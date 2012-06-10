namespace ChangeHope.Common
{
    using System;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading;
    using System.Web.Security;

    public class DEncryptHelper
    {
        public static string Decrypt(string encrypted, string key)
        {
            return Decrypt(encrypted, key, Encoding.Default);
        }

        public static byte[] Decrypt(byte[] encrypted, byte[] key)
        {
            TripleDESCryptoServiceProvider provider = new TripleDESCryptoServiceProvider();
            provider.Key = MakeMD5(key);
            provider.Mode = CipherMode.ECB;
            return provider.CreateDecryptor().TransformFinalBlock(encrypted, 0, encrypted.Length);
        }

        public static string Decrypt(string encrypted, string key, Encoding encoding)
        {
            byte[] buffer = Convert.FromBase64String(encrypted);
            byte[] bytes = Encoding.Default.GetBytes(key);
            return encoding.GetString(Decrypt(buffer, bytes));
        }

        public static byte[] Encrypt(byte[] original, byte[] key)
        {
            TripleDESCryptoServiceProvider provider = new TripleDESCryptoServiceProvider();
            provider.Key = MakeMD5(key);
            provider.Mode = CipherMode.ECB;
            return provider.CreateEncryptor().TransformFinalBlock(original, 0, original.Length);
        }

        public static string Encrypt(string original, int encryptFormat)
        {
            switch (encryptFormat)
            {
                case 0:
                    return FormsAuthentication.HashPasswordForStoringInConfigFile(original, "SHA1");

                case 1:
                    return FormsAuthentication.HashPasswordForStoringInConfigFile(original, "MD5");
            }
            return "";
        }

        public static string Encrypt(string original, string key)
        {
            byte[] bytes = Encoding.Default.GetBytes(original);
            byte[] buffer2 = Encoding.Default.GetBytes(key);
            return Convert.ToBase64String(Encrypt(bytes, buffer2));
        }

        public static string GetRandomNumber()
        {
            string str = "";
            str = DateTime.Now.ToString("yyyyMMddHHmmss");
            Random random = new Random();
            str = str + random.Next(0x989680, 0x5f5e0ff).ToString();
            random = null;
            return str;
        }

        public static string GetRandomNumber(int length, bool isSleep)
        {
            if (isSleep)
            {
                Thread.Sleep(3);
            }
            string str = "";
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                str = str + random.Next(10).ToString();
            }
            return str;
        }

        public static string GetRandWord(int length)
        {
            string str = string.Empty;
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                char ch;
                int num = random.Next();
                if ((num % 2) == 0)
                {
                    ch = (char) (0x30 + ((ushort) (num % 10)));
                }
                else
                {
                    ch = (char) (0x41 + ((ushort) (num % 0x1a)));
                }
                str = str + ch.ToString();
            }
            return str;
        }

        public static byte[] MakeMD5(byte[] original)
        {
            byte[] buffer = new MD5CryptoServiceProvider().ComputeHash(original);
            return buffer;
        }

        public static string MakeMD5(string original, string encoding)
        {
            byte[] buffer = new MD5CryptoServiceProvider().ComputeHash(Encoding.GetEncoding(encoding).GetBytes(original));
            StringBuilder builder = new StringBuilder(0x20);
            for (int i = 0; i < buffer.Length; i++)
            {
                builder.Append(buffer[i].ToString("x").PadLeft(2, '0'));
            }
            return builder.ToString();
        }
    }
}

