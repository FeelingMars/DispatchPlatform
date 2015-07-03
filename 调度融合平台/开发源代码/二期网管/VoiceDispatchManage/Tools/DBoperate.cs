using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace VoiceDispatchManage.Tools
{
   
        /// 
        /// DbOper类,主要应用SQLDMO实现对Microsoft SQL Server数据库的备份和恢复
        /// 
        public sealed class DbOper
        {
            /// 
            /// DbOper类的构造函数
            /// 
            public DbOper()
            {
            }

            //BACKUP DATABASE BW_VoiceDispatch TO DISK='D:\C#\BW_VoiceDispatch'
            //RESTORE DATABASE BW_VoiceDispatch FROM DISK ='D:\C#\BW_VoiceDispatch'
            //RESTORE DATABASE BW_VoiceDispatch FROM DISK = 'D:\C#\BW_VoiceDispatch.bak' WITH REPLACE
            //RESTORE DATABASE BW_VoiceDispatch FROM DISK ='D:\C#\BW_VoiceDispatch' WITH MOVE 'BW_VoiceDispatch_Data' 
            //        TO 'D:\Data\BW_VoiceDispatch.mdf',MOVE 'BW_VoiceDispatch_log' TO 'D:\Data\BW_VoiceDispatch.ldf'"

            public  string hostID = Global.Params.ConfigModel.DBInfo.HostID;//".";
            public  string password = Global.Params.ConfigModel.DBInfo.Password;//"";
            public  string database = Global.Params.ConfigModel.DBInfo.DatabaseName;
            public string errorMes = "";
            /// 
            /// 数据库备份
            /// 
            public  bool DbBackup(string backPath)
            {
                try
                {
                    if (!System.IO.Directory.Exists(backPath))
                        System.IO.Directory.CreateDirectory(backPath);
                    if (System.IO.File.Exists(backPath + "\\" + database + ".bak")) System.IO.File.Delete(backPath + "\\" + database + ".bak");
                    string sqlBack = @"backup database {0} to disk='{1}'";
                    string sql = string.Format(sqlBack, database, backPath + "\\" + database + ".bak");
                    if (ExecuteSql(sql))
                        return true;
                    else
                        return false;
                }
                catch(Exception ex)
                {
                    CommControl.Tools.WriteLog.AppendErrorLog(ex);
                    return false;
                }
 
            }

            /// 
            /// 数据库恢复
            /// 
            public  bool DbRestore(string restorePath)
            {
                KillUseDbPross();
               //string sqlRestore = @"restore database {0} from disk='{1}' ";// WITH REPLACE";

                string sqlRestore = "";// "drop DATABASE " + database + "  ";

                sqlRestore += @"RESTORE DATABASE {0} FROM DISK = '{1}.bak' WITH REPLACE, "+  
                           @"MOVE '{0}_Data'  TO '{1}.mdf',"+
                           @"MOVE '{0}_Log'  TO '{1}.ldf'" ;

               //sqlRestore = @"RESTORE DATABASE BW_VoiceDispatch FROM DISK = 'D:\C#\BW_VoiceDispatch.bak' WITH REPLACE, " +
               //                          @"MOVE 'BW_VoiceDispatch_Data'  TO  'D:\C#\BW_VoiceDispatch.mdf'," +
               //                          @"MOVE 'BW_VoiceDispatch_Log'  TO 'D:\C#\BW_VoiceDispatch.ldf'";


               string sql = string.Format(sqlRestore, database, restorePath + "\\" + database);
                if (ExecuteSql(sql))
                    return true;
                else
                    return false;
            }

            private  bool ExecuteSql(string Sql)
            {
                try
                {
                    CommControl.Tools.WriteLog.AppendLog(Sql);

                    //OleDbConnection con = new OleDbConnection("Provider=SQLOLEDB;Data Source=(local);Initial Catalog=master;User ID=sa;Password=1234;");
                    OleDbConnection con = new OleDbConnection("Provider=SQLOLEDB;Data Source=" + hostID +
                                          ";Initial Catalog=master;User ID=sa; Password=" + password + ";");
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand(Sql, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 0;
                    cmd.ExecuteNonQuery();
                    errorMes = "";
                   
                    return true;
                }
                catch (Exception e)
                {
                    errorMes = e.Message.ToString();
                    return false;
                }
            }

            public void KillUseDbPross()
            {
                 string Sql = "select spid from sysprocesses where dbid=db_id('" + database + "')";
                 DataTable dt= GetDataTable(Sql);
                 if (dt.Rows.Count > 0)
                 {
                     for (int i = 0; i < dt.Rows.Count; i++)
                     {
                         string strSql = "kill " + dt.Rows[i][0].ToString();
                         ExecuteSql(strSql);
                     }
                 }
            }

            public DataTable GetDataTable(string Sql)
            {
                 DataTable dt = new DataTable();
                 try
                 {
                     OleDbConnection con = new OleDbConnection("Provider=SQLOLEDB;Data Source=" + hostID +
                                           ";Initial Catalog=master;User ID=sa; Password=" + password + ";");
                     con.Open();
                     OleDbCommand cmd = new OleDbCommand(Sql, con);
                     cmd.CommandType = CommandType.Text;
                     cmd.CommandTimeout = 0;
                     OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                     da.Fill(dt);
                     errorMes = "";
                 }
                 catch (Exception e)
                 {
                     errorMes = e.Message.ToString();
                    
                 }
                 return dt;
            }

        }



    
}
