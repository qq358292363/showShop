<%@ Page Language="C#"  MasterPageFile="~/admin/admin_page.master" enableEventValidation="false" AutoEventWireup="true" CodeBehind="member_edit.aspx.cs" Inherits="ShowShop.Web.admin.member.member_edit" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <link rel="stylesheet" href="../style/toolbar.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <script type="text/javascript" src="../scripts/public.js"></script>
    <script type="text/javascript" src="../scripts/calendar.js"></script>
<script type="text/javascript">
        function GetCity(controlid,code,value)
        {
            if (code.length>0){
             var control=$(controlid);
             var url="../plugin/getcity.aspx?parentid="+code; 
             new Ajax.Request(
                url,
                {
                    method: 'get',
                    encoding: 'GBK',
                    onSuccess: function(transport) 
                    {
                        var contentjson=eval("("+transport.responseText+")"); 
                        control.options.length=0;
                        control.options.add(new Option("请选择","")); 
                        for(var i=0;i<contentjson.city.length;i++)
                        {
                            
                            control.options.add(new Option(contentjson.city[i].content,contentjson.city[i].code)); 
                            if(value==contentjson.city[i].code)
                            {
                                control.options[i+1].selected=true;
                            }
                        }
                    }
                }
            );
           }
        }
        window.document.body.onload=function(){
            InitForm();
            ShowDiv(0,1); 
            <asp:Literal id="lblScript" runat="server"></asp:Literal>
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">会员信息
    <asp:Button ID="button1" runat="server" CssClass="inputbutton" onclick="btnSave_Click" Text="保  存" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
    <asp:HyperLink ID="HyperLink1" runat="server"  CssClass="inputbutton" NavigateUrl="member_list.aspx" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返回列表</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">
        添加会员信息
        <asp:Literal ID="ltlMemberView" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
<table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td id="TabTitle0" class="titlemouseover" onclick="ShowTabs(0,4)">基本信息</td>
            <td id="TabTitle1" class="tabtitle" onclick="ShowTabs(1,4)">个人信息</td>
            <td id="TabTitle2" class="tabtitle" onclick="ShowTabs(2,4)">联系方式</td>
            <td id="TabTitle3" class="tabtitle" onclick="ShowTabs(3,4)">公司信息</td>
        </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td colspan="9" style="border: 1px solid #bac9c6;">
<asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    </asp:Panel>
<div id="tab0" class="tabs">
<asp:HiddenField ID="txtUId" runat="server" />
    <table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
	    <tr>
		    <td class="form_table_input_info">会员帐号：</td>
		    <td>
                <asp:TextBox ID="txtUserId" CssClass="long_input" runat="server"></asp:TextBox>
            </td>
		    <td>
		        <asp:Panel id="txtUserIdTip" runat="server"></asp:Panel>
		    </td>
	    </tr>
	    
	    <tr>
		    <td class="form_table_input_info">会员密码：</td>
		    <td>
                <asp:TextBox ID="txtPasswordRe"  CssClass="long_input" runat="server" TextMode="Password"></asp:TextBox>
            </td>
		    <td>
		        <asp:Panel id="txtPasswordReTip" runat="server"></asp:Panel><div class="msgNormal"><asp:Literal ID="litPassword" runat="server" Text=""></asp:Literal></div>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">密码确认：</td>
		    <td>
                <asp:TextBox ID="txtPassword" CssClass="long_input"   runat="server" TextMode="Password"></asp:TextBox>
            </td>
		    <td>
		        <asp:Panel id="txtPasswordTip" runat="server"></asp:Panel>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">电子邮件：</td>
		    <td>
                <asp:TextBox ID="txtEmail" CssClass="long_input" runat="server"></asp:TextBox> 
            </td>
		    <td>
		        <asp:Panel id="txtEmailTip" runat="server"></asp:Panel>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">用户类别/会员等级：</td>
		    <td>
                <asp:DropDownList ID="ddlUserType" runat="server">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlUserGroup" runat="server">
                </asp:DropDownList>
		    </td>
		    <td>
		        <div class="msgNormal">商家用户可以在本站开通网店销售自己的产品，普通用户只能购买商品不能销售物品</div>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">会员状态：</td>
		    <td>
                
                <asp:CheckBox ID="ckbState" runat="server" Text="冻结该帐号" />
                
            </td>
		    <td>
		        <div class="msgNormal">是否冻结该帐号，冻结该帐号后，该帐号人员将无法登陆系统，但是不会删除其任何信息。</div>
		    </td>
	    </tr>
	    
	    <tr>
		    <td class="form_table_input_info">会员签名：</td>
		    <td>
                <asp:TextBox ID="txtSigned" TextMode="MultiLine" runat="server"></asp:TextBox> 
            </td>
		    <td>
		        <asp:Panel id="txtSignedTip" runat="server"></asp:Panel>
		    </td>
	    </tr>
	    
	    <tr>
		    <td class="form_table_input_info">找回密码问题：</td>
		    <td>
                <asp:TextBox ID="txtQuestion" CssClass="long_input" runat="server"></asp:TextBox> 
            </td>
		    <td>
		        <asp:Panel id="txtQuestionTip" runat="server"></asp:Panel>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">找回密码答案：</td>
		    <td>
                <asp:TextBox ID="txtAnswer" CssClass="long_input" runat="server"></asp:TextBox> 
            </td>
		    <td>
		        <asp:Panel id="txtAnswerTip" runat="server"></asp:Panel>
		    </td>
	    </tr>
	    
    </table>
</div>
<div id="tab1" class="tabs">
    <table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
        <tr>
		    <td class="form_table_input_info">信息是否公开：</td>
		    <td>
                <asp:CheckBox ID="ckbPrivacySettings" runat="server" />公开
            </td>
		    <td>
		        <div class="msgNormal">个人隐私信息是否公开</div>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">真实姓名：</td>
		    <td>
                <asp:TextBox ID="txtTrueName" CssClass="long_input" runat="server"></asp:TextBox>
            </td>
		    <td>
		        <div class="msgNormal">会员的真实姓名</div>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">称谓：</td>
		    <td>
                <asp:TextBox ID="txtTitle" CssClass="long_input" runat="server"></asp:TextBox>
            </td>
		    <td>
		        <div class="msgNormal">该会员的称谓，用于网店用户或者网站运营商对该会员的称呼，比如:李先生，王女士</div>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">籍贯：</td>
		    <td>
                <asp:TextBox ID="txtOrigin"  CssClass="long_input" runat="server"></asp:TextBox>
            </td>
		    <td>
		        <div class="msgNormal">会员的籍贯</div>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">出生日期：</td>
		    <td>
                <asp:TextBox ID="txtBirthday" CssClass="date_input"   runat="server"></asp:TextBox>
            </td>
		    <td>
		        <div class="msgNormal">出生日期：格式yyyy-MM-dd</div>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">性别：</td>
		    <td>
                <asp:DropDownList ID="ddlSex" runat="server"></asp:DropDownList>
            </td>
		    <td>
		        <div class="msgNormal">性别</div>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">民族：</td>
		    <td>
                <asp:TextBox ID="txtNation" CssClass="long_input" runat="server"></asp:TextBox> 
		    </td>
		    <td>
		        <div class="msgNormal">民族，请尽量按照标准来</div>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">证件类型/号码：</td>
		    <td>
                <asp:DropDownList ID="ddlPapersType" runat="server"></asp:DropDownList>
                <asp:TextBox ID="txtPapersNumber"  runat="server"></asp:TextBox> 
            </td>
		    <td>
		        <div class="msgNormal">证件的类型和号码</div>
		    </td>
	    </tr>
	    
	    
	    <tr>
		    <td class="form_table_input_info">婚姻状况：</td>
		    <td>
                <asp:DropDownList ID="ddlMarriage" runat="server"></asp:DropDownList>
            </td>
		    <td>
		        <div class="msgNormal">婚姻状况</div>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">学历：</td>
		    <td>
                <asp:DropDownList ID="ddlEducation" runat="server"></asp:DropDownList>
            </td>
		    <td>
		        <div class="msgNormal">会员的学历信息</div>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">毕业学校：</td>
		    <td>
                <asp:TextBox ID="txtGraduateSchool" CssClass="long_input" runat="server"></asp:TextBox>
            </td>
		    <td>
		        <div class="msgNormal">毕业学校。如果有多个学校用逗号分开</div>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">生活爱好：</td>
		    <td>
                <asp:TextBox ID="txtLifeHobbies" CssClass="long_input" runat="server"></asp:TextBox>
            </td>
		    <td>
		        <div class="msgNormal">生活爱好</div>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">文化爱好：</td>
		    <td>
                <asp:TextBox ID="txtCultureHobbies" CssClass="long_input" runat="server"></asp:TextBox>
            </td>
		    <td>
		        <div class="msgNormal">文化爱好,多个用逗号分开</div>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">娱乐休闲爱好：</td>
		    <td>
                <asp:TextBox ID="txtEntertainment" CssClass="long_input" runat="server"></asp:TextBox>
            </td>
		    <td>
		        <div class="msgNormal">娱乐休闲爱好,多个用逗号分开</div>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">体育爱好：</td>
		    <td>
                <asp:TextBox ID="txtSportsHobbies" CssClass="long_input" runat="server"></asp:TextBox>
            </td>
		    <td>
		        <div class="msgNormal">体育爱好,多个用逗号分开</div>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">其他爱好：</td>
		    <td>
                <asp:TextBox ID="txtOtherHobbies" CssClass="long_input" runat="server"></asp:TextBox>
            </td>
		    <td>
		        <div class="msgNormal">其他爱好,多个用逗号分开</div>
		    </td>
	    </tr>
    </table>
</div>
<div id="tab2" class="tabs">
<table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
	    <tr>
		    <td class="form_table_input_info">省市区：</td>
		    <td>
                <asp:DropDownList ID="ddlProvince" runat="server">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlCity" runat="server">
                </asp:DropDownList>
                <asp:DropDownList ID="ddlBorough" runat="server">
                </asp:DropDownList>
            </td>
		    <td>
		        <div class="msgNormal">该会员所在的行政区划</div>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">详细地址：</td>
		    <td>
                <asp:TextBox ID="txtAddress" CssClass="long_input" runat="server"></asp:TextBox>
            </td>
		    <td>
		        <div class="msgNormal">该会员所在地的详细地址，详细联系地址</div>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">邮政编码：</td>
		    <td>
                <asp:TextBox ID="txtZip" CssClass="date_input" runat="server"></asp:TextBox>
            </td>
		    <td>
		        <div class="msgNormal">邮政编码</div>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">办公电话：</td>
		    <td>
                <asp:TextBox ID="txtOfficePhone"  CssClass="long_input" runat="server"></asp:TextBox>
            </td>
		    <td>
		        <div class="msgNormal">该会员的办公电话</div>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">家庭电话：</td>
		    <td>
                <asp:TextBox ID="txtHomePhone"  CssClass="long_input" runat="server"></asp:TextBox>
            </td>
		    <td>
		        <div class="msgNormal">家庭电话</div>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">手机：</td>
		    <td>
                <asp:TextBox ID="txtMobilePhone"  CssClass="long_input" runat="server"></asp:TextBox>
            </td>
		    <td>
		        <div class="msgNormal">手机</div>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">小灵通：</td>
		    <td>
                <asp:TextBox ID="txtHandPhone" CssClass="long_input" runat="server"></asp:TextBox> 
		    </td>
		    <td>
		        <div class="msgNormal">小灵通</div>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">传真：</td>
		    <td>
                <asp:TextBox ID="txtFax"  CssClass="long_input" runat="server"></asp:TextBox> 
            </td>
		    <td>
		        <div class="msgNormal">传真</div>
		    </td>
	    </tr>
	    
	    
	    <tr>
		    <td class="form_table_input_info">个人网站：</td>
		    <td>
                <asp:TextBox ID="txtPersonWebSite" CssClass="long_input" runat="server"></asp:TextBox>
            </td>
		    <td>
		        <div class="msgNormal">个人网站</div>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">QQ：</td>
		    <td>
                <asp:TextBox ID="txtQQ"  CssClass="long_input" runat="server"></asp:TextBox>
            </td>
		    <td>
		        <div class="msgNormal">QQ</div>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">MSN：</td>
		    <td>
                <asp:TextBox ID="txtMSN" CssClass="long_input" runat="server"></asp:TextBox>
            </td>
		    <td>
		        <div class="msgNormal">MSN</div>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">ICQ：</td>
		    <td>
                <asp:TextBox ID="txtICQ" CssClass="long_input" runat="server"></asp:TextBox>
            </td>
		    <td>
		        <div class="msgNormal">ICQ</div>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">UC：</td>
		    <td>
                <asp:TextBox ID="txtUC" CssClass="long_input" runat="server"></asp:TextBox>
            </td>
		    <td>
		        <div class="msgNormal">UC</div>
		    </td>
	    </tr>
    </table>
</div>
<div id="tab3" class="tabs">

<table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
	    <tr>
		    <td class="form_table_input_info">公司名称：</td>
		    <td>
                <asp:TextBox ID="txtIncName" CssClass="long_input" runat="server"></asp:TextBox>
            </td>
		    <td>
		        <div class="msgNormal">公司名称</div>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">部门：</td>
		    <td>
                <asp:TextBox ID="txtDepartment" CssClass="long_input" runat="server"></asp:TextBox>
            </td>
		    <td>
		        <div class="msgNormal">公司所在部门</div>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">职位：</td>
		    <td>
                <asp:TextBox ID="txtPositions" CssClass="long_input" runat="server"></asp:TextBox>
            </td>
		    <td>
		        <div class="msgNormal">该会员在公司所任职位</div>
		    </td>
	    </tr>
	    <tr>
		    <td class="form_table_input_info">职务：</td>
		    <td>
                <asp:TextBox ID="txtWorkRange" CssClass="long_input" runat="server"></asp:TextBox>
            </td>
		    <td>
		        <div class="msgNormal">该会员在该公司职务</div>
		    </td>
	    </tr>
	     <tr>
		    <td class="form_table_input_info">公司详细地址：</td>
		    <td>
                <asp:TextBox ID="txtIncAddress" CssClass="long_input" runat="server"></asp:TextBox>
            </td>
		    <td>
		        <div class="msgNormal">公司的详细地址</div>
		    </td>
	    </tr>
	     <tr>
		    <td class="form_table_input_info">月收入：</td>
		    <td>
                <asp:TextBox ID="txtMonthlyInCome"  runat="server"></asp:TextBox> 元人民币
            </td>
		    <td>
		        <div class="msgNormal">该会员月收入</div>
		    </td>
	    </tr>
</table>
</div>
</td>
</tr>
</table>
</asp:Content>
<asp:Content ContentPlaceHolderID="pagebottom" runat="server" ID="ContentBottom">
    <asp:Button ID="button2" runat="server" CssClass="inputbutton" onclick="btnSave_Click" Text="保  存" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
    <asp:HyperLink ID="HyperLink2" runat="server"  CssClass="inputbutton" NavigateUrl="member_list.aspx" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返回列表</asp:HyperLink>
</asp:Content>