<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="member_list.aspx.cs" Inherits="ShowShop.Web.admin.member.member_list" Title="无标题页" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <link rel="stylesheet" href="../style/toolbar.css" type="text/css" />
    <script src="../scripts/images.js" type="text/javascript"></script>
    <script src="../scripts/public.js" type="text/javascript"></script>
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <script type="text/javascript">
function SelectAll(tempControl)
{
      var theBox=tempControl;
      xState=theBox.checked;    
      elem=theBox.form.elements;
      for(i=0;i<elem.length;i++)
      if(elem[i].type=='checkbox' && elem[i].id!=theBox.id)
      {
        if(elem[i].checked!=xState)
           elem[i].click();
                        
      }
}   
function GetStat(stat)
{
   if(stat=="1")
     {
        document.write("冻结");
     }else
     {
        document.write("正常");
     }
}
    function DelAll(id)
    { 
       var idStr;
       if(id<0)
       {
            idStr = GetAllChecked();
            if(idStr == "")
            {
                alert("您没有选择要删除的信息!");
                return;
            }
       }
       else
       {
           idStr=id
       }
       if(confirm('确定要永久删除该信息吗?删除后将不能被恢复!'))
       {
             SendAjax("del",idStr);
       }
    }
 //批量锁定
function Lock(id)
{
    var idStr;
    if(id < 0)
    {
        idStr = GetAllChecked();
        if(idStr == "")
        {
            alert("您没有选择要锁定的信息!");
            return;
        }
    }
    else
    {
        idStr = id;
    }
    if(confirm('确定要锁定您所选择的信息吗?'))
    {
         SendAjax("locked",idStr);
    }
}
//批量解锁
function UnLock(id)
{
    var idStr;
    if(id < 0)
    {
        idStr = GetAllChecked();
        if(idStr == "")
        {
            alert("您没有选择要解锁的信息!");
            return;
        }
    }
    else
    {
        idStr = id;
    }
    if(confirm('确定要解锁您所选择的信息吗?'))
    {
         SendAjax("Unlocked",idStr);
    }
}
//编辑有效期
function AddUsefulLife(op)
{
   var idStr;
   idStr=GetAllChecked();
   window.location.href="useful_add.aspx?strId="+idStr+"&Opreate="+op;
   
}
//编辑点卷
function EditWrap(op){
  var isStr;
  idStr=GetAllChecked();
  window.location.href="wrap_edit.aspx?strId="+idStr+"&Opreate="+op;
}
//编辑奖金
function EditBonus(op)
{
   var idStr;
   idStr = GetAllChecked();
   window.location.href="bonus_send.aspx?strId="+idStr+"&Opreate="+op;
}
//移动与邮件
function Make(op)
{
  var idStr;
  idStr = GetAllChecked();
  switch (op){
      case "move":
            window.location.href="member_move.aspx?strId="+idStr;
            break;
      case "email":
            window.location.href="email_send.aspx?strId="+idStr;
            break;
  }
}
function SendAjax(op,id)
{
    var param = "Option="+ op +"&id="+ id;
    var options={
        method:'post',
        parameters:param,
        onComplete:
        function(transport)
	    {
	      var retv=transport.responseText;
		  window.location.reload();
		}     

	  }
	new  Ajax.Request('member_list.aspx',options);
}
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">会员管理
    <asp:HyperLink ID="HyperLink2" runat="server"  CssClass="inputbutton" NavigateUrl="member_edit.aspx" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">添加会员</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">会员信息管理&nbsp; 
    用户名：<asp:TextBox ID="w_l_userid" CssClass="date_input" runat="server"></asp:TextBox>
    用户类别：<asp:DropDownList ID="w_d_UserType" runat="server"></asp:DropDownList>
    用户等级：<asp:DropDownList ID="w_d_UserGroup" runat="server"></asp:DropDownList>
    状态：<asp:DropDownList ID="w_d_State" runat="server">
        <asp:ListItem Value="">不限制</asp:ListItem>
        <asp:ListItem Value="0">正常</asp:ListItem>
        <asp:ListItem Value="1">冻结</asp:ListItem>
    </asp:DropDownList>
    <asp:Button ID="button1" runat="server" CssClass="inputbutton" onclick="LinkButton1_Click" Text="查  询" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
    <asp:Literal ID="ltlview" EnableViewState="false" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="pagesarch" runat="server">
<hr style="border: 1px dashed #DDDDDD; margin:0 0 4px 0;" />
           <a href="#" onclick="javascript:EditBonus('allay')">批量扣奖金</a>
           <a href="#" onclick="javascript:EditWrap('allay')"  >扣除点券</a>
           <a href="#" onclick="javascript:Lock(-1)"  >批量锁定</a>
           <a href="#" onclick="javascript:UnLock(-1)"  >批量解锁</a>
           <a href="#" onclick="javascript:AddUsefulLife('add')" >添加有效期</a>
           <a href="#" onclick="javascript:EditBonus('add')" >批量发奖金</a>
           <a href="#" onclick="javascript:Make('email')" >发送邮件</a>
           <a href="#" onclick="javascript:AddUsefulLife('allay')">减少有效期</a>
           <a href="#" onclick="javascript:Make('move')" >批量移动</a>
           <a href="#" onclick="javascript:EditWrap('add')" >奖励点券</a>
           <hr style="border: 1px dashed #DDDDDD; margin:0 0 4px 0;" />
           <input type="checkbox"  id="cheAll" onclick="SelectAll(cheAll)"/>全选/取消
           <a href="#" onclick="javascript:DelAll(-1)"  >批量删除</a>
</asp:Content>