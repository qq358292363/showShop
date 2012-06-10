<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="bannerchannel_edit.aspx.cs" Inherits="ShowShop.Web.admin.systeminfo.bannerchannel_edit" %>

<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>
<asp:Content ID="ContHead" runat="server" ContentPlaceHolderID="head">
 <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <link rel="stylesheet" href="../style/toolbar.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <script type="text/javascript" src="../scripts/public.js"></script>
    <script type="text/javascript" src="../scripts/calendar.js"></script>
    <script type="text/javascript" src="../scripts/changehope.js"></script>
    <script type="text/javascript">
function ShowDivColumn(tabid,num)
{
    var tab;
    for(var i=0;i<num;i++)
    {
        tab="tab"+i;
        if(i==tabid)
        { 
           document.getElementById(tab).style.display='block';
        }
        else
        {  
           document.getElementById(tab).style.display='none';
        }
    }
}
    </script>
</asp:Content>
<asp:Content ID="ContTitle" runat="server" ContentPlaceHolderID="pagetitle">
编辑栏目
</asp:Content>
<asp:Content ID="ContInfo" runat="server" ContentPlaceHolderID="pageinfo"> 
</asp:Content>
<asp:Content ID="ContSarch" runat="server" ContentPlaceHolderID="pagesarch">
   <a href="#" onclick="ShowDivColumn(0,4)">基本信息</a>
   <a href="#" onclick="ShowDivColumn(1,4)">栏目选项</a>
   <a href="#" onclick="ShowDivColumn(2,4)">权限设置</a>
   <a href="#" onclick="ShowDivColumn(3,4)">自设选项</a>
   &nbsp;&#1769;&nbsp;&nbsp;&#1769;&nbsp;&nbsp;&#1769;&nbsp;&nbsp;&#1769;&nbsp;&nbsp;&#1769;&nbsp;
    <asp:LinkButton ID="btnSave" runat="server">确定</asp:LinkButton> <a href="javascript:window.history.back()">取消返回</a>
</asp:Content>
<asp:Content ID="ContMain" runat="server" ContentPlaceHolderID="workspace">
<asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    </asp:Panel>
    <!--基本信息-->
    <div id="tab0"  class="tabs">
        <table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
          <tr>
             <td class="form_table_input_info">所属栏目频道：</td>
             <td>
                 <asp:DropDownList ID="ddlChannel" runat="server"></asp:DropDownList>
                 <asp:HiddenField ID="txtParentId" runat="server" />
                <asp:HiddenField ID="txtId" runat="server" />
             </td>
             <td>
                <div class="msgNormal">该频道的所属栏目</div>
            </td>
          </tr>
          <tr>
             <td class="form_table_input_info">栏目名称：</td>
               <td>
                <asp:TextBox ID="txtName" CssClass="long_input" runat="server"></asp:TextBox>
              </td>
              <td>
                 <asp:Panel ID="txtNameTip" runat="server">
                 </asp:Panel>
              </td>
          </tr>
          <tr>
             <td class="form_table_input_info">栏目类别：</td>
              <td>
                <asp:RadioButtonList ID="txtShop" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True" Value="system">系统</asp:ListItem>
                    <asp:ListItem Value="shop">网店</asp:ListItem>
                </asp:RadioButtonList>
             </td>
		      <td>
                <div class="msgNormal">该栏目是系统栏目还是用户网店栏目</div>
              </td>
          </tr>
          <tr>
             <td class="form_table_input_info">栏目说明：</td>
               <td>
                <asp:TextBox ID="txtDescription" TextMode="MultiLine" runat="server"></asp:TextBox>
            </td>
		    <td>
                <div class="msgNormal">用于在栏目页详细介绍栏目信息</div>
            </td>
          </tr>
          <tr>
             <td class="form_table_input_info">项目名称：</td>
               <td><asp:TextBox id="txtProjectName" runat="server" CssClass="long_input" ></asp:TextBox></td>
              <td><asp:Panel id="txtProjectNameTip" runat="server"></asp:Panel></td>
          </tr>
          <tr>
              <td class="form_table_input_info">项目单位：</td>
              <td><asp:TextBox id="txtProjectUtil" runat="server" CssClass="long_input" ></asp:TextBox></td>
              <td><asp:Panel id="txtProjectUtilTip" runat="server"></asp:Panel></td>
          </tr>
          
          <tr>
             <td class="form_table_input_info">栏目类型：</td>
             <td>
             <asp:RadioButtonList ID="ckbType" runat="server" RepeatDirection="Horizontal" 
               RepeatLayout="Flow">
               <asp:ListItem Value="1" Selected="True">系统栏目</asp:ListItem>
               <asp:ListItem Value="2">外部链接</asp:ListItem>
               <asp:ListItem Value="3">系统单页</asp:ListItem>
             </asp:RadioButtonList>
              <br /><span id='classarea'>英文名称：</span>
              <input name='FolderEname' type='text' id='txtEname' value='' /><font color="red">*</font><span id='classtips'>不能带\/：*？“ < > | 等特殊符号,且设定后不能改</span>
             </td>
          </tr>
             <tr id="templatearea">
                <td class="form_table_input_info">栏目模板：</td>
                <td><asp:TextBox id="txtTemplate" runat="server" CssClass="long_input" ></asp:TextBox><asp:Button ID="btnTemplates" runat="server" Text="选者模板..." /></td>
                <td><asp:Panel id="txtTemplateTip" runat="server"></asp:Panel></td>
              
             </tr>
             <tr id="tempcontent">
                <td class="form_table_input_info">内容页模板：</td>
                <td><asp:TextBox ID="txtGutTemp" runat="server" CssClass="long_input" ></asp:TextBox><asp:Button ID="btnGut" runat="server" Text="选者模板..." /></td>
                <td><asp:Panel ID="txtGutTempTip" runat="server"></asp:Panel></td>
              
             </tr>
             <tr id="editorarea">
              <td class="form_table_input_info">单页内容：</td>
              <td>
                 <FCKeditorV2:FCKeditor ID="txtOneContent" runat="server" Width="500px"></FCKeditorV2:FCKeditor>
              </td>
              <td><div class="msgNormal">使用标签{$GetClassIntro}在模板里调用</div></td>
             </tr>
           </table>
     
 </div>
 <!--栏目选项-->
 <div id="tab1" class="tabs">
    <table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
       <tr>
             <td class="form_table_input_info">打开方式：</td>
              <td>
                   <asp:RadioButtonList ID="ckbTarget" runat="server" RepeatDirection="Horizontal" 
                       RepeatLayout="Flow">
                       <asp:ListItem Value="1">新页面</asp:ListItem>
                       <asp:ListItem Value="2" Selected="True">本页面</asp:ListItem>
                       <asp:ListItem Value="3">父页面</asp:ListItem>
                   </asp:RadioButtonList>
               </td>
             <td><div class="msgNormal">打开方式是指在打开该栏目的时候是打开新页面还是在本页面里显示</div></td>
        </tr>
       <tr>
        <td class="form_table_input_info">栏目顶部导航：</td>
        <td>
           <asp:RadioButtonList ID="radTopNavigation" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
             <asp:ListItem Value="0" Text="显示" Selected="True" />
             <asp:ListItem Value="1" Text="不显示" />
           </asp:RadioButtonList>
        </td>
        <td><div class="msgNormal">顶部导航</div></td>
      </tr>
       <tr>
         <td class="form_table_input_info">Mete关键字：</td>
         <td><asp:TextBox id="txtMeteKey" runat="server" CssClass="long_input" ></asp:TextBox></td>
         <td><asp:Panel id="txtMeteKeyTip" runat="server"></asp:Panel></td>
       </tr>
       <tr>
         <td class="form_table_input_info">Mete描述：</td>
          <td><asp:TextBox id="txtMeteDescription" runat="server" CssClass="long_input" 
               TextMode="MultiLine" ></asp:TextBox></td>
          <td><asp:Panel id="txtMeteDescriptionTip" runat="server"></asp:Panel></td>
       </tr>
    </table>
 </div>
 <!--权限设置-->
 <div id="tab2" class="tabs">
   <table class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">     
      <tr>
        <td class="form_table_input_info" rowspan="2">频道权限：</td>
        <td>
           <asp:RadioButton  ID="radOpen" runat="server" Text="开放频道" GroupName="rad"/>
        </td>
        <td><div class="msgNormal"> 任何人（包括游客）可以浏览和查看此栏目下的信息。</div></td>
      </tr>
      <tr>
        <td>
          <asp:RadioButton  ID="radAttestation" runat="server" Text="认证频道" GroupName="rad"/>
        </td>
        <td><div class="msgNormal"> 游客不能浏览和查看，其他会员根据会员组的栏目权限设置决定是否可以浏览和查看。</div></td>
      </tr>
      <tr>
        <td class="form_table_input_info">允许浏览此频道的会员组：</td>
        <td>
           <asp:CheckBoxList ID="ckbPower" runat="server" RepeatColumns="3" 
               RepeatDirection="Horizontal" RepeatLayout="Flow">
           </asp:CheckBoxList>
       </td>
       <td><div class="msgNormal">哪些用户可以浏览该栏目</div></td>
      </tr>
   </table>
 </div>
 <!--自设选项-->
 <div id="tab3" class="tabs">
    <table class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0"> 
       <tr>
         <td class="form_table_input_info">自设内容数：</td>
         <td>
           <select id="selNumber" name="selNumber"  onchange="setFileFileds(this.value)"><option value="1" selected="selected" >1</option><option value="2">2</option><option value="3">3</option><option value="4">4</option><option value="5">5</option><option value="6">6</option><option value="7">7</option><option value="8">8</option><option value="9">9</option><option value="10">10</option></select>
         
         </td>
       </tr>
       <tr id="objFile1" style="display:block">
         <td class="form_table_input_info">自设内容1：</td>
         <td>
            <asp:TextBox ID="txtContent1" runat="server" TextMode="MultiLine"></asp:TextBox>
         </td>
         <td><div class="msgNormal">在栏目模板页插入{$GetClassDefineContent1} 调用</div></td>
       </tr>
       <tr id="objFile2">
         <td class="form_table_input_info">自设内容2：</td>
         <td>
            <asp:TextBox ID="txtContent2" runat="server" TextMode="MultiLine"></asp:TextBox>
         </td>
         <td><div class="msgNormal">在栏目模板页插入{$GetClassDefineContent2} 调用</div></td>
       </tr>
       <tr id="objFile3">
         <td class="form_table_input_info">自设内容3：</td>
         <td>
            <asp:TextBox ID="txtContent3" runat="server" TextMode="MultiLine"></asp:TextBox>
         </td>
         <td><div class="msgNormal">在栏目模板页插入{$GetClassDefineContent3} 调用</div></td>
       </tr>
       <tr id="objFile4">
         <td class="form_table_input_info">自设内容4：</td>
         <td>
            <asp:TextBox ID="txtContent4" runat="server" TextMode="MultiLine"></asp:TextBox>
         </td>
         <td><div class="msgNormal">在栏目模板页插入{$GetClassDefineContent4} 调用</div></td>
       </tr>
       <tr id="objFile5">
         <td class="form_table_input_info">自设内容5：</td>
         <td>
            <asp:TextBox ID="txtContent5" runat="server" TextMode="MultiLine"></asp:TextBox>
         </td>
         <td><div class="msgNormal">在栏目模板页插入{$GetClassDefineContent5} 调用</div></td>
       </tr>
       <tr id="objFile6">
         <td class="form_table_input_info">自设内容6：</td>
         <td>
            <asp:TextBox ID="txtContent6" runat="server" TextMode="MultiLine"></asp:TextBox>
         </td>
         <td><div class="msgNormal">在栏目模板页插入{$GetClassDefineContent6} 调用</div></td>
       </tr>
       <tr id="objFile7">
         <td class="form_table_input_info">自设内容7：</td>
         <td>
            <asp:TextBox ID="txtContent7" runat="server" TextMode="MultiLine"></asp:TextBox>
         </td>
         <td><div class="msgNormal">在栏目模板页插入{$GetClassDefineContent7} 调用</div></td>
       </tr>
       <tr id="objFile8">
         <td class="form_table_input_info">自设内容8：</td>
         <td>
            <asp:TextBox ID="txtContent8" runat="server" TextMode="MultiLine"></asp:TextBox>
         </td>
         <td><div class="msgNormal">在栏目模板页插入{$GetClassDefineContent8} 调用</div></td>
       <tr id="objFile9">
         <td class="form_table_input_info">自设内容9：</td>
         <td>
            <asp:TextBox ID="txtContent9" runat="server" TextMode="MultiLine"></asp:TextBox>
         </td>
         <td><div class="msgNormal">在栏目模板页插入{$GetClassDefineContent9} 调用</div></td>
        <tr id="objFile10">       
         <td class="form_table_input_info">自设内容10：</td>
         <td>
            <asp:TextBox ID="txtContent10" runat="server" TextMode="MultiLine"></asp:TextBox>
         </td>
         <td><div class="msgNormal">在栏目模板页插入{$GetClassDefineContent10} 调用</div></td>
       </tr>   
    </table>
 </div>
 
 <script type="text/javascript">  
  ShowDivColumn(0,1);  
  setFileFileds($("#selNumber").val());
  function setFileFileds(num){    
    for(var i=1,str="";i<=10;i++){
	    $("#objFile" + i).hide();
   }
   for(var i=1,str="";i<=num;i++){	
      $("#objFile" + i).show();
   }
}
changetype(1);
function changetype(v)
{
  switch(parseInt(v))
  {
   case 1:$('#editorarea').hide();$('#classarea').html('英文名称：');$('#classtips').html('不能带\/：*？“ < > | 等特殊符号,且设定后不能改');$('#templatearea').show();$('#tempcontent').show();break;
   case 2:$('#editorarea').hide();$('#classarea').html('链接地址：');$('#classtips').html('如 <font color=blue>http://www.changehope.com</font> 等');$('#templatearea').hide();$('#tempcontent').hide();break;
   case 3:$('#editorarea').show();$('#classarea').html('生成文件名：');$('#classtips').html('如 <font color=blue>about.html,intro.html,help.html</font>等');$('#templatearea').show();break;
  }
}
</script>
</asp:Content>
