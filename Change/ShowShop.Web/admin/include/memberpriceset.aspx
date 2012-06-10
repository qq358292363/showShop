<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="memberpriceset.aspx.cs" Inherits="ShowShop.Web.admin.include.memberpriceset" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <link href="../style/admin.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../style/toolbar.css" type="text/css" />
    <script src="../scripts/public.js" type="text/javascript"></script>
    <script src="../scripts/prototype.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
function ReturnValue()
{
    var count=document.getElementById("<%=hfMemberPrice.ClientID %>").value;
    var memberPrice;
    for(var i=1;i<parseInt(count)+1;i++)
    {
        if(document.getElementById("rankName"+i).value!="")
        {
            if(memberPrice==null)
            {
                memberPrice=document.getElementById("rankId"+i).value+","+document.getElementById("rankName"+i).value;
            }
            else
            {
                memberPrice=memberPrice+"|"+document.getElementById("rankId"+i).value+","+document.getElementById("rankName"+i).value;
            }
        }
    }
    var contrl=document.getElementById("<%=hfContrl.ClientID %>").value
    parent.document.getElementById(contrl).value=memberPrice;
    CloseDiv();
}

function CloseDiv()
{
    parent.document.getElementById("LabelDivid").style.display="none";
}

function Button1_onclick() {

}

</script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
         <table style="width: 100%;" class="form_table_input">
            <tr>
                <td colspan="3" align="center">
                    <asp:HiddenField ID="hfMemberPrice" runat="server" />
                    <asp:HiddenField ID="hfContrl" runat="server" />
                   <input type="button" id="Button1" value="保  存" onclick="ReturnValue()" />
                </td>
            </tr>
        </table>
        </div>
    </form>
</body>
</html>