namespace ChangeHope.Common
{
    using System;
    using System.Collections;
    using System.Text;
    using System.Text.RegularExpressions;

    public class StringHelper
    {
        public static string Filter(string sInput)
        {
            if ((sInput == null) || (sInput == ""))
            {
                return null;
            }
            string input = sInput.ToLower();
            string str2 = sInput;
            string str = "*|and|exec|insert|select|delete|update|count|master|truncate|declare|char(|mid(|chr(|'";
            if (Regex.Match(input, Regex.Escape(str), RegexOptions.IgnoreCase).Success)
            {
                str2 = str2.Replace(sInput, "''");
            }
            else
            {
                str2 = str2.Replace("'", "''");
            }
            return str2;
        }

        public static string InputTexts(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return string.Empty;
            }
            text = Regex.Replace(text, @"[\s]{2,}", " ");
            text = Regex.Replace(text, @"(<[b|B][r|R]/*>)+|(<[p|P](.|\n)*?>)", "\n");
            text = Regex.Replace(text, @"(\s*&[n|N][b|B][s|S][p|P];\s*)+", " ");
            text = Regex.Replace(text, @"<(.|\n)*?>", string.Empty);
            text = text.Replace("'", "''");
            return text;
        }

        public static double String2Double(string str)
        {
            if (ValidateHelper.IsDecimal(str))
            {
                return double.Parse(str);
            }
            return 0.0;
        }

        public static DateTime StringToDateTime(string str)
        {
            if (ValidateHelper.IsDateTime(str))
            {
                return DateTime.Parse(str);
            }
            return DateTime.Parse("1900-1-1");
        }

        public static int StringToInt(string str)
        {
            if (ValidateHelper.IsNumberSign(str))
            {
                return int.Parse(str);
            }
            return 0;
        }

        public static string SubString(string SoucreStr, int len)
        {
            string str = SoucreStr;
            if (SoucreStr.Length >= len)
            {
                str = SoucreStr.Substring(0, len);
            }
            return str;
        }

        public static string SubString(string str, int begin, int length)
        {
            if (str.Length < begin)
            {
                return "";
            }
            if (length >= (str.Length - begin))
            {
                length = str.Length - begin;
            }
            return str.Substring(begin, length);
        }

        public static string SubStringAndAppend(string str, int length, string appendCode)
        {
            return (SubString(str, length) + appendCode);
        }

        public static string SubStringHTML(string htmlString, int length, string appendCode)
        {
            MatchCollection matchs = null;
            int num2;
            StringBuilder builder = new StringBuilder();
            int num = 0;
            bool flag = false;
            bool flag2 = false;
            char[] chArray = htmlString.ToCharArray();
            for (num2 = 0; num2 < chArray.Length; num2++)
            {
                char ch = chArray[num2];
                if (ch.Equals("<"))
                {
                    flag = true;
                }
                else if (ch.Equals("&"))
                {
                    flag2 = true;
                }
                else if (ch.Equals(">") && flag)
                {
                    num--;
                    flag = false;
                }
                else if (ch.Equals(";") && flag2)
                {
                    flag2 = false;
                }
                if (!flag2 && !flag)
                {
                    num++;
                    if (Encoding.Default.GetBytes(ch.ToString()).Length > 1)
                    {
                        num++;
                    }
                }
                builder.Append(ch);
                if (num >= length)
                {
                    break;
                }
            }
            builder.Append(appendCode);
            matchs = Regex.Matches(Regex.Replace(Regex.Replace(Regex.Replace(builder.ToString(), "(>)[^<>]*(<?)", "$1$2", RegexOptions.IgnoreCase), "</?(area|base|basefont|body|br|col|colgroup|dd|dt|frame|head|hr|html|img|input|isindex|li|link|meta|option|p|param|tbody|td|tfoot|th|thead|tr)[^<>]*/?>", "", RegexOptions.IgnoreCase), @"<([a-zA-Z]+)[^<>]*>(.*?)</\1>", "", RegexOptions.IgnoreCase), "<([a-zA-Z]+)[^<>]*>");
            ArrayList list = new ArrayList();
            foreach (Match match in matchs)
            {
                list.Add(match.Result("$1"));
            }
            for (num2 = list.Count - 1; num2 >= 0; num2--)
            {
                builder.Append("</");
                builder.Append(list[num2]);
                builder.Append(">");
            }
            return builder.ToString();
        }

        public static string ToString(object obj)
        {
            if (obj != null)
            {
                return obj.ToString();
            }
            return "";
        }
    }
}

