<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="product_specialspecification.aspx.cs" Inherits="ShowShop.Web.admin.product.product_specialspecification" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <script src="../scripts/public.js" type="text/javascript"></script>
    <script type="text/javascript">
     /*添加相片*/
    function addFile()
    {   
        var str = ' <table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0"><tr><td>本地图片：<input type="file" name="File" runat="server" /></td><td>描述：<input name="description" type="text" value="" maxlength="200" /></td></tr></table>'
        document.getElementById("MyFile").insertAdjacentHTML("beforeEnd",str);   
    }  
    function GetColor(img_val,input_val)
    {
	    var PaletteLeft,PaletteTop
	    var obj = document.getElementById("colorPalette");
	    ColorImg = img_val;
	    ColorValue = document.getElementById(input_val);	
	    if (obj){
		    PaletteLeft = getOffsetLeft(ColorImg)
		    PaletteTop = (getOffsetTop(ColorImg)-250)
		    if (PaletteTop<0)PaletteTop+=ColorImg.offsetHeight+165;
		    if (PaletteLeft+260 > parseInt(document.body.clientWidth)) PaletteLeft = parseInt(event.clientX)-280;
		    obj.style.left = PaletteLeft + "px";
		    obj.style.top = PaletteTop + "px";
		    if (obj.style.visibility=="hidden")
		    {
			    obj.style.visibility="visible";
		    }else {
			    obj.style.visibility="hidden";
		    }
	    }
    }
    function getOffsetLeft(elm) {
	    var mOffsetLeft = elm.offsetLeft;
	    var mOffsetParent = elm.offsetParent;
	    while(mOffsetParent) {
		    mOffsetLeft += mOffsetParent.offsetLeft;
		    mOffsetParent = mOffsetParent.offsetParent;
	    }
	    return mOffsetLeft;
    }
    function getOffsetTop(elm) {
	    var mOffsetTop = elm.offsetTop;
	    var mOffsetParent = elm.offsetParent;
	    while(mOffsetParent){
		    mOffsetTop += mOffsetParent.offsetTop;
		    mOffsetParent = mOffsetParent.offsetParent;
	    }
	    return mOffsetTop;
    }
    function setColor(color)
    {
	    if(ColorImg.id=="FontColorShow"&&color=="#") color='#000000';
	    if(ColorImg.id=="FontBgColorShow"&&color=="#") color='#FFFFFF';
	    if (ColorValue){ColorValue.value = color.substr(1);}
	    if (ColorImg && color.length>1){
		    ColorImg.src=src='../images/Rect.gif';
		    ColorImg.style.backgroundColor = color;
	    }else if(color=='#'){ ColorImg.src='../images/rectNoColor.gif';}
	    document.getElementById("colorPalette").style.visibility="hidden";
    }
    function Sign(str)
    {
        if(str=="1")
        {
            document.getElementById("<%=ColorSign.ClientID %>").style.display="";
            document.getElementById("<%=ColorAddressImages.ClientID %>").style.display="none";
        }
        else
        {
            document.getElementById("<%=ColorSign.ClientID %>").style.display="none";
            document.getElementById("<%=ColorAddressImages.ClientID %>").style.display="";
        }
    }
    function DelProAlbum(id)
    {
        var param = "Option=delAlbum&ID="+ id;
        var options={
            method:'post',
            parameters:param,
            onComplete:
            function(transport)
	        {
                 var retv=transport.responseText;
                 document.getElementById("divPhoto").innerHTML=retv;
		    }     
	      }
	    new  Ajax.Request('product_specialspecification.aspx',options);
    }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server"><asp:Label ID="speProperty" runat="server"></asp:Label>
    <asp:Button ID="button1" runat="server" CssClass="inputbutton" 
        onclick="button2_Click" Text="保存设置" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
    <asp:HyperLink ID="HyperLink1" runat="server"  CssClass="inputbutton" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返回列表</asp:HyperLink>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">添加或编辑商品品牌 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
    <asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    </asp:Panel>
    <iframe width="260" height="165" id="colorPalette" src="../include/selcolor.htm"
            style="visibility: hidden; position: absolute; border: 1px gray solid; left: 297px;
            top: -20px;" frameborder="0" scrolling="no"></iframe>
    <table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
         <tr>
             <td colspan="2" class="page_button">
                 <table border="0">
                     <tr>
                         <td>
                             <span style="font-weight:bold; font-size:14px;"><asp:Label ID="SpecificationValue" runat="server"></asp:Label></span>
                         </td>
                         <td>
                             <asp:RadioButtonList ID="rblSpecSign" runat="server" RepeatDirection="Horizontal">
                                 <asp:ListItem Value="1" Text="颜色标示" Selected="True" onclick="Sign('1')"></asp:ListItem>
                                 <asp:ListItem Value="2" Text="上传本地图标" onclick="Sign('2')"></asp:ListItem>
                             </asp:RadioButtonList>
                         </td>
                         <td>
                            <span id="ColorSign" runat="server">
                                 <asp:HiddenField ID="TitleColor" runat="server" />
                                 <img src="../images/Rect.gif" alt="-" name="MarkFontColor_Show"
                                            width="18" height="17" border="0" align="middle" id="MarkFontColor_Show" style="cursor: pointer;
                                            background-color:#<%=Color %>" title="选取颜色" onclick="GetColor(this,'<%=TitleColor.ClientID %>');" />
                             </span> 
                             <span id="ColorAddressImages" style="display:none" runat="server">
                                 <asp:FileUpload ID="fuColorSign" runat="server" />
                                 <asp:Literal ID="SignImages" runat="server"></asp:Literal>
                             </span>
                         </td>
                         <td>
                              <asp:HyperLink ID="HyperLink3" runat="server"  CssClass="inputbutton" NavigateUrl="javascript:addFile()" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">增加相片</asp:HyperLink>
                         </td>
                     </tr>
                 </table>
                 
             </td>
         </tr>
         <tr>
             <td>
                 本地图片：<input id="File2" type="file" name="File" runat="server" />
             </td>
             <td>
                描述：<input type="text" name="description" maxlength="200" />
             </td>
         </tr>
    </table>
    <div id="MyFile"></div>
    <div id="divPhoto">
        <table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
             <tr>
                 <span id="spanJSAlbum"><asp:Literal ID="litaAlbum" runat="server"></asp:Literal></span>
             </tr>
        </table>
   </div>
</asp:Content>
<asp:Content ContentPlaceHolderID="pagebottom" runat="server" ID="ContentBottom">
    <asp:Button ID="button2" runat="server" CssClass="inputbutton"  Text="保存设置" 
        onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" 
        onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'" 
        onclick="button2_Click"/>
    <asp:HyperLink ID="HyperLink2" runat="server"  CssClass="inputbutton"  Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返回列表</asp:HyperLink>
</asp:Content>