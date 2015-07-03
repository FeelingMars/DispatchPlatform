using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace VoiceDispatchManage.Tools
{
    class FtpFileInfo
    {
        public string FileName;
        public string FileFullName;
        //public DateTime ModifyDateTime;
        public bool IsDirectory;
    }

    class FtpHelper
    {
        private string ftpServer;
        private string userName;
        private string password;
        FtpWebRequest ftpRequest = null;
        private string errMsg;
        public string ErrMsg
        {
            get { return errMsg; }
            set { errMsg = value; }
        }
        public bool IsAnonymous
        {
            get
            {
                return !(userName != null && userName.Trim() != String.Empty && password != null && password.Trim() != string.Empty);

            }
        }

        public List<FtpFileInfo> lstftpfile = new List<FtpFileInfo>();

        public List<FtpFileInfo> lstLocalfile = new List<FtpFileInfo>();

        public FtpHelper(string ftpServer, string userName, string password)
        {
            this.ftpServer = ftpServer;
            this.userName = userName;
            this.password = password;
        }
       
        //查找ftp文件夹中的文件
        public List<FtpFileInfo> GetFilesListByForder(string serverPath)
        {
            List<FtpFileInfo> lstfileName = new List<FtpFileInfo>();
            StreamReader sr = null;
            //Uri uri = new Uri("ftp://" + ftpServer + "/" + serverPath);

            Uri uri = null;
            if (serverPath != "")
                uri = new Uri(serverPath);
            else
                uri = new Uri("ftp://" + ftpServer + "/");

            try
            {
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(uri);
                if (ftpRequest == null) throw new Exception("无法打开ftp服务器连接");
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;   //列表   

                if (!IsAnonymous)
                {
                    ftpRequest.Credentials = new NetworkCredential(userName, password);
                }

                sr = new StreamReader(ftpRequest.GetResponse().GetResponseStream());
                while (!sr.EndOfStream)//读取列表
                {

                    char[] splitChar = { ' ' };
                    string temp = sr.ReadLine();
                    string[] tmpArray = temp.Split(splitChar, StringSplitOptions.RemoveEmptyEntries);

                    if (tmpArray.Length != 9)
                    {
                        continue;
                    }
                    FtpFileInfo ffi = new FtpFileInfo();
                    ffi.IsDirectory = tmpArray[0].StartsWith("d");
                    string tempName= tmpArray[8].Replace(".","");
                    if(string.IsNullOrEmpty(tempName)) continue;

                    ffi.FileName = tmpArray[8];
                    if (serverPath != "")
                        ffi.FileFullName = serverPath + "/" + tmpArray[8];
                    else
                        ffi.FileFullName = "ftp://" + ftpServer + "/" +  tmpArray[8];
                    lstfileName.Add(ffi);
                }
            }
            catch (Exception ex)
            {
                //TODO: 异常处理.
                throw ex;
            }
            finally
            {
                if (sr != null) sr.Close();
            }
            return lstfileName;
        }

        //查找ftp服务器上的文件</summary>
        public void FindFtpFileList(string serverPath)
        {
            Uri uri = null;
            if(serverPath!="")  
                uri = new Uri(serverPath);
            else
                uri = new Uri("ftp://" + ftpServer + "/");

            StreamReader sr = null;

            List<FtpFileInfo> lstfilename = GetFilesListByForder(serverPath);
            foreach (FtpFileInfo Fileinfo in lstfilename)
            {
                //是文件 
                if (Fileinfo.IsDirectory == false)
                {
                    lstftpfile.Add(Fileinfo);
                    //Download();
                }
                //对于子目录，进行递归调用 
                else
                {
                    if (Fileinfo.FileFullName == null)
                    {
                    }
                    else
                       FindFtpFileList(Fileinfo.FileFullName);
                }

            }

        }

        /// 下载Download
        /// </summary>
        /// <param name="serverPath"></param>
        /// <param name="serverFileName"></param>
        /// <param name="localPath"></param>
        /// <param name="localFileName"></param>
        /// <returns></returns>
        public bool Download(string serverFullFileName, string localPath)
        {
            FileStream outputStream = null;
            Stream ftpStream = null;
            try
            {
                //ftp://192.168.1.220/tffs0/cfg/

                string strServer = "ftp://" + ftpServer;

                localPath = localPath + serverFullFileName.Replace(strServer, "").Replace("/","\\");
                FileInfo fileInf = new FileInfo(localPath);
                if (!Directory.Exists(fileInf.DirectoryName))
                    Directory.CreateDirectory(fileInf.DirectoryName);
                outputStream = new FileStream(localPath, FileMode.Create);
                if (outputStream == null)
                {
                    errMsg = "无法创建本地文件";
                    return false;
                }
                string strUri = serverFullFileName;//"ftp://" + ftpServer + serverPath + "/" + serverFileName
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(new Uri(strUri));
                if (ftpRequest == null)
                {
                    errMsg = "无法连接服务器";
                    return false;
                }
                ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                ftpRequest.UseBinary = true;
                //用户验证
                if (!IsAnonymous)
                {
                    ftpRequest.Credentials = new NetworkCredential(userName, password);
                }
                ftpStream = ftpRequest.GetResponse().GetResponseStream();
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];

                while ((readCount = ftpStream.Read(buffer, 0, bufferSize)) > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                }
            }
            catch (Exception ex)
            {
                errMsg = ex.ToString();
                return false;
            }
            finally
            {
                if (ftpStream != null) ftpStream.Close();
                if (outputStream != null) outputStream.Close();
            }
            //FileInfo fi = new FileInfo(localPath + "\\" + localFileName);
            //fi.LastWriteTime = GetFileModifyTime(serverPath, serverFileName);
            return true;
        }


        /// 上传文件到FTP服务器上【注意：当文件存在时，覆盖原来的文件】
        /// </summary>
        /// <param name="fileName">本地文件路径（例如：d:\ftp_upload1.txt）</param>
        /// <param name="ftpUrl">FTP服务器路径（例如：ftp://192.168.10.176:21/ftp_upload.txt ）</param>
        /// <returns>0：成功； 1：失败</returns>
        public int UpToFtpFile(string LocalFullfileName,string localPath)
        {
            //int nstatus = ftpOper.UploadFun(@"f:\tffs0/cfg/cli_log01.txt", "ftp://192.168.1.220/tffs0/cfg/cli_log01.txt")
           
            Stream requestStream = null;
            FileStream fileStream = null;
            FtpWebResponse uploadResponse = null;
            try
            {
                string strServer = "ftp://" + ftpServer ;
                //serverPath ="ftp://172.21.2.59/tffs0/cfg/";
                string serverPath = strServer + LocalFullfileName.Replace(localPath, "").Replace("\\", "/");
                //string fullDir = "tffs0/cfg/";
                //判断ftp文件目录是否存在，不存在创建
                FileInfo fileInf = new FileInfo(LocalFullfileName);
                string fullDir = fileInf.Directory.ToString().Replace(localPath, "").Replace("\\", "/"); 
                FtpCheckDirectoryExist(fullDir);

                FtpWebRequest uploadRequest = (FtpWebRequest)WebRequest.Create(serverPath);
                uploadRequest.Method = WebRequestMethods.Ftp.UploadFile;
                uploadRequest.Proxy = null;
                if (!IsAnonymous)
                {
                    uploadRequest.Credentials = new NetworkCredential(userName, password);
                }
                requestStream = uploadRequest.GetRequestStream();
                fileStream = File.Open(LocalFullfileName, FileMode.Open);

                byte[] buffer = new byte[1024];
                int bytesRead;
                while (true)
                {
                    bytesRead = fileStream.Read(buffer, 0, buffer.Length);
                    if (bytesRead == 0)
                        break;
                    requestStream.Write(buffer, 0, bytesRead);
                }
                requestStream.Close();

                uploadResponse = (FtpWebResponse)uploadRequest.GetResponse();
                if (uploadResponse.StatusCode == FtpStatusCode.ClosingData)
                {
                    return 0;
                }
                else
                {
                    errMsg = "上传文件失败,code=" + uploadResponse.StatusCode.ToString();
                }

            }
            catch (Exception ex)
            {
                errMsg = ex.Message;
            }
            finally
            {
                if (uploadResponse != null)
                    uploadResponse.Close();
                if (fileStream != null)
                    fileStream.Close();
                if (requestStream != null)
                    requestStream.Close();
            }

            return 1;
        }

        /// 判断ftp服务器上该目录是否存在
        /// </summary>
        /// <param name="dirName"></param>
        /// <param name="ftpHostIP"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool ftpIsExistsFile(string ftpPath)
        {
            bool flag = true;
            try
            {
                Uri uri =new Uri(ftpPath);// "ftp://" + ftpHostIP + "/" + dirName;
                //根据服务器信息FtpWebRequest创建类的对象
                FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(uri);
                //提供身份验证信息
                if (!IsAnonymous)
                {
                    ftp.Credentials = new NetworkCredential(userName, password);
                }
                //设置请求完成之后是否保持到FTP服务器的控制连接，默认值为true
                ftp.KeepAlive = false;
                ftp.Method = WebRequestMethods.Ftp.ListDirectory;
                FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();
                response.Close();
            }
            catch (Exception)
            {
                flag = false;
            }
            return flag;
        }

        /// 在ftp服务器上创建目录
        /// </summary>
        /// <param name="dirName">创建的目录名称</param>
        /// <param name="ftpHostIP">ftp地址</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        public void MakeDir(string serverPath)
        {
            try
            {
                string uri = serverPath;// "ftp://" + ftpHostIP + "/" + dirName;

                FtpWebRequest ftp = (FtpWebRequest)FtpWebRequest.Create(uri);

                //根据服务器信息FtpWebRequest创建类的对象
                //FtpWebRequest result = (FtpWebRequest)FtpWebRequest.Create(URI);
                //提供身份验证信息
                //提供身份验证信息
                if (!IsAnonymous)
                {
                    ftp.Credentials = new NetworkCredential(userName, password);
                }
                //result.Credentials = new System.Net.NetworkCredential(username, password);
                //设置请求完成之后是否保持到FTP服务器的控制连接，默认值为true
                //ftp.KeepAlive = false;
               

               // FtpWebRequest ftp = GetRequest(uri);
               
                ftp.Method = WebRequestMethods.Ftp.MakeDirectory;

                FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();
                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //判断文件的目录是否存,不存则创建   
        public  void FtpCheckDirectoryExist(string destFilePath)
        {
            //string fullDir = FtpParseDirectory(destFilePath);
            ////serverPath ="ftp://172.21.2.59/tffs0/cfg/";
            //string ftpPath = "tffs0/cfg/";

            string[] dirs = destFilePath.Split('/');
            string curDir = "/";
            for (int i = 0; i < dirs.Length; i++)
            {
                string dir = dirs[i];
                //如果是以/开始的路径,第一个为空     
                if (dir != null && dir.Length > 0)
                {
                    try
                    {
                        curDir += dir + "/";
                        FtpMakeDir(curDir);
                    }
                    catch (Exception)
                    { }
                }
            }
        }

        public static string FtpParseDirectory(string destFilePath)
        {
            return destFilePath.Substring(0, destFilePath.LastIndexOf("/"));
        }

        //创建目录   
        public  Boolean FtpMakeDir(string localFile)
        {
            //string str = "ftp://172.21.2.59/tffs0/";// +ftpServer + localFile;
            string ftpPath = "ftp://" + ftpServer + localFile;
            if (ftpIsExistsFile(ftpPath)) return true;
            FtpWebRequest req = (FtpWebRequest)WebRequest.Create(ftpPath);
            req.Credentials = new NetworkCredential(userName, password);
            req.Method = WebRequestMethods.Ftp.MakeDirectory;
            try
            {
                FtpWebResponse response = (FtpWebResponse)req.GetResponse();
                response.Close();
            }
            catch (Exception)
            {
                req.Abort();
                return false;
            }
            req.Abort();
            return true;
        }  


        /// 删除目录
        /// </summary>
        /// <param name="dirName">创建的目录名称</param>
        /// <param name="ftpHostIP">ftp地址</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        public void delDir(string dirName, string ftpHostIP)
        {
            try
            {
                string uri = "ftp://172.21.2.59/tffs0/"; //"ftp://" + ftpHostIP + "/" + dirName;
                System.Net.FtpWebRequest ftp = GetRequest(uri);
                ftp.Method = WebRequestMethods.Ftp.RemoveDirectory;
                ftp.Credentials = new NetworkCredential("zhai","1");//userName, password);
                FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();
                response.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        /// 文件重命名
        /// </summary>
        /// <param name="currentFilename">当前目录名称</param>
        /// <param name="newFilename">重命名目录名称</param>
        /// <param name="ftpServerIP">ftp地址</param>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        public void Rename(string currentFilename, string newFilename, string ftpServerIP)
        {
            try
            {
                FileInfo fileInf = new FileInfo(currentFilename);
                string uri = "ftp://" + ftpServerIP + "/" + fileInf.Name;
                System.Net.FtpWebRequest ftp = GetRequest(uri);
                ftp.Method = WebRequestMethods.Ftp.Rename;

                ftp.RenameTo = newFilename;
                FtpWebResponse response = (FtpWebResponse)ftp.GetResponse();

                response.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>查找本地文件</summary>
        public void FindLocalFile(string filePath)
        {
            DirectoryInfo parentdi = new DirectoryInfo(filePath);
            //不是目录 
            if (parentdi == null) return;
            //路径不存在
            if (!Directory.Exists(filePath)) return;

            foreach (FileSystemInfo Fileinfo in parentdi.GetFileSystemInfos())
            {
                FileInfo file = Fileinfo as FileInfo;
                //是文件 
                if (file != null)
                {
                    FtpFileInfo ffi = new FtpFileInfo();
                    ffi.IsDirectory = false;
                    ffi.FileName = file.Name;
                    ffi.FileFullName = file.FullName;
                    lstLocalfile.Add(ffi);
                }
                //对于子目录，进行递归调用 
                else
                    FindLocalFile(Fileinfo.FullName);

            }

        }


        private  FtpWebRequest GetRequest(string URI)
        {
            //根据服务器信息FtpWebRequest创建类的对象
            FtpWebRequest result = (FtpWebRequest)FtpWebRequest.Create(URI);
            //提供身份验证信息
            //提供身份验证信息
            if (!IsAnonymous)
            {
                result.Credentials = new NetworkCredential(userName, password);
            }
            //result.Credentials = new System.Net.NetworkCredential(username, password);
            //设置请求完成之后是否保持到FTP服务器的控制连接，默认值为true
            result.KeepAlive = false;
            return result;
        }


        public DateTime GetFileModifyTime(string serverPath, string fileName)
        {
            Uri uri = new Uri("ftp://" + ftpServer + serverPath + "/" + fileName);
            DateTime dt = DateTime.Now;
            try
            {
                ftpRequest = (FtpWebRequest)WebRequest.Create(uri);
                if (!IsAnonymous)
                {
                    ftpRequest.Credentials = new NetworkCredential(userName, password);
                }
                ftpRequest.Method = WebRequestMethods.Ftp.GetDateTimestamp;
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = false;
                dt = ((FtpWebResponse)ftpRequest.GetResponse()).LastModified;
            }
            catch (Exception ex)
            {
                //TODO: 错误处理
                throw ex;
            }
            return dt;
        }
    }

}
