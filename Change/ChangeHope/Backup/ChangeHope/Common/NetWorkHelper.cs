namespace ChangeHope.Common
{
    using SQLDMO;
    using System;
    using System.Configuration;
    using System.IO;
    using System.Net;
    using System.Text;

    public class NetWorkHelper
    {
        public static bool DbBackup(string url)
        {
            bool flag;
            Backup backup = new BackupClass();
            SQLServer serverObject = new SQLServerClass();
            try
            {
                serverObject.LoginSecure = false;
                serverObject.Connect(ConfigurationManager.AppSettings["Server"], ConfigurationManager.AppSettings["User"], ConfigurationManager.AppSettings["Password"]);
                backup.Action = SQLDMO_BACKUP_TYPE.SQLDMOBackup_Database;
                backup.Database = ConfigurationManager.AppSettings["DB"];
                backup.Files = url;
                backup.BackupSetName = ConfigurationManager.AppSettings["DB"];
                backup.BackupSetDescription = "数据库备份";
                backup.Initialize = true;
                backup.SQLBackup(serverObject);
                flag = true;
            }
            catch
            {
                flag = false;
            }
            finally
            {
                serverObject.DisConnect();
            }
            return flag;
        }

        public static string ReadPageContentByUrl(string url, string encodingType)
        {
            try
            {
                StringBuilder builder = new StringBuilder();
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
                request.AllowAutoRedirect = true;
                HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream responseStream = response.GetResponseStream();
                    Encoding encoding = Encoding.GetEncoding(encodingType);
                    StreamReader reader = new StreamReader(responseStream, encoding);
                    char[] buffer = new char[500];
                    for (int i = reader.Read(buffer, 0, 0x100); i > 0; i = reader.Read(buffer, 0, 0x100))
                    {
                        string str = new string(buffer, 0, i);
                        builder.Append(str);
                    }
                    response.Close();
                    return builder.ToString();
                }
                response.Close();
                return null;
            }
            catch
            {
                return "网络异常...请稍后再试。";
            }
        }
    }
}

