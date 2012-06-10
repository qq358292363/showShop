<%@ Page Language="C#" ValidateRequest="false" AutoEventWireup="true" CodeBehind="specifications_add.aspx.cs" Inherits="ShowShop.Web.admin.include.specifications_add" %>

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
    var name=document.getElementById("<%=txtSpecificationsName.ClientID %>").value;
    var value=document.getElementById("<%=txtSpecificationsValue.ClientID %>").value;
    if(name=="")
    {
        document.getElementById("specificationsName").innerHTML="<span style='color:red'>请输入规格名称。</span>";
        return false;
    }
    if(value=="")
    {
        document.getElementById("specificationsValue").innerHTML="<span style='color:red'>请输入规格值，每行代表一个规格值。</span>";
        return false;
    }
    var param = "Option=SpecificationsProduct&Name="+name+"&Value=" + value;
    var options = 
    { method: 'post',parameters: param,onComplete:
         function(transport)
         {
             var retv = transport.responseText;
             parent.document.getElementById("Specifications").innerHTML=retv;
             particularitySpe();
             CloseDiv();
         }
    }
    new Ajax.Request('specifications_add.aspx', options);
    
}
function TowReturnValue()
{
    var name=document.getElementById("<%=txtSpecificationsName.ClientID %>").value;
    var value=document.getElementById("<%=txtSpecificationsValue.ClientID %>").value;
    if(name=="")
    {
        document.getElementById("specificationsName").innerHTML="<span style='color:red'>请输入规格名称。</span>";
        return false;
    }
    if(value=="")
    {
        document.getElementById("specificationsValue").innerHTML="<span style='color:red'>请输入规格值，每行代表一个规格值。</span>";
        return false;
    }
    var strContent=parent.document.getElementById("SpecificationsContent").innerHTML;
    var count=parent.document.getElementById("SpecificationRows").value;
    
    var groupCount=parent.document.getElementById("SpeGroupCount").value;
    parent.document.getElementById("SpeGroupCount").value=parseInt(groupCount)+1;
    var newGroupCount=parseInt(groupCount)+1;
    var hfValue="<input type=\"hidden\" name=\"SpecificationsName"+newGroupCount+"\" id=\"SpecificationsName"+newGroupCount+"\" value=\"" + name + "\" />";
    hfValue+="<input type=\"hidden\" name=\"SpecificationsValue"+newGroupCount+"\" id=\"SpecificationsValue"+newGroupCount+"\" value=\"" + value + "\" />";
    
    var addTitle ="<td style='font-weight:bold; text-align:center;' >" +hfValue+ name + "</td>";
    var titleValue=parent.document.getElementById("SpeTitle").innerHTML;
    strContent = strContent.replace(titleValue, titleValue+addTitle);
    strContent=strContent.replace("</TABLE>","")
    value=value.split('\n');
    if(value.length>0)
    {
        var rows=parseInt(count);
        for(var v=0;v<value.length;v++)
        {
            for(var g=0;g<parseInt(count);g++)
            {
                var va=value[v].replace("\r", "");
                if(parent.document.getElementById("SpeValueGroup"+g))
                {
                    var speValRows=parent.document.getElementById("SpeValRows"+g);
                    if(speValRows)
                    {
                        var speValue=parent.document.getElementById("SpeValue"+speValRows.value).value;
                        var oldValue=parent.document.getElementById("SpeValueGroup"+g).innerHTML;
                        if(v==0)
                        {
                            var ng=newGroupCount+"_"+speValRows.value;
                            strContent = strContent.replace(oldValue, oldValue+"<td style=\"text-align:center;\">" + va + "</td>");
                            var spanSpeValue=parent.document.getElementById("spanSpeValue"+speValRows.value).innerHTML;
                            strContent=strContent.replace(spanSpeValue,"<input type=\"hidden\" name=\"SpeValue" +  speValRows.value + "\" id=\"SpeValue" +  speValRows.value + "\" value=\"" + speValue.replace("\r", "")+","+va + "\"/>");
                        }
                        else
                        {
                            var newSpeValue=speValue+","+va;
                            strContent += "<tr id=\"trSpeRows"+rows+"\">";
                            strContent += "<td>";
                            strContent += "<input type=\"hidden\" name=\"SpeValRows" + rows + "\" id=\"SpeValRows" + rows + "\" value=\"" + rows + "\"/>";
                            strContent +="<span id=\"spanSpeValue"+rows+"\"><input type=\"hidden\" name=\"SpeValue" +rows + "\" id=\"SpeValue" + rows + "\" value=\"" + newSpeValue + "\" /></span>";
                            strContent += "<input type=\"text\" name=\"SpeItemNo" + rows + "\" id=\"SpeItemNo" + rows + "\" /></td>";
                            strContent += "<span id=\"SpeValueGroup" +rows + "\">";
                            strContent += ""+oldValue+"<td style=\"text-align:center;\">";
                            strContent += va + "</td>";
                            strContent += "</span>"
                            strContent += "<td><input type=\"text\" class=\"short_input\" name=\"SpeStock" + rows + "\" id=\"SpeStock" + rows + "\" /></td>";
                            strContent += "<td><input type=\"text\" class=\"short_input\" name=\"SpeIntegral" + rows + "\" id=\"SpeIntegral" + rows + "\" /></td>";
                            strContent += "<td><input type=\"text\" class=\"short_input\" name=\"SpeShopPrice" + rows+ "\" id=\"SpeShopPrice" + rows + "\" />";
                            strContent += "<input type=\"hidden\" class=\"short_input\" name=\"SpeMemberPrice" + rows + "\" id=\"SpeMemberPrice" + rows + "\" />";
                            strContent += "</td>";
                            strContent+="<td><a href=\"javascript:showPath('SetMemberPrice',document.getElementById('SpecificationsAddress'),'设置会员价',650,250,'../../','SpeShopPrice" + rows+ ";SpeMemberPrice" + rows + "');\">会员价</a> <a href='javascript:DelSpecificationRow(" + rows+ ")'>删除</a></td>";
                            strContent += "</tr>";
                            rows++;
                        }
                        
                    }
                }
            }
        }
        parent.document.getElementById("SpecificationRows").value=rows;
    }
    strContent=strContent+"</TABLE>";
    parent.document.getElementById("SpecificationsContent").innerHTML=strContent;
    particularitySpe();
    CloseDiv();
    
}
function CloseDiv()
{
    parent.document.getElementById("LabelDivid").style.display="none";
}

function particularitySpe()
{
   var val;
   var va= document.getElementsByName("rblSpecifications"); 
   var len=va.length;   
    for (var i=0;i<len ;i++ )
    {
        if( va[i].checked==true )
        {
            val=va[i].value;
        }
    }
    if(val=="1")
    {
        parent.document.getElementById("ctl00_workspace_IsSpecAlbum").value=val;
        var speName=document.getElementById("<%=txtSpecificationsName.ClientID %>").value;
        var speValue=document.getElementById("<%=txtSpecificationsValue.ClientID %>").value;
        parent.document.getElementById("ctl00_workspace_SpecialSpecName").value=speName;
        parent.document.getElementById("ctl00_workspace_SpecialSpecValue").value=speValue;
    }
}
function SpecAlum()
{
    var va=parent.document.getElementById("ctl00_workspace_IsSpecAlbum").value;
    if(va=="1")
    {
       document.getElementById("divSpecialspe").style.display="none";
       document.getElementById("divSpecialspeVal").style.display="";
       document.getElementById("defaultSpeValue").innerHTML=parent.document.getElementById("ctl00_workspace_SpecialSpecName").value;
    }
    else
    {
        document.getElementById("divSpecialspeVal").style.display="none";
    }
}
function CancelSpe()
{
   if(confirm("温馨提示：取消后将不可进行恢复，确认要取消吗？"))
   { 
       document.getElementById("divSpecialspe").style.display="";
       document.getElementById("divSpecialspeVal").style.display="none";
        parent.document.getElementById("ctl00_workspace_IsSpecAlbum").value="0";
        parent.document.getElementById("ctl00_workspace_SpecialSpecName").value="";
        parent.document.getElementById("ctl00_workspace_SpecialSpecValue").value="";
   }
   else
   {
       document.getElementById("<%=cbCancelSpe.ClientID %>").checked=false;
       document.getElementById("divSpecialspe").style.display="none";
       document.getElementById("divSpecialspeVal").style.display="";
   }
}
</script>
</head>
<body onload="SpecAlum()">
    <form id="form1" runat="server">
        <div>
         <table style="width: 100%;" class="form_table_input">
             <tr>
                <td class="form_table_input_info">
                    规格名称：
                </td>
                <td>
                    <asp:TextBox ID="txtSpecificationsName" runat="server"></asp:TextBox>
                </td>
                <td>
                    <div id="specificationsName" class="msgNormal">请输入规格名称。</div>
                </td>
            </tr>
            <tr>
                <td class="form_table_input_info">
                    规格值：
                </td>
                <td>
                    <asp:TextBox ID="txtSpecificationsValue" runat="server" TextMode="MultiLine" 
                        Height="94px" Width="180px"></asp:TextBox>
                </td>
                <td>
                    <div id="specificationsValue" class="msgNormal">请输入规格值，每行代表一个规格值。</div>
                </td>
            </tr>
            <tr>
                <td class="form_table_input_info">特殊规格：</td>
                <td>
                    <div id="divSpecialspe">
                        <asp:RadioButtonList ID="rblSpecifications" Name="rblSpecifications" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="0" Text="不启用" Selected="True"></asp:ListItem>
                            <asp:ListItem Value="1" Text="启用"></asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                    <div id="divSpecialspeVal" style="display:none">
                         <span id="defaultSpeValue"></span>&nbsp;<asp:CheckBox ID="cbCancelSpe" runat="server" onclick="CancelSpe()" />是否取消
                    </div>
                </td>
                <td>
                    <div id="Div1" class="msgNormal">启用特殊规格，可以为每一个规格值上传多张图片及标示。</div>
                </td>
            </tr>
            <tr>
                <td colspan="3" align="center">
                   <asp:Panel ID="panOne" runat="server">
                       <input type="button" id="Button1" value="保  存" onclick="ReturnValue()" />
                   </asp:Panel>
                   <asp:Panel ID="panTow" runat="server" Visible="false">
                       <input type="hidden" id="hfContent" name="hfContent"/>
                       <input type="button" id="Button2" value="保  存" onclick="TowReturnValue()" />
                   </asp:Panel>
                </td>
            </tr>
        </table>
        </div>
    </form>
</body>
</html>