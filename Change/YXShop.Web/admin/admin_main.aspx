<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_main.aspx.cs" Inherits="ShowShop.Web.admin.admin_main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<link rel="stylesheet" href="style/mune.css" type="text/css" />
<title>����������</title>
</head>
<script  type="text/javascript" src="scripts/title.js"></script>
<body>
<div id="nav">
    <ul>
         <li id="man_nav_1"  onclick="list_sub_nav(id,'��Ʒ����')"  class="bg_image">��Ʒ����</li>
        <li id="man_nav_2"  onclick="list_sub_nav(id,'��������')"  class="bg_image">��������</li>
        <li id="man_nav_3"  onclick="list_sub_nav(id,'�û�����')"  class="bg_image">�û�����</li>
        <li id="man_nav_4"  onclick="list_sub_nav(id,'��ѶƵ��')"  class="bg_image">��ѶƵ��</li>
        <li id="man_nav_5"  onclick="list_sub_nav(id,'ϵͳ����')"  class="bg_image">ϵͳ����</li>
     
    </ul>
</div>
<div id="sub_info">&nbsp;&nbsp;<img src="images/listen.gif"  alt="tab"/>&nbsp;<span id="show_text"></span></div>
</body>
</html>

