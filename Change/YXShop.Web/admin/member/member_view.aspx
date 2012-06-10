<%@ Page Language="C#" EnableViewState="false" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="member_view.aspx.cs" Inherits="ShowShop.Web.admin.member.member_view" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <link rel="stylesheet" href="../style/toolbar.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <script type="text/javascript" src="../scripts/public.js"></script>
    <script type="text/javascript" defer="defer">
        function ShowMenu(control)
        {
            var y=control.offsetTop; 
            var x=control.offsetLeft; 
             
            objectC=control;
            while(control=control.offsetParent)
            {
                y+=control.offsetTop; 
                x+=control.offsetLeft;
            } 
            $("munelist").style.left=x;
            $("munelist").style.top=y+20;
            $("munelist").style.display="block";
        }
        function HiddenMune(control)
        {
            control.style.display="none";
        }
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">用户<asp:Literal ID="ltlUser" runat="server"></asp:Literal>信息浏览
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server"> 
        <a href="#" id="mune" onmousemove="ShowMenu(this)"><font color='Red'>&#9758;</font> 操 作 </a>  &nbsp;&#1769;&nbsp;
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
    <div id="munelist" class="toolmune" onclick="HiddenMune(this)">
        <div class="toolmunel"></div>
        <ul>
            <li><img src="../images/mune.gif" alt=""/>&nbsp;<a href="javascript:window.history.back();">返回会员列表</a></li>
            <asp:Literal ID="linklist" runat="server"></asp:Literal>
        </ul>
    </div>
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td id="TabTitle0" class="titlemouseover" onclick="ShowTabs(0,9)">基本信息</td>
            <td id="TabTitle1" class="tabtitle" onclick="ShowTabs(1,9)">个人信息</td>
            <td id="TabTitle2" class="tabtitle" onclick="ShowTabs(2,9)">联系方式</td>
            <td id="TabTitle3" class="tabtitle" onclick="ShowTabs(3,9)">公司信息</td>
            <td id="TabTitle4" class="tabtitle" onclick="ShowTabs(4,9)">银行资金明细</td>
            <td id="TabTitle5" class="tabtitle" onclick="ShowTabs(5,9)">点券明细</td>
            <td id="TabTitle6" class="tabtitle" onclick="ShowTabs(6,9)">有效期明细</td>
            <td id="TabTitle7" class="tabtitle" onclick="ShowTabs(7,9)">积分信息</td>
            <td id="TabTitle8" class="tabtitle" onclick="ShowTabs(8,9)">收货信息</td>
        </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td colspan="9" style="border: 1px solid #bac9c6;">
    <!--用户基本信息-->
    <div id="tab0" class="tabs">
    <table width="100%"  cellspacing="0" cellpadding="0" border="1" bordercolorlight="#DDDDDD" bordercolordark="#FFFFFF">
                    <caption>基本信息</caption>
                    <tr>
                        <td class="form_text_row">会员账号：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblUserId" runat="server"></asp:Literal>&nbsp;</td>
                        <td class="form_text_row">E-mail：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblEmail" runat="server"></asp:Literal>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="form_text_row">用户状态：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblState" runat="server"></asp:Literal>&nbsp;</td>
                        <td class="form_text_row">会员等级：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblUserGroup" runat="server"></asp:Literal>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="form_text_row"> 会员类别：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblUserType" runat="server"></asp:Literal>&nbsp;</td>
                        <td class="form_text_row">有效期限：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblPeriodOfValidity" runat="server"></asp:Literal>&nbsp;</td>
                    </tr>
        			<tr>
                        <td class="form_text_row">可用点券：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblCoupons" runat="server"></asp:Literal>&nbsp;</td>
                        <td class="form_text_row">可用积分：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblPoints" runat="server"></asp:Literal>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="form_text_row">资金余额：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblCapital" runat="server"></asp:Literal>&nbsp;</td>
                        <td class="form_text_row">消费的金额：</td>
                        <td class="form_ctrl_row">暂不统计</td>
                    </tr>
                    <tr>
                        <td class="form_text_row">注册日期：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblRegisterDate" runat="server"></asp:Literal>&nbsp;</td>
                        <td class="form_text_row">注册地址：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblRegisterIP" runat="server"></asp:Literal>&nbsp;</td>
                    </tr>
                     <tr>
                        <td class="form_text_row">最后登陆时间：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblLastLoginDate" runat="server"></asp:Literal>&nbsp;</td>
                        <td class="form_text_row">最后登陆地址：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblLastLoginIP" runat="server"></asp:Literal>&nbsp;</td>
                    </tr>
                    
			         <tr>
			             <td width="15%"></td>
			             <td width="35%"></td>
			             <td width="15%"></td>
			             <td width="35%"></td>
			         </tr>
		         </table>
    </div>
    <!--个人信息-->
    <div id="tab1" class="tabs">
        <table width="100%"  cellspacing="0" cellpadding="0" border="1" bordercolorlight="#DDDDDD" bordercolordark="#FFFFFF">
                    <caption>个人信息</caption>
                    <tr>
                        <td class="form_text_row">真实姓名（籍贯）：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblTrueName" runat="server"></asp:Literal>&nbsp;</td>
                        <td class="form_text_row">称谓：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblTitle" runat="server"></asp:Literal>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="form_text_row">出生日期：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblBirthday" runat="server"></asp:Literal>&nbsp;</td>
                        <td class="form_text_row">性别：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblSex" runat="server"></asp:Literal>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="form_text_row">证件类型：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblPapersType" runat="server"></asp:Literal>&nbsp;</td>
                        <td class="form_text_row">证件号码：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblPapersNumber" runat="server"></asp:Literal>&nbsp;</td>
                    </tr>
        			<tr>
                        <td class="form_text_row">民族：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblNation" runat="server"></asp:Literal>&nbsp;</td>
                        <td class="form_text_row">婚姻状况：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblMarriage" runat="server"></asp:Literal>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="form_text_row">学历：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblEducation" runat="server"></asp:Literal>&nbsp;</td>
                        <td class="form_text_row">毕业学校：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblGraduateSchool" runat="server"></asp:Literal>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="form_text_row">生活爱好：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblLifeHobbies" runat="server"></asp:Literal>&nbsp;</td>
                        <td class="form_text_row">文化爱好：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblCultureHobbies" runat="server"></asp:Literal>&nbsp;</td>
                    </tr>
                     <tr>
                        <td class="form_text_row">娱乐休闲爱好：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblEntertainment" runat="server"></asp:Literal>&nbsp;</td>
                        <td class="form_text_row">体育爱好：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblSportsHobbies" runat="server"></asp:Literal>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="form_text_row">其他爱好：</td>
                        <td class="form_ctrl_row" colspan="3"><asp:Literal ID="lblOtherHobbies" runat="server"></asp:Literal>&nbsp;</td>
                        
                    </tr>
			         <tr>
			             <td width="15%"></td>
			             <td width="35%"></td>
			             <td width="15%"></td>
			             <td width="35%"></td>
			         </tr>
		         </table>
    
    </div>
    
    <div id="tab2" class="tabs">
        <table width="100%"  cellspacing="0" cellpadding="0" border="1" bordercolorlight="#DDDDDD" bordercolordark="#FFFFFF">
                    <caption>联系方式</caption>
                    <tr>
                        <td class="form_text_row">省/市/区：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblProvince" runat="server"></asp:Literal>&nbsp;</td>
                        <td class="form_text_row">邮政编码：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblZip" runat="server"></asp:Literal>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="form_text_row">联系地址：</td>
                        <td class="form_ctrl_row" colspan="3"><asp:Literal ID="lblAddress" runat="server"></asp:Literal>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="form_text_row">办公电话：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblOfficePhone" runat="server"></asp:Literal>&nbsp;</td>
                        <td class="form_text_row">住宅电话：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblHomePhone" runat="server"></asp:Literal>&nbsp;</td>
                    </tr>
        			<tr>
                        <td class="form_text_row">移动电话：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblMobilePhone" runat="server"></asp:Literal>&nbsp;</td>
                        <td class="form_text_row">传真号码：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblFax" runat="server"></asp:Literal>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="form_text_row">小灵通：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblHandPhone" runat="server"></asp:Literal>&nbsp;</td>
                        <td class="form_text_row">个人网站：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblPersonWebSite" runat="server"></asp:Literal>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="form_text_row">QQ：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblQQ" runat="server"></asp:Literal>&nbsp;</td>
                        <td class="form_text_row">MSN：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblMSN" runat="server"></asp:Literal>&nbsp;</td>
                    </tr>
                     <tr>
                        <td class="form_text_row">ICQ：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblICQ" runat="server"></asp:Literal>&nbsp;</td>
                        <td class="form_text_row">UC：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblUC" runat="server"></asp:Literal>&nbsp;</td>
                    </tr>
			         <tr>
			             <td width="15%"></td>
			             <td width="35%"></td>
			             <td width="15%"></td>
			             <td width="35%"></td>
			         </tr>
		         </table>
    
    </div>
    
    
    <div id="tab3" class="tabs">
        <table width="100%"  cellspacing="0" cellpadding="0" border="1" bordercolorlight="#DDDDDD" bordercolordark="#FFFFFF">
                    <caption>工作信息</caption>
                    <tr>
                        <td class="form_text_row">所在公司：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblIncName" runat="server"></asp:Literal>&nbsp;</td>
                        <td class="form_text_row">所属部门：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblDepartment" runat="server"></asp:Literal>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="form_text_row">职位：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblPositions" runat="server"></asp:Literal>&nbsp;</td>
                        <td class="form_text_row">负责业务：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblWorkRange" runat="server"></asp:Literal>&nbsp;</td>
                    </tr>
                    
                    <tr>
                        <td class="form_text_row">单位地址：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblIncAddress" runat="server"></asp:Literal>&nbsp;</td>
                        <td class="form_text_row">月收入：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblMonthlyInCome" runat="server"></asp:Literal>&nbsp;</td>
                    </tr>
			         <tr>
			             <td width="15%"></td>
			             <td width="35%"></td>
			             <td width="15%"></td>
			             <td width="35%"></td>
			         </tr>
		         </table>
    
    </div>
    <!--有效期-->
    <div id="tab4" class="tabs">
      <asp:Literal ID="litData" runat="server"></asp:Literal>
    </div>
    <!--点卷-->
    <div id="tab5" class="tabs">
      <asp:Literal ID="litCoupon" runat="server"></asp:Literal>
    </div>
    <!--资金-->
    <div id="tab6" class="tabs">
      <asp:Literal ID="litCapital" runat="server"></asp:Literal>
    </div>
    <!--积分-->
    <div id="tab7" class="tabs">
      <asp:Literal ID="LitIntegral" runat="server"></asp:Literal>
    </div>
    
    
    
    <!--收货信息-->
    <div id="tab8" class="tabs">
    <table width="100%"  cellspacing="0" cellpadding="0" border="1" bordercolorlight="#DDDDDD" bordercolordark="#FFFFFF">
                    <caption>收货信息</caption>
                    <tr>
                        <td class="form_text_row">收货人姓名：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblName" runat="server"></asp:Literal>&nbsp;</td>
                        <td class="form_text_row">电子邮件地址：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblEmails" runat="server"></asp:Literal>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="form_text_row">详细地址：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblAddresss" runat="server"></asp:Literal>&nbsp;</td>
                        <td class="form_text_row">邮政编码：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblZips" runat="server"></asp:Literal>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="form_text_row">电话：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblTel" runat="server"></asp:Literal>&nbsp;</td>
                        <td class="form_text_row">手机：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblModeil" runat="server"></asp:Literal>&nbsp;</td>
                    </tr>
        			<tr>
                        <td class="form_text_row">标志建筑：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblConig" runat="server"></asp:Literal>&nbsp;</td>
                        <td class="form_text_row">最佳送货时间：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="lblConTime" runat="server"></asp:Literal>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="form_text_row">配送地区：</td>
                        <td class="form_ctrl_row" colspan="3"><asp:Literal ID="lblAdd" runat="server"></asp:Literal>&nbsp;</td>
                        
                    </tr>                    
                    
			         <tr>
			             <td width="15%"></td>
			             <td width="35%"></td>
			             <td width="15%"></td>
			             <td width="35%"></td>
			         </tr>
		         </table>
    </div>
    
    
    </td>
    </tr>
    </table>
    <script type="text/javascript" defer="defer">
        ShowDiv(0,1);
    </script>
</asp:Content>
