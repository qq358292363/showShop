<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_left.aspx.cs" Inherits="ShowShop.Web.admin.admin_left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<link rel="stylesheet" href="style/mune.css" type="text/css" />
<title>��ർ����</title>
<script src="../scripts/prototype.js" type="text/javascript"></script>
<script type="text/javascript" src="scripts/mune.js"></script>
</head>
<body onload="initinav('��Ʒ����')">
<form id="form1" runat="server">
<div id="left_content">
     <div id="user_info">
        ��ӭ����
        <strong><asp:Literal ID="ltlAdminUserName" runat="server"></asp:Literal></strong>
        <br />[<a href="systeminfo/site_sysinfo.aspx" target="manFrame">�ύBUG</a>��<a href="admin_logout.aspx" target="_parent">�˳�</a>]</div>
	 <div id="main_nav">
	     <div id="left_main_nav"></div>
		 <div id="right_main_nav"></div>
	 </div>
</div>
</form>
</body>
</html>
