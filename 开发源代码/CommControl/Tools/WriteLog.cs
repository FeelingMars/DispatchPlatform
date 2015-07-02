using System;
using System.Collections.Generic;

using System.Text;

namespace CommControl.Tools
{
    public static class  WriteLog
    {
        public static readonly string APP_EXE_PATH = System.Windows.Forms.Application.StartupPath;
        public static void AppendErrorLog(string Errormessage)
        {
            if (!System.IO.Directory.Exists(APP_EXE_PATH + "\\log"))
                System.IO.Directory.CreateDirectory(APP_EXE_PATH + "\\log");
            string strPath = APP_EXE_PATH + string.Format("\\log\\error{0}.log", DateTime.Now.ToString("yyyy-MM-dd"));
            System.IO.File.AppendAllText(strPath, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "：" + Errormessage + "\r\n");
        }

        public static void AppendLog(string Message)
        {
            if (!System.IO.Directory.Exists(APP_EXE_PATH + "\\log"))
                System.IO.Directory.CreateDirectory(APP_EXE_PATH + "\\log");
            string strPath = APP_EXE_PATH + string.Format("\\log\\log{0}.log", DateTime.Now.ToString("yyyy-MM-dd"));
            System.IO.File.AppendAllText(strPath, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "：" + Message + "\r\n");
        }

        public static void AppendLog(string filename, string message)
        {
            if (!System.IO.Directory.Exists(APP_EXE_PATH + "\\log"))
                System.IO.Directory.CreateDirectory(APP_EXE_PATH + "\\log");
            string strPath;
            strPath = APP_EXE_PATH + string.Format("\\log\\" + filename + "{0}.log", DateTime.Now.ToString("yyyy-MM-dd"));
            System.IO.File.AppendAllText(strPath, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff") + "：" + message + "\r\n");
        }

        public static void AppendErrorLog(Exception ex)
        {
            string strText, strCaption;
            strCaption = ex.Source;
            strText = string.Format("捕获的错误：{0}\n\r方法名称:{1}", ex.ToString(), ex.TargetSite.Name);
            CommControl.Tools.WriteLog.AppendErrorLog(strCaption + "\n\r" + strText);

         }

    }
}
