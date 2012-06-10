<%@ Page Language="C#"  MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="user_setting.aspx.cs" Inherits="ShowShop.Web.admin.systeminfo.user_setting" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <script type="text/javascript" src="../scripts/calendar.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">
    用户参数配置
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">
    访问该网站的用户参数配置信息

    <asp:Button ID="Button2" runat="server" CssClass="inputbutton" onclick="btnSave_Click" Text="保存设置" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">

    <asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    </asp:Panel>
    
    <table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
	    <tr>
		    <td class="form_table_input_info">允许会员注册功能：
            </td>
		    <td>
                <asp:RadioButtonList ID="ckbAllowRegister" runat="server" 
                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1" Selected="True">是</asp:ListItem>
                    <asp:ListItem Value="0">否</asp:ListItem>
                    
                </asp:RadioButtonList>
                <asp:HiddenField ID="txtId" runat="server" />
            </td>
		    <td>
		        <div class="msgNormal">您的网站可以随时关闭新会员注册功能！</div>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">同一Email多次注册：</td>
		    <td>
                <asp:RadioButtonList ID="ckbSameEmailRegister" runat="server" 
                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1" Selected="True">允许</asp:ListItem>
                    <asp:ListItem Value="0">不允许</asp:ListItem>
                    
                </asp:RadioButtonList>
            </td>
		    <td><div class="msgNormal">您的网站是不是允许同一个Email地址可注册多个帐号</div></td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">是否需要管理员认证：</td>
		    <td>
                <asp:RadioButtonList ID="ckbAdminValidate" runat="server" 
                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1" Selected="True">是</asp:ListItem>
                    <asp:ListItem Value="0">否</asp:ListItem>
                    
                </asp:RadioButtonList>
            </td>
		    <td><div class="msgNormal">开启管理员认证后，则必须在管理员验证后该用户方可登陆，建议不采用该种方式！</div></td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">是否需要邮件验证：</td>
		    <td>
                <asp:RadioButtonList ID="ckbEmailValidate" runat="server" 
                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1" Selected="True">是</asp:ListItem>
                    <asp:ListItem Value="0">否</asp:ListItem>
                    
                </asp:RadioButtonList>
            </td>
		    <td><div class="msgNormal">启用邮件验证后，则用户需要到自己的邮箱中收取激活邮件方可成为本站会员，不建议采用</div></td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">邮件发送激活内容：</td>
		    <td>
                <asp:TextBox ID="txtEmailValidateContent" runat="server" TextMode="MultiLine"></asp:TextBox>
            </td>
		    <td>
		        <asp:Panel id="txtEmailValidateContentTip" runat="server"></asp:Panel></td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">注册后是否赠送点券：</td>
		    <td>
                <asp:RadioButtonList ID="ckbHandselCoupons" runat="server" 
                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1" Selected="True">是</asp:ListItem>
                    <asp:ListItem Value="0">否</asp:ListItem>
                    
                </asp:RadioButtonList>
            </td>
		    <td><div class="msgNormal">新用户注册后是否赠送给其相应的点券</div></td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">赠送点券数量：</td>
		    <td>
                <asp:TextBox ID="txtHandselCouponsNumber" CssClass="short_input" runat="server"></asp:TextBox>
                    </td>
		    <td><asp:Panel id="txtHandselCouponsNumberTip" runat="server"></asp:Panel></td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">赠送起始时间：</td>
		    <td><asp:TextBox ID="txtHandselCouponsBeginTime" CssClass="date_input" runat="server"></asp:TextBox> 至 <asp:TextBox ID="txtHandselCouponsEndTime" CssClass="date_input" runat="server"></asp:TextBox></td>
		    <td><asp:Panel id="txtHandselCouponsBeginTimeTip" runat="server"></asp:Panel><asp:Panel id="txtHandselCouponsEndTimeTip" runat="server"></asp:Panel></td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">新会员赠送积分：</td>
		    <td dir="ltr" valign="middle">
                <asp:TextBox ID="txtHandselPoint"  CssClass="long_input" runat="server"></asp:TextBox>
            </td>
		    <td><asp:Panel id="txtHandselPointTip" runat="server"></asp:Panel></td>
	    </tr>
	    
	    <tr>
		    <td class="form_table_input_info">默认会员组：</td>
		    <td>
                <asp:DropDownList ID="ddlUserDefaultGroup" EnableViewState="true" runat="server">
                </asp:DropDownList>
                    </td>
		    <td><div class="msgNormal">新会员注册后，自动进入默认会员组。</div></td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">启用回答问题验证：</td>
		    <td>
                <asp:RadioButtonList ID="ckbAnswerValidate" runat="server" 
                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1" Selected="True">启用</asp:ListItem>
                    <asp:ListItem Value="0">不启用</asp:ListItem>
                    
                </asp:RadioButtonList>
            </td>
		    <td><div class="msgNormal">新会员注册时，是否需要回答相关问题后才能进行注册。</div></td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">设置问题一：</td>
		    <td>
                <asp:TextBox ID="txtQuestionFirst"  CssClass="long_input" runat="server"></asp:TextBox>
            </td>
		    <td><div class="msgNormal">如果启用了回答问题验证模式，请填写问题一。</div></td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">问题一回答：</td>
		    <td>
                <asp:TextBox ID="txtAnswerFirst"  CssClass="long_input" runat="server"></asp:TextBox>
            </td>
		    <td><div class="msgNormal">针对问题一的回答。用户只有回答正确该答案后才能进行注册</div></td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">设置问题二：</td>
		    <td>
                <asp:TextBox ID="txtQuestionSecond"  CssClass="long_input" runat="server"></asp:TextBox>
            </td>
		    <td><div class="msgNormal">如果启用了回答问题验证模式，请填写问题二。</div></td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">问题二回答：</td>
		    <td>
                <asp:TextBox ID="txtAnswerSecond"  CssClass="long_input" runat="server"></asp:TextBox>
            </td>
		    <td><div class="msgNormal">针对问题二的回答。用户只有回答正确该答案后才能进行注册。</div></td>
	    </tr>
	    
	    <tr>
		    <td class="form_table_input_info">找回密码方式：</td>
		    <td>
                <asp:RadioButtonList ID="ckbGetPasswordMethod" runat="server" 
                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1" Selected="True">回答问题</asp:ListItem>
                    <asp:ListItem Value="0">发送到邮箱</asp:ListItem>
                    
                </asp:RadioButtonList>
            </td>
		    <td><div class="msgNormal">新会员注册时，是否需要回答相关问题后才能进行注册。</div></td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">禁止注册用户名：</td>
		    <td>
                <asp:TextBox ID="txtForbidUserId"  CssClass="long_input" runat="server"></asp:TextBox>
                    </td>
		    <td><div class="msgNormal">禁止使用的用户名，请用(,)分开，例如：张三,李四,王二</div></td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">注册的必填：</td>
		    <td style="color:Blue">
                <asp:CheckBoxList ID="ckbRegisterRequired" RepeatDirection="Horizontal" 
                    runat="server" RepeatColumns="3" RepeatLayout="Flow">
                </asp:CheckBoxList>
            </td>
		    <td><div  class="msgNormal">用户注册时，必须填写的信息</div></td>
	    </tr>
	    
	    <tr>
		    <td class="form_table_input_info">注册的选填项：</td>
		    <td style="color:Green">
                <asp:CheckBoxList ID="ckbRegisterRequiredOptional" RepeatDirection="Horizontal" 
                    runat="server" RepeatColumns="3" RepeatLayout="Flow">
                </asp:CheckBoxList>
            </td>
		    <td><div  class="msgNormal">用户注册时，选择填写的信息</div></td>
	    </tr>
	    
	    
	    
	    <tr>
		    <td class="form_table_input_info">登录是否启用验证：</td>
		    <td>
                <asp:RadioButtonList ID="ckbLoginIsNeedCheckCode" runat="server" 
                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1" Selected="True">是</asp:ListItem>
                    <asp:ListItem Value="0">否</asp:ListItem>
                    
                </asp:RadioButtonList>
            </td>
		    <td><div class="msgNormal">用户在登陆时，是否需要选择填写验证码</div></td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">会员登陆赠送积分：</td>
		    <td>
                每登陆一次赠送 <asp:TextBox ID="txtLoginPoint"  CssClass="short_input" runat="server"></asp:TextBox> 点积分
                    </td>
		    <td><asp:Panel id="txtLoginPointTip" runat="server"></asp:Panel></td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">多人使用同一帐号：</td>
		    <td>
                <asp:RadioButtonList ID="ckbAllowOtherLogin" runat="server" 
                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                    <asp:ListItem Value="1" Selected="True">是</asp:ListItem>
                    <asp:ListItem Value="0">否</asp:ListItem>
                    
                </asp:RadioButtonList>
            </td>
		    <td><div class="msgNormal">一个帐号能否同时在不同电脑上登陆？</div></td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">资金与点券兑换比：</td>
		    <td>
                每1元人民币可兑换 <asp:TextBox ID="txtMoneyToCoupons"  CssClass="short_input" runat="server"></asp:TextBox> 点券
                    </td>
		    <td>
                <asp:Panel ID="txtMoneyToCouponsTip" runat="server"></asp:Panel>
            </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">资金与有效期兑换比：</td>
		    <td>
                每1元人民币可兑换 <asp:TextBox ID="txtMoneyToDate"  CssClass="short_input" runat="server"></asp:TextBox> 天有效期
            </td>
		    <td><asp:Panel ID="txtMoneyToDateTip" runat="server"></asp:Panel></td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">积分与点券兑换比：</td>
		    <td>
                每 <asp:TextBox ID="txtPointToCoupons"  CssClass="short_input" runat="server"></asp:TextBox> 点积分可兑换1点点券
            </td>
		    <td><asp:Panel ID="txtPointToCouponsTip" runat="server"></asp:Panel></td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">积分与有效期兑换比：</td>
		    <td>
                每 <asp:TextBox ID="txtPointToDate"  CssClass="short_input" runat="server"></asp:TextBox> 点积分可兑换1天有效期
            </td>
		    <td><asp:Panel ID="txtPointToDateTip" runat="server"></asp:Panel></td>
	    </tr>
	    
	    <tr>
		    <td class="form_table_input_info">点券名称：</td>
		    <td>
                <asp:TextBox ID="txtCouponsName"  runat="server"></asp:TextBox>
            </td>
		    <td><asp:Panel ID="txtCouponsNameTip" runat="server"></asp:Panel></td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">点券单位：</td>
		    <td>
                <asp:TextBox ID="txtCouponsUnits"   runat="server"></asp:TextBox>
            </td>
		    <td><asp:Panel ID="txtCouponsUnitsTip" runat="server"></asp:Panel></td>
	    </tr>
	  
    </table>
</asp:Content>
<asp:Content ContentPlaceHolderID="pagebottom" runat="server" ID="ContentBottom">
    <asp:Button ID="Button1" runat="server" CssClass="inputbutton" onclick="btnSave_Click" Text="保存设置" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
</asp:Content>