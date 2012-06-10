<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sparepartproduct.aspx.cs" Inherits="ShowShop.Web.admin.include.sparepartproduct" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
    <link href="../style/admin.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../style/toolbar.css" type="text/css" />
    <script src="../scripts/public.js" type="text/javascript"></script>
    <script src="../scripts/prototype.js" type="text/javascript"></script>
<script language="javascript" type="text/javascript">
function ReturnValue()
{
    
    var sparepartId=document.getElementById("<%=hfSparepartID.ClientID %>").value;
    //已存在的商品
    var eProductId=parent.document.getElementById("hfProductSparepartID"+sparepartId).value;
    if(sparepartId=="")
    {
        alert("程序出错！");
        return false;
    }
    //选中的商品
    var productId= GetAllChecked();
    if(productId=="")
    {
        alert("请选择商品！");
        return false;
    }
    //已存在的商品与选中的商品对比
    if(eProductId!="")
    {
        var proIdArray=productId.split(',');
        var eProIdArray=eProductId.split(',');
        for(var i=0;i<proIdArray.length;i++)
        {
            if((","+eProductId+",").indexOf(","+proIdArray[i]+",")<0)
            {
               eProductId+=","+proIdArray[i];
            }
        }
        productId=eProductId;
    }
    var param = "Option=SpareartProduct&SparepartId="+sparepartId+"&id=" + productId;
    var options = 
    { method: 'post',parameters: param,onComplete:
         function(transport)
         {
             parent.document.getElementById("hfProductSparepartID"+sparepartId).value=productId;
             var retv = transport.responseText;
             parent.getValue(retv,sparepartId);
             CloseDiv();
         }
    }
    new Ajax.Request('sparepartproduct.aspx', options);
    
}
function CloseDiv()
{
    parent.document.getElementById("LabelDivid").style.display="none";
}

</script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
         <table style="width: 100%;" class="form_table_input">
            <tr>
                <td style="width: 100%;">
                    商品名称：<asp:TextBox ID="w_l_pro_Name" runat="server"></asp:TextBox>
                    货号：<asp:TextBox ID="w_l_pro_NO" runat="server"></asp:TextBox>
                    <asp:Button ID="lbSearch" runat="server" Text="查 询" onclick="lbSearch_Click1" />
                </td>
            </tr>
        </table>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
       <table style="width: 100%;" class="form_table_input">
            <tr>
                <td style="width: 100%;" align="center"><input type="hidden" runat="server" name="hfSparepartID" id="hfSparepartID" />
                    <input type="button" id="Button2" value="确 定" onclick="ReturnValue()" />
                </td>
            </tr>
        </table>
        </div>
    </form>
</body>
</html>