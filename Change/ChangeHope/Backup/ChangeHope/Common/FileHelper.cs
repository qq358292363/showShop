namespace ChangeHope.Common
{
    using System;
    using System.IO;
    using System.Text;

    public class FileHelper
    {
        private Encoding defaultEncoding = Encoding.UTF8;
        private int directoryIndex = 0;
        public StringBuilder fileTree = new StringBuilder();
        private int listIndex = 0;
        public string rootUrl = "";

        public bool CopyFile(string FileOldPath, string FileNewPath, bool IsReplaceFile)
        {
            try
            {
                if (File.Exists(FileOldPath))
                {
                    if (!File.Exists(FileNewPath))
                    {
                        if (!File.Exists(FileNewPath.Substring(0, FileNewPath.LastIndexOf(@"\"))))
                        {
                            this.CreateDirectory(FileNewPath.Substring(0, FileNewPath.LastIndexOf(@"\")));
                        }
                        File.Copy(FileOldPath, FileNewPath);
                        return true;
                    }
                    if (IsReplaceFile)
                    {
                        File.Delete(FileNewPath);
                        File.Copy(FileOldPath, FileNewPath);
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool CreateDirectory(string filePath)
        {
            try
            {
                if (!Directory.Exists(filePath))
                {
                    DirectoryInfo info = Directory.CreateDirectory(filePath);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CreateFile(string filePath, string fileContent)
        {
            try
            {
                if (this.CreateDirectory(Path.GetDirectoryName(filePath)))
                {
                    Encoding defaultEncoding = this.defaultEncoding;
                    StreamWriter writer = new StreamWriter(filePath, false, defaultEncoding);
                    writer.WriteLine(fileContent);
                    writer.Flush();
                    writer.Close();
                    writer = null;
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteDirectory(string directoryPath)
        {
            try
            {
                if (Directory.Exists(directoryPath))
                {
                    Directory.Delete(directoryPath);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteFile(string[] filePath)
        {
            bool flag = true;
            for (int i = 0; i < filePath.Length; i++)
            {
                if (!this.DeleteFile(filePath[i]))
                {
                    flag = false;
                }
            }
            return flag;
        }

        public void listFileName(string dir, int level)
        {
            try
            {
                string[] directories = Directory.GetDirectories(dir);
                foreach (string str in directories)
                {
                    this.directoryIndex++;
                    if (str.LastIndexOf(@"\") == -1)
                    {
                        this.fileTree.AppendLine(string.Concat(new object[] { "d.add(", this.directoryIndex, ",", level, ",'", str.Substring(str.LastIndexOf("/") + 1), "','javascript: GetFileUrl(filelist[", this.listIndex, "]);');" }));
                    }
                    else
                    {
                        this.fileTree.AppendLine(string.Concat(new object[] { "filelist[", this.listIndex, "]='", str.Replace(this.rootUrl + @"\", "").Replace(@"\", "/"), "';" }));
                        this.fileTree.AppendLine(string.Concat(new object[] { "d.add(", this.directoryIndex, ",", level, ",'", str.Substring(str.LastIndexOf(@"\") + 1), "','javascript: GetFileUrl(filelist[", this.listIndex, "]);');" }));
                    }
                    this.listIndex++;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public void listFiles(string dir, int level)
        {
            try
            {
                string[] directories = Directory.GetDirectories(dir);
                foreach (string str in directories)
                {
                    this.directoryIndex++;
                    if (str.LastIndexOf(@"\") == -1)
                    {
                        this.fileTree.AppendLine(string.Concat(new object[] { "d.add(", this.directoryIndex, ",", level, ",'", str.Substring(str.LastIndexOf("/") + 1), "');" }));
                    }
                    else
                    {
                        this.fileTree.AppendLine(string.Concat(new object[] { "d.add(", this.directoryIndex, ",", level, ",'", str.Substring(str.LastIndexOf(@"\") + 1), "');" }));
                    }
                    if (Directory.Exists(str))
                    {
                        this.listFiles(str, this.directoryIndex);
                    }
                }
                string[] files = Directory.GetFiles(dir, "*.*htm*");
                foreach (string str2 in files)
                {
                    this.directoryIndex++;
                    if (str2.LastIndexOf(@"\") == -1)
                    {
                        this.fileTree.AppendLine(string.Concat(new object[] { "filelist[", this.listIndex, "]='", str2.Replace(this.rootUrl + @"\", "").Replace(@"\", "/"), "';" }));
                        this.fileTree.AppendLine(string.Concat(new object[] { "d.add(", this.directoryIndex, ",", level, ",''", str2.Substring(str2.LastIndexOf("/") + 1), "','javascript: GetFileUrl(filelist[", this.listIndex, "]);');" }));
                    }
                    else
                    {
                        this.fileTree.AppendLine(string.Concat(new object[] { "filelist[", this.listIndex, "]='", str2.Replace(this.rootUrl + @"\", "").Replace(@"\", "/"), "';" }));
                        this.fileTree.AppendLine(string.Concat(new object[] { "d.add(", this.directoryIndex, ",", level, ",'", str2.Substring(str2.LastIndexOf(@"\") + 1), "','javascript: GetFileUrl(filelist[", this.listIndex, "]);');" }));
                    }
                    this.listIndex++;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        public string ReadFileContent(string filePath)
        {
            return this.ReadFileContent(filePath, this.defaultEncoding);
        }

        public string ReadFileContent(string filePath, Encoding encoding)
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath, encoding))
                {
                    return reader.ReadToEnd();
                }
            }
            catch
            {
                return "读取文件时产生不可预知的错误。";
            }
        }

        public static string ReadHtml(string Path)
        {
            string str = string.Empty;
            if (File.Exists(Path))
            {
                try
                {
                    using (StreamReader reader = new StreamReader(Path, Encoding.GetEncoding("UTF-8")))
                    {
                        str = reader.ReadToEnd();
                    }
                }
                catch
                {
                }
                return str;
            }
            return "模板不存在!";
        }

        public bool ReNameFile(string filePath, string oldName, string newName, int fileType)
        {
            try
            {
                if (fileType.Equals(0))
                {
                    if (Directory.Exists(filePath + @"\" + oldName))
                    {
                        Directory.Move(filePath + @"\" + oldName, filePath + @"\" + newName.Replace(".", ""));
                        return true;
                    }
                    return false;
                }
                if (File.Exists(filePath + @"\" + oldName))
                {
                    File.Move(filePath + @"\" + oldName, filePath + @"\" + newName);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public static string StringToHtml(string strText)
        {
            return strText.Replace(" ", "&nbsp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\r\n", "<br />").Replace("\"", "&quot;").Replace("'", "&#39;");
        }

        public bool WriteFileContent(string filePath, string fileContent, bool isAppend)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    this.CreateFile(filePath, "");
                }
                StreamWriter writer = new StreamWriter(filePath);
                writer.WriteLine(fileContent);
                writer.Close();
                writer.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

