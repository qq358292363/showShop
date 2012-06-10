<%@ Page Language="C#" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="advertise_info_edit.aspx.cs" Inherits="ShowShop.Web.admin.accessories.advertise_info_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <link rel="stylesheet" href="../style/toolbar.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <script type="text/javascript" src="../scripts/public.js"></script>
    <script type="text/javascript" src="../scripts/calendar.js"></script>
   
    <script type="text/javascript" defer="defer">
        function ShowTabs(id,num)
        {
            var tab;
            for(var i=0;i<num;i++)
            {
                tab=$("ctl00_workspace_tab"+i);
                if(i==id)
                {
                    $("ctl00_workspace_TabTitle"+i).className="titlemouseover";
                    tab.style.display='block';
                }
                else
                {
                    $("ctl00_workspace_TabTitle"+i).className="tabtitle";
                    tab.style.display='none';
                }
            }
            $("<%=hfAdTypeId.ClientID %>").value=id;
        } 
        function ClientVer()
        {
            var typeId=$("<%=hfAdTypeId.ClientID %>").value;
            switch(typeId)
            {
                case "0":
                    if($("<%=txt_image_Add_Name.ClientID %>").value=="")
                    {
                        $("<%=txt_image_Add_NameTip.ClientID %>").innerHTML="广告名称不能为空";
                        $("<%=txt_image_Add_NameTip.ClientID %>").className="actionErr";
                        return false;
                    }
                    break;
                case "1":
                    if($("<%=txt_flash_Add_Name.ClientID %>").value=="")
                    {
                        $("<%=txt_flash_Add_NameTip.ClientID %>").innerHTML="广告名称不能为空";
                        $("<%=txt_flash_Add_NameTip.ClientID %>").className="actionErr";
                        return false;
                    }
                    break;
                case "2":
                    if($("<%=txt_text_Add_Name.ClientID %>").value=="")
                    {
                        $("<%=txt_text_Add_NameTip.ClientID %>").innerHTML="广告名称不能为空";
                        $("<%=txt_text_Add_NameTip.ClientID %>").className="actionErr";
                        return false;
                    }
                    break;
                case "3":
                    if($("<%=txt_Slide_Add_Name.ClientID %>").value=="")
                    {
                        $("<%=txt_Slide_Add_NameTip.ClientID %>").innerHTML="广告名称不能为空";
                        $("<%=txt_Slide_Add_NameTip.ClientID %>").className="actionErr";
                        return false;
                    }
                    break;
            }
        }
         /*添加图片*/
        function addFile()
        {   
            var str = ' <table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0"><tr><td><input type="file" name="File" runat="server" /></td></tr></table>'
            document.getElementById("MyFile").insertAdjacentHTML("beforeEnd",str);   
        }
        
        
        function DelImages(str,id)
        {
            var images=document.getElementById("hfImagesAddress").value;
            var param = "Option=DelImages&images="+images+"&ID="+id+"&Delpath=" + str;
            var options = 
            { method: 'post',parameters: param,onComplete:
                 function(transport)
                 {
                     var retv = transport.responseText;
                     if(retv!="")
                     {
                        document.getElementById("divImages").innerHTML=retv;
                     }
                 }
            }
            new Ajax.Request('advertise_info_edit.aspx', options);
        }       
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">广告管理
     <asp:Button ID="Button2" runat="server" CssClass="inputbutton" OnClientClick="return ClientVer();" onclick="lbtnSave_Click" Text="保存" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
     <asp:HyperLink ID="HyperLink1" NavigateUrl="~/admin/accessories/advertise_list.aspx" runat="server"  CssClass="inputbutton" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返  回</asp:HyperLink>
 </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server"> 
    编辑广告信息
    <asp:HiddenField ID="hfAdTypeId" runat="server" Value="0"/>
    <asp:HiddenField ID="hfAdId" runat="server"/>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td id="TabTitle0" class="titlemouseover" runat="server" onclick="ShowTabs(0,4)">图片</td>
            <td id="TabTitle1" class="tabtitle" runat="server" onclick="ShowTabs(1,4)">动画</td>
            <td id="TabTitle2" class="tabtitle" runat="server" onclick="ShowTabs(2,4)">文本</td>
            <td id="TabTitle3" class="tabtitle" runat="server" onclick="ShowTabs(3,4)">幻灯片</td>
        </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td colspan="9" style="border: 1px solid #bac9c6;">
            <asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
                <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
            </asp:Panel>
    <!--图片-->
    <div id="tab0" runat="server">
                <table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="form_table_input_info">广告名称：</td>
                            <td>
                                <asp:TextBox ID="txt_image_Add_Name" CssClass="long_input" runat="server"></asp:TextBox>
                            </td> 
                        <td>
                            <asp:Panel ID="txt_image_Add_NameTip" runat="server"></asp:Panel>
                        </td>    
                    </tr> 
                    <tr>
                        <td class="form_table_input_info">图片上传：</td>
                        <td>
                            <asp:FileUpload ID="fu_images" runat="server" />
                        </td>
                        <td>
                            <div class="msgNormal">请选择要上传的图片</div>
                        </td>
                    </tr>
                  
                    <tr>
                        <td class="form_table_input_info">图片宽：</td>
                        <td>
                            <asp:TextBox ID="txt_images_Width" runat="server" Width="43px" MaxLength="4"  
                        onkeyup="value=value.replace(/[^\d]/g,'') " 
                        onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" ></asp:TextBox>
                        </td> 
                        <td>
                            &nbsp;
                        </td>    
                    </tr>
                 
                    <tr>
                        <td class="form_table_input_info">图片高：</td>
                         <td>
                             <asp:TextBox ID="txt_images_Height" runat="server" Width="43px" MaxLength="4" onkeyup="value=value.replace(/[^\d]/g,'') " 
                        onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" ></asp:TextBox>
                         </td> 
                         <td>
                             &nbsp;
                         </td>    
                    </tr>
                 
                    <tr>
                        <td class="form_table_input_info">链接地址：</td>
                        <td>
                            <asp:TextBox ID="txt_images_LinkAddress" runat="server" Width="50%" MaxLength="50">http://</asp:TextBox>
                        </td> 
                        <td>       
                            &nbsp;
                        </td>    
                    </tr>
                 
                    <tr>
                        <td class="form_table_input_info">链接提示：</td>
                        <td>
                            <asp:TextBox ID="txt_images_Hint" runat="server" Width="50%" MaxLength="100"></asp:TextBox>
                        </td> 
                        <td>
                            <div class="msgNormal">请输入广告的链接提示</div>
                        </td>    
                     </tr>
                 
                    <tr>
                        <td class="form_table_input_info">链接目标：</td>
                        <td>
                            <asp:RadioButtonList ID="rdolstTarget1"  RepeatLayout="Flow"  runat="server" RepeatDirection="Horizontal" Width="171px">
                                <asp:ListItem Text="新窗口" Value="0"  Selected="True" ></asp:ListItem>
                                <asp:ListItem Text="原窗口" Value="1"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td> 
                        <td>
                            <div class="msgNormal">请选择点击广告后要链接的目标方式</div>
                        </td>    
                    </tr>
                 
                    <tr>
                        <td class="form_table_input_info">广告简介：</td>
                        <td>
                             <asp:TextBox ID="txtContent1" runat="server" TextMode="MultiLine" Width="300px"></asp:TextBox>
                        </td> 
                        <td>
                             <div class="msgNormal">请输入简短的文字作为广告的介绍</div>
                        </td>    
                    </tr> 
                    <tr>
                         <td class="form_table_input_info">广告权重：</td>
                         <td>
                              <asp:TextBox ID="txt_images_Power" runat="server" MaxLength="5"  
                        onkeyup="value=value.replace(/[^\d]/g,'') " 
                        onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" ></asp:TextBox>
                         </td> 
                         <td>
                             &nbsp;
                         </td>    
                    </tr> 
                     
                    <tr>
                        <td class="form_table_input_info">统计浏览数：</td>
                        <td>
                             <asp:CheckBox ID="chx_images_BorwsCount" runat="server" Text="是否统计" />
                &nbsp;浏览数：<asp:TextBox ID="txt_images_BrowseCount" runat="server" MaxLength="10" Width="60px"  
                        onkeyup="value=value.replace(/[^\d]/g,'') " 
                        onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" ></asp:TextBox>
                        </td> 
                        <td>
                            &nbsp;
                        </td>    
                    </tr> 
                     
                    <tr>
                        <td class="form_table_input_info">统计点击数：</td>
                        <td>
                            <asp:CheckBox ID="chx_images_ClickCount" runat="server" Text="是否统计" />
                &nbsp;点击数：<asp:TextBox ID="txt_images_ClickCount" runat="server" MaxLength="10" Width="60px"  
                        onkeyup="value=value.replace(/[^\d]/g,'') " 
                        onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" ></asp:TextBox>
                        </td> 
                        <td>
                            &nbsp;
                        </td>    
                    </tr> 
                     
                    <tr>
                        <td class="form_table_input_info">广告过期时间：</td>
                        <td>
                            <asp:TextBox ID="dpStart_images" CssClass="date_input" runat="server"  Width="70"></asp:TextBox>
                        </td> 
                        <td>
                            <div class="msgNormal">请选择广告的过期时间</div>
                        </td>    
                    </tr> 
                     
                    <tr>
                        <td class="form_table_input_info">审核状态：</td>
                        <td>
                            <asp:CheckBox ID="chx_images_Examine" runat="server" Text="审核通过" />
                        </td> 
                        <td>
                            <div class="msgNormal">请选择是否通过审核</div>
                        </td>    
                    </tr> 
		         </table>
            </div>
    <!--动画-->
    <div id="tab1" class="tabs" runat="server">
            <table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
                <tr>
                    <td class="form_table_input_info">广告名称：</td>
                        <td>
                            <asp:TextBox ID="txt_flash_Add_Name" CssClass="long_input" runat="server"></asp:TextBox>
                        </td> 
                    <td>
                        <asp:Panel ID="txt_flash_Add_NameTip" runat="server"></asp:Panel>
                    </td>    
                </tr> 
                <tr>
                    <td class="form_table_input_info">动画上传：</td>
                    <td>
                        <asp:FileUpload ID="fu_flash" runat="server" />
                    </td>
                    <td>
                        <div class="msgNormal">请选择你要上传的动画</div>
                    </td>
                  </tr>
                 
                    <tr>
                        <td class="form_table_input_info">动画宽：</td>
                        <td>
                            <asp:TextBox ID="txt_flash_Width" runat="server" Width="43px" MaxLength="4"  
                        onkeyup="value=value.replace(/[^\d]/g,'') " 
                        onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" ></asp:TextBox>
                        </td> 
                        <td>
                            &nbsp;
                        </td>    
                   </tr>
                 
                    <tr>
                        <td class="form_table_input_info">动画高：</td>
                        <td>
                            <asp:TextBox ID="txt_flash_Height" runat="server" Width="43px" MaxLength="4"  
                        onkeyup="value=value.replace(/[^\d]/g,'') " 
                        onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" ></asp:TextBox>
                         </td> 
                         <td>
                             &nbsp;
                         </td>    
                    </tr>
                 
                    <tr>
                        <td class="form_table_input_info">背景透明：</td>
                        <td>
                             <asp:RadioButtonList ID="rlistTarget2" runat="server" RepeatDirection="Horizontal" Width="171px">
                                <asp:ListItem Text="不透明" Value="0"  Selected="True" ></asp:ListItem>
                                <asp:ListItem Text="透明" Value="1"></asp:ListItem>
                             </asp:RadioButtonList>
                        </td> 
                        <td>
                             <div class="msgNormal">请选择背景是否透明</div>
                        </td>    
                    </tr>
                    <tr>
                         <td class="form_table_input_info">广告权重：</td>
                         <td>
                              <asp:TextBox ID="txt_flash_Power" runat="server" MaxLength="5"  
                        onkeyup="value=value.replace(/[^\d]/g,'') " 
                        onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" ></asp:TextBox>
                         </td> 
                         <td>
                             &nbsp;
                         </td>    
                    </tr> 
                     
                    <tr>
                        <td class="form_table_input_info">统计浏览数：</td>
                        <td>
                             <asp:CheckBox ID="chx_flash_BorwsCount" runat="server" Text="是否统计" />
                &nbsp;浏览数：<asp:TextBox ID="txt_flash_BrowseCount" runat="server" MaxLength="10" Width="60px"  
                        onkeyup="value=value.replace(/[^\d]/g,'') " 
                        onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" ></asp:TextBox>
                        </td> 
                        <td>
                            &nbsp;
                        </td>    
                    </tr> 
                     
                    <tr>
                        <td class="form_table_input_info">统计点击数：</td>
                        <td>
                            <asp:CheckBox ID="chx_flash_ClickCount" runat="server" Text="是否统计" />
                &nbsp;点击数：<asp:TextBox ID="txt_flash_ClickCount" runat="server" MaxLength="10" Width="60px"  
                        onkeyup="value=value.replace(/[^\d]/g,'') " 
                        onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" ></asp:TextBox>
                        </td> 
                        <td>
                            &nbsp;
                        </td>    
                    </tr> 
                     
                    <tr>
                        <td class="form_table_input_info">广告过期时间：</td>
                        <td>
                            <asp:TextBox ID="dpStart_flash" CssClass="date_input" runat="server"  Width="70"></asp:TextBox>
                        </td> 
                        <td>
                            <div class="msgNormal">请选择广告的过期时间</div>
                        </td>    
                    </tr> 
                     
                    <tr>
                        <td class="form_table_input_info">审核状态：</td>
                        <td>
                            <asp:CheckBox ID="chx_flash_Examine" runat="server" Text="审核通过" />
                        </td> 
                        <td>
                            <div class="msgNormal">请选择是否通过审核</div>
                        </td>    
                    </tr> 
		         </table>
    
    </div>
    <!--文本-->
    <div id="tab2" class="tabs" runat="server">
                <table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="form_table_input_info">广告名称：</td>
                            <td>
                                <asp:TextBox ID="txt_text_Add_Name" CssClass="long_input" runat="server"></asp:TextBox>
                            </td> 
                        <td>
                            <asp:Panel ID="txt_text_Add_NameTip" runat="server"></asp:Panel>
                        </td>    
                    </tr> 
                    <tr>
                        <td class="form_table_input_info">广告内容设置：</td>
                        <td>
                            <asp:TextBox ID="txtContent3" runat="server" TextMode="MultiLine" Width="300px"></asp:TextBox>
                        </td> 
                        <td>
                            <asp:Panel ID="txtContent3Tip" runat="server"></asp:Panel>
                        </td>    
                     </tr>  
                    <tr>
                         <td class="form_table_input_info">广告权重：</td>
                         <td>
                              <asp:TextBox ID="txt_text_Power" runat="server" MaxLength="5"  
                        onkeyup="value=value.replace(/[^\d]/g,'') " 
                        onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" ></asp:TextBox>
                         </td> 
                         <td>
                             &nbsp;
                         </td>    
                    </tr> 
                     
                    <tr>
                        <td class="form_table_input_info">统计浏览数：</td>
                        <td>
                             <asp:CheckBox ID="chx_text_BorwsCount" runat="server" Text="是否统计" />
                &nbsp;浏览数：<asp:TextBox ID="txt_text_BrowseCount" runat="server" MaxLength="10" Width="60px"  
                        onkeyup="value=value.replace(/[^\d]/g,'') " 
                        onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" ></asp:TextBox>
                        </td> 
                        <td>
                            &nbsp;
                        </td>    
                    </tr> 
                     
                    <tr>
                        <td class="form_table_input_info">统计点击数：</td>
                        <td>
                            <asp:CheckBox ID="chx_text_ClickCount" runat="server" Text="是否统计" />
                &nbsp;点击数：<asp:TextBox ID="txt_text_ClickCount" runat="server" MaxLength="10" Width="60px"  
                        onkeyup="value=value.replace(/[^\d]/g,'') " 
                        onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" ></asp:TextBox>
                        </td> 
                        <td>
                            &nbsp;
                        </td>    
                    </tr> 
                     
                    <tr>
                        <td class="form_table_input_info">广告过期时间：</td>
                        <td>
                            <asp:TextBox ID="dpStart_text" CssClass="date_input" runat="server"  Width="70"></asp:TextBox>
                        </td> 
                        <td>
                            <div class="msgNormal">请选择广告的过期时间</div>
                        </td>    
                    </tr> 
                     
                    <tr>
                        <td class="form_table_input_info">审核状态：</td>
                        <td>
                            <asp:CheckBox ID="chx_text_Examine" runat="server" Text="审核通过" />
                        </td> 
                        <td>
                            <div class="msgNormal">请选择是否通过审核</div>
                        </td>    
                    </tr> 
		         </table>
		     </div>
    
            <!--幻灯片-->
            <div id="tab3" class="tabs" runat="server">
                <table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="form_table_input_info">广告名称：</td>
                            <td>
                                <asp:TextBox ID="txt_Slide_Add_Name" CssClass="long_input" runat="server"></asp:TextBox>
                            </td> 
                        <td>
                            <asp:Panel ID="txt_Slide_Add_NameTip" runat="server"></asp:Panel>
                        </td>    
                    </tr> 
                    <tr>
                        <td class="form_table_input_info">图片上传：</td>
                        <td>
                             <input id="File1" type="file" name="File" runat="server" />
                            <input onclick="addFile()" type="button" value="+" title="点击新增图片"/>
                            <div id="MyFile"></div>
                         </td>
                         <td>
                             <div class="msgNormal">请选择你要上传的图片</div>
                         </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                              <div id="divImages"><asp:Literal ID="litaAlbum" runat="server"></asp:Literal></div>
                        </td>
                    </tr>
                    <tr>
                        <td class="form_table_input_info">图片宽：</td>
                        <td>
                            <asp:TextBox ID="txt_Slide_Width" runat="server" Width="43px" MaxLength="4"  
                        onkeyup="value=value.replace(/[^\d]/g,'') " 
                        onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" ></asp:TextBox>
                        </td> 
                         <td>
                               &nbsp;
                         </td>    
                    </tr>
                 
                    <tr>
                        <td class="form_table_input_info">图片高：</td>
                        <td>
                            <asp:TextBox ID="txt_Slide_Height" runat="server" Width="43px" MaxLength="4"  
                        onkeyup="value=value.replace(/[^\d]/g,'') " 
                        onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" ></asp:TextBox>
                        </td> 
                        <td>
                            &nbsp;
                        </td>    
                    </tr>
                         
                    <tr>
                        <td class="form_table_input_info"> 链接地址：</td>
                        <td>
                            <asp:TextBox ID="txtLinkAddress4" runat="server" >http://</asp:TextBox>     
                        </td>
                        <td>
                            &nbsp;
                        </td> 
                    </tr>
                         
                    <tr>
                        <td class="form_table_input_info">链接提示：</td>
                        <td>
                            <asp:TextBox ID="txtHint4" runat="server"  MaxLength="100"></asp:TextBox>
                        </td>
                        <td>
                            <div class="msgNormal">请输入广告的链接提示</div>
                        </td> 
                    </tr>
                         
                    <tr>
                        <td class="form_table_input_info">链接目标：</td>
                        <td>
                            <asp:RadioButtonList ID="rlistTarget4" RepeatLayout="Flow" runat="server" RepeatDirection="Horizontal" Width="171px">
                                <asp:ListItem Text="新窗口" Value="0"  Selected="True" ></asp:ListItem>
                                <asp:ListItem Text="原窗口" Value="1"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td>
                            &nbsp;    
                        </td> 
                   </tr>
                     
                    <tr>
                        <td class="form_table_input_info">广告简介：</td>
                        <td>
                            <asp:TextBox ID="txtContent4" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </td>
                        <td>
                           <div class="msgNormal">请输入简短的文字作为广告的介绍</div>      
                        </td> 
                   </tr>
                    <tr>
                         <td class="form_table_input_info">广告权重：</td>
                         <td>
                              <asp:TextBox ID="txt_Slide_Power" runat="server" MaxLength="5"  
                        onkeyup="value=value.replace(/[^\d]/g,'') " 
                        onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" ></asp:TextBox>
                         </td> 
                         <td>
                             &nbsp;
                         </td>    
                    </tr> 
                     
                    <tr>
                        <td class="form_table_input_info">统计浏览数：</td>
                        <td>
                             <asp:CheckBox ID="chx_Slide_BorwsCount" runat="server" Text="是否统计" />
                &nbsp;浏览数：<asp:TextBox ID="txt_Slide_BrowseCount" runat="server" MaxLength="10" Width="60px"  
                        onkeyup="value=value.replace(/[^\d]/g,'') " 
                        onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" ></asp:TextBox>
                        </td> 
                        <td>
                            &nbsp;
                        </td>    
                    </tr> 
                     
                    <tr>
                        <td class="form_table_input_info">统计点击数：</td>
                        <td>
                            <asp:CheckBox ID="chx_Slide_ClickCount" runat="server" Text="是否统计" />
                &nbsp;点击数：<asp:TextBox ID="txt_Slide_ClickCount" runat="server" MaxLength="10" Width="60px"  
                        onkeyup="value=value.replace(/[^\d]/g,'') " 
                        onbeforepaste="clipboardData.setData('text',clipboardData.getData('text').replace(/[^\d]/g,''))" ></asp:TextBox>
                        </td> 
                        <td>
                            &nbsp;
                        </td>    
                    </tr> 
                     
                    <tr>
                        <td class="form_table_input_info">广告过期时间：</td>
                        <td>
                            <asp:TextBox ID="dpStart_Slide" CssClass="date_input" runat="server"  Width="70"></asp:TextBox>
                        </td> 
                        <td>
                            <div class="msgNormal">请选择广告的过期时间</div>
                        </td>    
                    </tr> 
                     
                    <tr>
                        <td class="form_table_input_info">审核状态：</td>
                        <td>
                            <asp:CheckBox ID="chx_Slide_Examine" runat="server" Text="审核通过" />
                        </td> 
                        <td>
                            <div class="msgNormal">请选择是否通过审核</div>
                        </td>    
                    </tr> 
		         </table>
              </div>
            </td>
        </tr>
    </table>

</asp:Content>
<asp:Content ContentPlaceHolderID="pagebottom" runat="server" ID="ContentBottom">
    <asp:Button ID="Button1" runat="server" CssClass="inputbutton" OnClientClick="return ClientVer();" onclick="lbtnSave_Click" Text="保存" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
    <asp:HyperLink ID="returnLinkBottom" onclick="javascript:history.back()" runat="server"  CssClass="inputbutton" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返  回</asp:HyperLink>
</asp:Content>