<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="area.aspx.cs" Inherits="ShowShop.Web.controls.area" %>
<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <style>
        .Big_City
        {
        	line-height:30px;color:red;font-size:14px;font-weight:bold
        }
        .Small_City
        {
        	line-height:20px;font:12px; padding:2px 10px
        }
        A:active ,A:hover{
	COLOR: #ff0000; TEXT-DECORATION: underline
}

A:link,A:visited  {
	COLOR: #3366CC; TEXT-DECORATION: none
}
    </style>

    <script src="../scripts/prototype.js" type="text/javascript"></script>
    <script language="javascript" type="text/javascript">
    function City(CityId)
    {
      SendAjax("ConMain",CityId);
      ContentMain("ConMain",CityId);
    }
function SendAjax(op,CityId)
{
    var param = "Option="+ op +"&CityId="+ CityId;
    var options={
        method:'post',
        parameters:param,
        onComplete:
        function(transport)
	    {
	      var retv=transport.responseText;
		  document.getElementById("City").innerHTML=retv;
		}     

	  }
	new  Ajax.Request('area.aspx',options);
}
function Calm(CityId)
{
  ContentMain("ConMain",CityId);
}
function ContentMain(op,CityId)
{
    var param = "Option1="+ op +"&CityId="+ CityId;
    var options={
        method:'post',
        parameters:param,
        onComplete:
        function(transport)
	    {
	      var retv=transport.responseText;
		  document.getElementById("MainConent").innerHTML=retv;
		}     

	  }
	new  Ajax.Request('area.aspx',options);
}
    </script>
</head>
<body style=" margin:0; padding:0;font-size:12px" onload="ContentMain('ConMain','0')">
<table border="0" width="98%">
   <tr><td></td></tr>
   <tr>
       <td height="60px"><fieldset><legend><span style="font-weight:bold;font-size:14px">请选择浏览地区</span></legend>&nbsp;<%=Proviecs %>&nbsp;<span id="City"></span><span style="font-size:14px;font-weight:bold;">&nbsp;<a target='_parent' href='../controls/cookie.aspx?ConversionCity=0'>返回总站</a></span>&nbsp;<br /> <span style="color:#666666">选择某地区代表您将浏览该地区分站信息。</span></fieldset> </td>
   </tr>
   <tr>
       <td><span id="MainConent"></span></td>
   </tr>
</table>
</body>
</html>
