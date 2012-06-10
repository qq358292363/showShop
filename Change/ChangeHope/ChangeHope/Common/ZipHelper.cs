namespace ChangeHope.Common
{
    using ICSharpCode.SharpZipLib.Zip;
    using System;
    using System.IO;
    using System.Runtime.InteropServices;

    public class ZipHelper
    {
        public bool UnZip(string sourceFile, string destinationFile)
        {
            bool flag = true;
            try
            {
                ZipEntry entry;
                ZipInputStream stream = new ZipInputStream(File.OpenRead(sourceFile));
                while ((entry = stream.GetNextEntry()) != null)
                {
                    bool flag3;
                    string directoryName = Path.GetDirectoryName(destinationFile);
                    if (!(Path.GetFileName(entry.Name.Replace("updatepacket/", "")) != string.Empty))
                    {
                        goto Label_010A;
                    }
                    if (entry.CompressedSize == 0L)
                    {
                        break;
                    }
                    Directory.CreateDirectory(Path.GetDirectoryName(destinationFile + entry.Name.Replace("updatepacket/", "")));
                    FileStream stream2 = File.Create(destinationFile + entry.Name.Replace("updatepacket/", ""));
                    int count = 0x800;
                    byte[] buffer = new byte[0x800];
                    goto Label_00FC;
                Label_00C9:
                    count = stream.Read(buffer, 0, buffer.Length);
                    if (count > 0)
                    {
                        stream2.Write(buffer, 0, count);
                    }
                    else
                    {
                        goto Label_0101;
                    }
                Label_00FC:
                    flag3 = true;
                    goto Label_00C9;
                Label_0101:
                    stream2.Close();
                Label_010A:;
                }
                stream.Close();
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public bool ZipFile(string[] files, string zipFilePath, out string err)
        {
            err = "";
            try
            {
                string[] strArray = files;
                using (ZipOutputStream stream = new ZipOutputStream(File.Create(zipFilePath)))
                {
                    stream.SetLevel(9);
                    byte[] buffer = new byte[0x1000];
                    foreach (string str in strArray)
                    {
                        ZipEntry entry = new ZipEntry(Path.GetFileName(str));
                        entry.DateTime = DateTime.Now;
                        stream.PutNextEntry(entry);
                        using (FileStream stream2 = File.OpenRead(str))
                        {
                            int num;
                            do
                            {
                                num = stream2.Read(buffer, 0, buffer.Length);
                                stream.Write(buffer, 0, num);
                            }
                            while (num > 0);
                        }
                    }
                    stream.Finish();
                    stream.Close();
                }
            }
            catch (Exception exception)
            {
                err = exception.Message;
                return false;
            }
            return true;
        }
    }
}

