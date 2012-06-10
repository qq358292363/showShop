<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_index.aspx.cs" Inherits="ShowShop.Web.admin.admin_index" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Frameset//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-frameset.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link rel="stylesheet" href="style/mune.css" type="text/css" />
    <title>后台管理-<%=WebName %></title>
    <meta name ="keywords" content="XYShop,电子商务,B/C,电子商城,商城,网店,易想,ChangeHope" />
</head>
<frameset rows="50,*,5" cols="*" frameborder="no" border="0" framespacing="0">
  <frame src="admin_top.aspx" name="topFrame" frameborder="no" scrolling="No" noresize="noresize" id="topFrame" title="topFrame" />
  <frameset name="myFrame" cols="199,7,*" frameborder="no" border="0" framespacing="0">
    <frame src="admin_left.aspx" name="leftFrame" frameborder="no" scrolling="No" noresize="noresize" id="leftFrame" title="leftFrame" />
	<frame src="switchframe.html" name="midFrame" frameborder="no" scrolling="No" noresize="noresize" id="midFrame" title="midFrame" />
    <frameset rows="65,*" cols="*" frameborder="no" border="0" framespacing="0">
         <frame src="admin_main.aspx" name="mainFrame" frameborder="no" scrolling="No"  noresize="noresize" id="mainFrame" title="mainFrame" />
         <frame src="systeminfo/site_sysinfo.aspx" name="manFrame" scrolling="yes" frameborder="0" id="manFrame" title="manFrame" />
     </frameset>
  </frameset>
  <frame src="admin_bottom.htm" name="bottom" frameborder="no" scrolling="No" noresize="noresize" id="bottom" title="bottom" />
</frameset>
<noframes><body>
</body>
</noframes>
</html>