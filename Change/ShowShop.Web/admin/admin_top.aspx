<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="admin_top.aspx.cs" Inherits="ShowShop.Web.admin.admin_top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>Admin_Top</title>
<link rel="stylesheet" href="style/mune.css" type="text/css" />
</head>
<style type="text/css" >
.admin_top0{ width:100%; height:50px; background:url(images/admin_top_bj.jpg) repeat-x}
.admin_top{ width:100%; height:50px; background:url(images/admin_top_bj.jpg) repeat-x}
.admin_top_logo {width:190px; padding:3px; float:left;}
.admin_top_menu {width:800px; float:right; overflow:hidden}

.admin_top02{ float:left; margin-top:2px; width:800px}
.admin_top02 ul { float:right; background:url(images/admin_top_char2.jpg) repeat-x; }
.admin_top02 li { float:left;  color:#000; height:29px; background:url(images/admin_top_char2.jpg) repeat-x  }
.admin_top02 li a { display:block; text-align:center; line-height:20px; font-size:14px; color:#000}
.admin_top02 li a:hover { display:block; text-align:center; line-height:20px; font-size:14px; color:red; }
</style>
<body>
<div class="admin_top0">
<div class="admin_top">
	<ul class="admin_top_logo"><img src="images/admin_top_logo.jpg" /></ul>
	<ul class="admin_top_menu">
		<ul class="admin_top02">
		  <ul>
			<li><img src="images/admin_top_char1.jpg" /></li>
			<li><a href="../default.aspx" target="_blank">【浏览网站】</a></li>
		<%--	<li><a href="http://www.yx-shop.cn/" target="_blank">【客户服务】</a></li>--%>
		  </ul>
		</ul>
	</ul>
</div>
</div>
</body>
</html>