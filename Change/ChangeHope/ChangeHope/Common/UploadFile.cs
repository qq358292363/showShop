namespace ChangeHope.Common
{
    using System;
    using System.IO;
    using System.Web;
    using System.Web.UI.WebControls;

    public class UploadFile
    {
        private string extensionLim = "";
        private int fileLengthLim = 0;
        private string filePath = "";
        private string fileSaveMethod = "R";
        private bool haveLoad;
        private string message = "";
        private HttpPostedFile myFile = null;
        private FileUpload postedFile = null;
        private string savePath = "userfile";

        public bool HTMLUpLoad()
        {
            string fileName = "";
            string str2 = "";
            if (this.myFile.FileName.Length > 0)
            {
                fileName = this.myFile.FileName;
                str2 = fileName.Substring(fileName.LastIndexOf('.'));
                if (this.extensionLim.IndexOf(str2.ToLower()) < 0)
                {
                    this.message = "不能上传该类型文件，您只能上传以下文件：" + this.extensionLim;
                    return false;
                }
                if ((this.myFile.ContentLength / 0x400) > this.fileLengthLim)
                {
                    this.message = "上传的文件大于最大限制：" + this.fileLengthLim + "KB";
                    return false;
                }
                if (this.fileSaveMethod.Equals("R"))
                {
                    fileName = DEncryptHelper.GetRandomNumber() + "_" + DEncryptHelper.GetRandWord(10) + str2;
                }
                string path = ServerInfo.GetRootPath() + this.savePath + @"\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                this.myFile.SaveAs(path + fileName);
                if (this.savePath.Substring(0, 1) == "/")
                {
                    this.savePath = this.savePath.Substring(1, this.savePath.Length - 1);
                }
                this.filePath = this.savePath + "/" + fileName;
                this.haveLoad = true;
            }
            else
            {
                this.haveLoad = false;
            }
            return true;
        }

        public bool Upload()
        {
            string fileName = "";
            string str2 = "";
            if (this.postedFile.PostedFile.ContentLength > 0)
            {
                fileName = this.postedFile.PostedFile.FileName;
                str2 = fileName.Substring(fileName.LastIndexOf('.'));
                if (this.extensionLim.IndexOf(str2.ToLower()) < 0)
                {
                    this.message = "不能上传该类型文件，您只能上传以下文件：" + this.extensionLim;
                    return false;
                }
                if ((this.postedFile.PostedFile.ContentLength / 0x400) > this.fileLengthLim)
                {
                    this.message = "上传的文件大于最大限制：" + this.fileLengthLim + "KB";
                    return false;
                }
                if (this.fileSaveMethod.Equals("R"))
                {
                    fileName = DEncryptHelper.GetRandomNumber() + "_" + DEncryptHelper.GetRandWord(10) + str2;
                }
                else
                {
                    fileName = fileName.Substring(fileName.LastIndexOf(@"\"));
                }
                string path = ServerInfo.GetRootPath() + this.savePath + @"\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                this.postedFile.SaveAs(path + fileName);
                if (this.savePath.Substring(0, 1) == "/")
                {
                    this.savePath = this.savePath.Substring(1, this.savePath.Length - 1);
                }
                this.filePath = this.savePath + "/" + fileName;
                this.haveLoad = true;
            }
            else
            {
                this.message = "上传文件不能为空";
                this.haveLoad = false;
            }
            return haveLoad;
        }

        public string ExtensionLim
        {
            get
            {
                return this.extensionLim;
            }
            set
            {
                this.extensionLim = value;
            }
        }

        public int FileLengthLim
        {
            get
            {
                return this.fileLengthLim;
            }
            set
            {
                this.fileLengthLim = value;
            }
        }

        public string FilePath
        {
            get
            {
                return this.filePath;
            }
            set
            {
                this.filePath = value;
            }
        }

        public string FileSaveMethod
        {
            get
            {
                return this.fileSaveMethod;
            }
            set
            {
                this.fileSaveMethod = value;
            }
        }

        public bool HaveLoad
        {
            get
            {
                return this.haveLoad;
            }
            set
            {
                this.haveLoad = value;
            }
        }

        public string Message
        {
            get
            {
                return this.message;
            }
        }

        public HttpPostedFile MyFile
        {
            get
            {
                return this.myFile;
            }
            set
            {
                this.myFile = value;
            }
        }

        public FileUpload PostedFile
        {
            get
            {
                return this.postedFile;
            }
            set
            {
                this.postedFile = value;
            }
        }

        public string SavePath
        {
            get
            {
                return this.savePath;
            }
            set
            {
                this.savePath = value;
            }
        }
    }
}

