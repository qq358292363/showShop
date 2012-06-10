<%@ Page Language="C#" ValidateRequest="false" MasterPageFile="~/admin/admin_page.master"
    AutoEventWireup="true" CodeBehind="product_info_edit.aspx.cs" Inherits="ShowShop.Web.admin.product.product_info_edit" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .inputCSS
        {
            border-bottom-width: 1px;
            border-top-style: none;
            border-right-style: none;
            border-bottom-style: dashed;
            border-left-style: none;
            border-bottom-color: #000000;
            background-color: #EBEDE8;
            text-align: left;
            cursor: hand;
        }
    </style>
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <link rel="stylesheet" href="../style/dtree.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <script type="text/javascript" src="../scripts/public.js"></script>
    <script type="text/javascript" src="../scripts/product.js"></script>
    <script type="text/javascript" src="../scripts/calendar.js"></script>
    <script type="text/javascript">
        /*选项卡切换*/
        function ProductShowTabs(id, num) {
            var tab;
            for (var i = 0; i < num; i++) {
                tab = $("ctl00_workspace_tab" + i);
                if (i == id) {
                    $("ctl00_workspace_TabTitle" + i).className = "titlemouseover";
                    tab.style.display = 'block';
                }
                else {
                    $("ctl00_workspace_TabTitle" + i).className = "tabtitle";
                    tab.style.display = 'none';
                }

            }
        }

        /*添加相片*/
        function addFile() {
            var str = ' <table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0"><tr><td>本地图片：<input type="file" name="File" runat="server" /></td><td>描述：<input name="description" type="text" value="" maxlength="200" /></td></tr></table>';
            document.getElementById("MyFile").insertAdjacentHTML("beforeEnd", str);
        }
        /*删除相片*/
        function DelProAlbum(id) {
            var param = "Option=delAlbum&ID=" + id;
            var options = {
                method: 'post',
                parameters: param,
                onComplete:
            function (transport) {
                var retv = transport.responseText;
                document.getElementById("spanJSAlbum").innerHTML = retv;
            }
            }
            new Ajax.Request('product_info_edit.aspx', options);
        }
        /*商品保存*/
        function Detect() {
            var stateTime = document.getElementById("<%=txtFilingTime.ClientID %>").value;
            var endTime = document.getElementById("<%=txtDownTime.ClientID %>").value;
            if (Date.parse(stateTime.replace(/-/g, "/")) >= Date.parse(endTime.replace(/-/g, "/"))) {
                alert("温馨提示：下架时间小于上架时间，请重新输入！");
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">
    商品管理
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">
    添加或编辑商品
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td id="TabTitle0" class="tabtitle" onclick="ProductShowTabs(0,3)" runat="server">
                基本信息
            </td>
            <td id="TabTitle1" class="tabtitle" onclick="ProductShowTabs(1,3)" runat="server">
                介绍及图片
            </td>
            <td id="TabTitle2" class="tabtitle" onclick="ProductShowTabs(2,3)" runat="server">
                商品相册
            </td>
        </tr>
    </table>
    <asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
        <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
    </asp:Panel>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td colspan="9" style="border: 1px solid #bac9c6;">
                <table width="100%" style="background-color: #EBEDE8; height: 28px;">
                    <tr>
                        <td>
                            <span style="font-weight: bold; font-size: 12px">商品分类</span>
                            <asp:TextBox ID="txtProductClass" runat="server" Text="请选择商品分类" CssClass="inputCSS"></asp:TextBox>
                              <!--商品分类ID-->
                            <asp:HiddenField runat="server" ID="hfcid" />
                        </td>
                    </tr>
                </table>
                <!--基本信息-->
                <div id="tab0" runat="server" style="border-top: #EBEDE8 solid 10px;">
                    <table class="form_table_input" border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td class="form_table_input_info">
                                商品编号：
                            </td>
                            <td>
                                <asp:Label ID="lb_ProductNo" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td>
                              
                            </td>
                        </tr>
                        <tr>
                            <td class="form_table_input_info">
                                商品名称：
                            </td>
                            <td>
                                <asp:TextBox ID="txtProductName" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Panel ID="txtProductNameTip" runat="server">
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td class="form_table_input_info">
                                附加名称：
                            </td>
                            <td>
                                <asp:TextBox ID="txtProductAttachName" runat="server"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td class="form_table_input_info">
                                品牌：
                            </td>
                            <td>
                                <div id="divBrand">
                                    <asp:Literal ID="litProductBrand" runat="server"></asp:Literal>
                                </div>
                            </td>
                            <td>
                                <div class="msgNormal">
                                    选择商品所属品牌。</div>
                            </td>
                        </tr>
                        <tr>
                            <td class="form_table_input_info">
                                单位：
                            </td>
                            <td>
                                <asp:Literal ID="litUnit" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <div class="msgNormal">
                                    选择商品计量单位。</div>
                            </td>
                        </tr>
                        <tr>
                            <td class="form_table_input_info">
                                是否上架销售：
                            </td>
                            <td>
                                <asp:RadioButtonList ID="rblIsShelves" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="0" Text="否" onclick="IsFilingSell(0)"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="是" Selected="True" onclick="IsFilingSell(1)"></asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                <div class="msgNormal">
                                    选择是表示在前台页面显示该商品；否表示暂存数据库。</div>
                            </td>
                        </tr>
                        <tr id="trFilingTime" runat="server">
                            <td class="form_table_input_info">
                                上架时间：
                            </td>
                            <td>
                                <asp:TextBox ID="txtFilingTime" CssClass="date_input" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Panel ID="txtFilingTimeTip" runat="server">
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr id="trDownTime" runat="server">
                            <td class="form_table_input_info">
                                下架时间：
                            </td>
                            <td>
                                <asp:TextBox ID="txtDownTime" CssClass="date_input" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Panel ID="txtDownTimeTip" runat="server">
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td class="form_table_input_info">
                                市场价格：
                            </td>
                            <td>
                                <asp:TextBox ID="txtMarketPrice" CssClass="short_input" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Panel ID="txtMarketPriceTip" runat="server">
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td class="form_table_input_info">
                                商城价：
                            </td>
                            <td>
                                <asp:TextBox ID="txtCostPrice" CssClass="short_input" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Panel ID="txtCostPriceTip" runat="server">
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                    <table width="100%">
                        <tr>
                            <td colspan="3" style='font-weight: bold; height: 10px; background-color: #EBEDE8'>
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
                <!--介绍及图片-->
                <div id="tab1" runat="server" style="border-top: #EBEDE8 solid 10px; display: none">
                    <table class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
                        <tr>
                            <td class="form_table_input_info">
                                商品缩略图：
                            </td>
                            <td>
                                <asp:FileUpload ID="fuPic" runat="server" />
                            </td>
                            <td>
                                <div class="msgNormal">
                                    上传100px*100px大小的图,前台显示为最佳效果,如自动生成缩略图请在系统设置下的缩略图参数配置下进行配置缩略图的大小</div>
                            </td>
                        </tr>
                        <tr>
                            <td class="form_table_input_info">
                                商品简介：
                            </td>
                            <td>
                                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" MaxLength="1500"
                                    Height="100px" Width="323px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Panel ID="txtDescriptionTip" runat="server">
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td class="form_table_input_info">
                                详细介绍：
                            </td>
                            <td colspan="2">
                                <div class="msgNormal">
                                    输入信息对商品进行详细介绍</div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <FCKeditorV2:FCKeditor ID="txtContent" runat="server" Height="450px">
                                </FCKeditorV2:FCKeditor>
                            </td>
                        </tr>
                    </table>
                </div>
                <!--商品相册-->
                <div id="tab2" runat="server" style="border-top: #EBEDE8 solid 10px; display: none">
                    <table class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
                        <tr>
                            <td colspan="2" class="page_button">
                                <asp:HyperLink ID="HyperLink3" runat="server" CssClass="inputbutton" NavigateUrl="javascript:addFile()"
                                    Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'"
                                    onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">增加相片</asp:HyperLink>
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
                    <div id="MyFile">
                    </div>
                    <div id="divAlbum">
                        <table class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                    <span id="spanJSAlbum">
                                        <asp:Literal ID="litaAlbum" runat="server"></asp:Literal></span>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ContentPlaceHolderID="pagebottom" runat="server" ID="ContentBottom">
    <asp:Button ID="butSave" runat="server" CssClass="inputbutton" Text="保  存" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'"
        onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"
        OnClick="butSave_Click" OnClientClick="return Detect();" />
    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="inputbutton" Width="65px"
        Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'"
        onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返回列表</asp:HyperLink>
</asp:Content>
