<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ShowShop.Web.Admin.index"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>管理登陆-<%=WebName %></title>
    <meta name ="keywords" content="XYShop,电子商务,B/C,电子商城,商城,网店,易想,ChangeHope" />
    <link rel="stylesheet" href="style/index.css" type="text/css" media="all"  />
    <script type="text/javascript" src="../scripts/prototype.js"></script>
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <script type="text/javascript">
    function CheckForm()
    {
        if(!IsNull($("txtUserLoginName"),3,20))
        {
            alert("帐号不能为空");
            return false;
        }
        if(!CheckLength($("txtUserLoginPwd"),5))
        {
            alert("密码至少为五位");
            return false;
        }
        if(!CheckEqualsLeng($("txtCheckCode"),5))
        {
            alert("验证码为5位");
            return false;
        }
    }
    function FormLoad()
    {
        $("txtUserLoginName").focus();
    }
    </script>
</head>
<body onload="FormLoad()">
    <form id="form1" runat="server"  onsubmit="return CheckForm();">
    <table id="tbLogin" cellpadding="0" cellspacing="0">
	<tr>
		<td id="tdLeft" />
		<td id="tdMiddle">
			<table id="tbLoginForm"  cellpadding="0" cellspacing="0">
				<tr>
					<td id="tdTop" />
				</tr>
				<tr>
					<td id="tdMain">
					    <table cellspacing="0" cellpadding="0" id="tbLoginInfo">
						    <tr>
							    <td class="txtInfo">帐&nbsp;&nbsp;&nbsp;&nbsp;号：</td>
							    <td class="controlInfo"><asp:TextBox ID="txtUserLoginName" CssClass="userControl" runat="server"></asp:TextBox></td>
						    </tr>
						    <tr>
							    <td class="txtInfo">密&nbsp;&nbsp;&nbsp;&nbsp;码：</td>
							    <td class="controlInfo"><asp:TextBox ID="txtUserLoginPwd" CssClass="userControl" runat="server" TextMode="Password"  EnableViewState="false"></asp:TextBox></td>
						    </tr>
						    <tr>
							    <td class="txtInfo">验证码：</td>
							    <td class="controlInfo">
							        <table cellspacing="0" cellpadding="0">
							            <tr>
							                <td><asp:TextBox ID="txtCheckCode" CssClass="checkCode" runat="server"></asp:TextBox></td>
							                <td><img alt="点击刷新验证码" onclick="this.src='plugin/check_code.aspx?t='+Math.random();" src="plugin/check_code.aspx" class="pointer"/></td>
							            </tr>
							        </table>
							    </td>
						    </tr>
						    <tr>
							    <td colspan="2">
							        <asp:ImageButton runat="server" ID="btnLogin" ImageUrl="images/admin_index_login.jpg" onclick="Login_Click"  />&nbsp;&nbsp;&nbsp;&nbsp;
							        <img alt="重置" src="images/admin_index_reset.jpg" onclick="reset();" class="pointer"/>
							    </td>
						    </tr>
					    </table>
					</td>
				</tr>
			</table>
		</td>
		<td id="tdRight" />
	</tr>
</table>
    </form>
</body>
</html>