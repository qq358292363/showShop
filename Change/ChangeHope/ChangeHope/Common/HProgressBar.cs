namespace ChangeHope.Common
{
    using System;
    using System.Web;

    public class HProgressBar
    {
        public static void Roll(string Msg, int Pos)
        {
            string s = string.Concat(new object[] { "<script language=\"javascript\">SetPorgressBar('", Msg, "',", Pos, ");</script>" });
            HttpContext.Current.Response.Write(s);
            HttpContext.Current.Response.Flush();
        }

        public static void Start()
        {
            Start("正在加载...");
        }

        public static void Start(string msg)
        {
            string s = "<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n<head>\r\n<title></title>\r\n\r\n";
            s = ((((((((((s + "<style>body {text-align:center;margin-top: 50px;}#ProgressBarSide {height:25px;border:1px #2F2F2F;width:65%;background:#EEFAFF;}</style>\r\n") + "<script language=\"javascript\">\r\n" + "function SetPorgressBar(msg, pos)\r\n") + "{\r\n" + "document.getElementById('ProgressBar').style.width = pos + \"%\";\r\n") + "WriteText('Msg1',msg + \" 已完成\" + pos + \"%\");\r\n" + "}\r\n") + "function SetCompleted(msg)\r\n{\r\nif(msg==\"\")\r\nWriteText(\"Msg1\",\"完成。\");\r\n" + "else\r\nWriteText(\"Msg1\",msg);\r\n}\r\n") + "function WriteText(id, str)\r\n" + "{\r\n") + "var strTag = '<span style=\"font-family:Verdana, Arial, Helvetica;font-size=11.5px;color:#DD5800\">' + str + '</span>';\r\n" + "document.getElementById(id).innerHTML = strTag;\r\n") + "}\r\n" + "</script>\r\n</head>\r\n<body>\r\n") + "<div id=\"Msg1\"><span style=\"font-family:Verdana, Arial, Helvetica;font-size=11.5px;color:#DD5800\">" + msg + "</span></div>\r\n") + "<div id=\"ProgressBarSide\" align=\"left\" style=\"color:Silver;border-width:1px;border-style:Solid;\">\r\n") + "<div id=\"ProgressBar\" style=\"background-color:#008BCE; height:25px; width:0%;color:#fff;\"></div>\r\n" + "</div>\r\n</body>\r\n</html>\r\n";
            HttpContext.Current.Response.Write(s);
            HttpContext.Current.Response.Flush();
        }
    }
}

