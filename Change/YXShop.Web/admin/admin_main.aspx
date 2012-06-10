<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_main.aspx.cs" Inherits="ShowShop.Web.admin.admin_main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<link rel="stylesheet" href="style/mune.css" type="text/css" />
<title>管理导航区域</title>
</head>
<script  type="text/javascript" src="scripts/title.js"></script>
<body>
<div id="nav">
    <ul>
         <li id="man_nav_1"  onclick="list_sub_nav(id,'商品管理')"  class="bg_image">商品管理</li>
        <li id="man_nav_2"  onclick="list_sub_nav(id,'订单管理')"  class="bg_image">订单管理</li>
        <li id="man_nav_3"  onclick="list_sub_nav(id,'用户管理')"  class="bg_image">用户管理</li>
        <li id="man_nav_4"  onclick="list_sub_nav(id,'资讯频道')"  class="bg_image">资讯频道</li>
        <li id="man_nav_5"  onclick="list_sub_nav(id,'系统设置')"  class="bg_image">系统设置</li>
     
    </ul>
</div>
<div id="sub_info">&nbsp;&nbsp;<img src="images/listen.gif"  alt="tab"/>&nbsp;<span id="show_text"></span></div>
</body>
</html>

