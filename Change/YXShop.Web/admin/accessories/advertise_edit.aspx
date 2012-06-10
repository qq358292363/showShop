<%@ Page Language="C#" Debug="true" MasterPageFile="~/admin/admin_page.master" AutoEventWireup="true" CodeBehind="advertise_edit.aspx.cs" Inherits="ShowShop.Web.admin.accessories.advertise_edit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../style/validator.css" type="text/css" />
    <script type="text/javascript" src="../scripts/validate.js"></script>
    <script type="text/javascript" src="../scripts/calendar.js"></script>
    <link href="../style/admin.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">广告管理
 <asp:Button ID="Button2" runat="server" CssClass="inputbutton" onclick="lbtnSave_Click" Text="保存" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
    <asp:HyperLink ID="HyperLink1" NavigateUrl="~/admin/accessories/advertise_list.aspx" runat="server"  CssClass="inputbutton" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返  回</asp:HyperLink>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">
    <br />
    <br />
    选择添加广告的类型：
    <a href="advertise_edit.aspx?type=0" title="图片广告">图片</a>
    <a href="advertise_edit.aspx?type=1" title="动画广告">动画</a>
    <a href="advertise_edit.aspx?type=2" title="文本广告">文本</a>
    <a href="advertise_edit.aspx?type=3" title="幻灯片广告">幻灯片</a>
    
   
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">

<asp:Panel ID="pnlMsg" runat="server" Visible="false" CssClass="pnlReturnMessageErr">
    <asp:Literal ID="ltlMsg" runat="server"></asp:Literal>
</asp:Panel>

<table  class="form_table_input" border="0" width="100%" cellspacing="0" cellpadding="0">
    <tr>
        <td class="form_table_input_info">广告名称：</td>
            <td>
                <asp:TextBox ID="txtName" CssClass="long_input" runat="server"></asp:TextBox>
            </td> 
        <td>
            <asp:Panel ID="txtNameTip" runat="server"></asp:Panel>
        </td>    
   </tr> 
    
    <asp:Panel ID="pnlType1" runat="server" Width="100%">
        <tr>
            <td class="form_table_input_info">图片上传：</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:Button ID="btnFileUpload" runat="server" CausesValidation="False" Text="提交" Width="10%" onclick="btnFileUpload_Click" />
                <asp:Button ID="btnDelPic" runat="server" CausesValidation="False" Text="删除一张图" Width="24%" onclick="btnDelPic_Click" />
            </td>
            <td>
                <div class="msgNormal">请选择要上传的图片</div>
            </td>
        </tr>
      
        <tr>
            <td class="form_table_input_info">图片地址：</td>
             <td>
                 <asp:TextBox ID="txtUpspread1" runat="server" TextMode="MultiLine" Width="300px"    Enabled="False"></asp:TextBox>
            </td> 
            <td>
                <div class="msgNormal">自动生成，不可修改项。是图片上传后的地址</div>
            </td>    
        </tr>
     
        <tr>
            <td class="form_table_input_info">图片宽：</td>
            <td>
                <asp:TextBox ID="txtWidth1" runat="server" Width="43px" MaxLength="3"></asp:TextBox>
            </td> 
            <td>
                <asp:Panel ID="txtWidth1Tip" runat="server"></asp:Panel> 
            </td>    
        </tr>
     
        <tr>
            <td class="form_table_input_info">图片高：</td>
             <td>
                 <asp:TextBox ID="txtHeight1" runat="server" Width="43px" MaxLength="3"></asp:TextBox>
             </td> 
             <td>
                 <asp:Panel ID="txtHeight1Tip" runat="server"></asp:Panel>
             </td>    
        </tr>
     
        <tr>
            <td class="form_table_input_info">链接地址：</td>
            <td>
                <asp:TextBox ID="txtLinkAddress" runat="server" Width="50%" MaxLength="50">http://</asp:TextBox>
            </td> 
            <td>       
                <asp:Panel ID="txtLinkAddressTip" runat="server"></asp:Panel>
            </td>    
        </tr>
     
        <tr>
            <td class="form_table_input_info">链接提示：</td>
            <td>
                <asp:TextBox ID="txtHint1" runat="server" Width="50%" MaxLength="100"></asp:TextBox>
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
    </asp:Panel>
       
    <asp:Panel ID="pnlType2" runat="server" Width="100%"> 
        <tr>
            <td class="form_table_input_info">动画上传：</td>
            <td>
                <asp:FileUpload ID="FileUpload2" runat="server" />
            </td>
            <td>
                <div class="msgNormal">请选择你要上传的动画</div>
            </td>
      </tr>
     
        <tr>
            <td class="form_table_input_info">动画宽：</td>
            <td>
                <asp:TextBox ID="txtWidth2" runat="server" Width="43px" MaxLength="3"></asp:TextBox>
            </td> 
            <td>
                <asp:Panel ID="txtWidth2Tip" runat="server"></asp:Panel> 
            </td>    
       </tr>
     
        <tr>
            <td class="form_table_input_info">动画高：</td>
            <td>
                <asp:TextBox ID="txtHeight2" runat="server" Width="43px" MaxLength="3"></asp:TextBox>
             </td> 
             <td>
                 <asp:Panel ID="txtHeight2Tip" runat="server"></asp:Panel>
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
    </asp:Panel>
     
    <asp:Panel ID="pnlType3" runat="server" Width="100%" Visible="False">
        <tr>
            <td class="form_table_input_info">广告内容设置：</td>
            <td>
                <asp:TextBox ID="txtContent3" runat="server" TextMode="MultiLine" Width="300px"></asp:TextBox>
            </td> 
            <td>
                <asp:Panel ID="txtContent3Tip" runat="server"></asp:Panel>
            </td>    
         </tr>       
     </asp:Panel>
     
    <asp:Panel ID="pnlType4" runat="server" Width="100%" Visible="False">
        <tr>
            <td class="form_table_input_info">图片上传：</td>
            <td>
                <asp:FileUpload ID="FileUpload3" runat="server" />
                <asp:Button ID="btnUploadSlide" runat="server" CausesValidation="False" Text="提交" Width="10%" onclick="btnUploadSlide_Click" />
                <asp:Button ID="btnDelSlide" runat="server" CausesValidation="False"  Text="删除" Width="10%" onclick="btnDelSlide_Click" />
             </td>
             <td>
                 <div class="msgNormal">请选择你要上传的图片</div>
             </td>
        </tr>
             
        <tr>
            <td class="form_table_input_info">图片地址：</td>
            <td>
                <asp:TextBox ID="txtUpspread4" runat="server" TextMode="MultiLine"  Enabled="False"></asp:TextBox>
            </td>
            <td>
                <div class="msgNormal">自动生成，不可修改项。是图片上传后的地址</div> 
            </td>
        </tr>
             
        <tr>
            <td class="form_table_input_info">图片宽：</td>
            <td>
                <asp:TextBox ID="txtWidth4" runat="server"  MaxLength="3"></asp:TextBox>
            </td> 
             <td>
                   <asp:Panel ID="txtWidth4Tip" runat="server"></asp:Panel> 
             </td>    
        </tr>
     
        <tr>
            <td class="form_table_input_info">图片高：</td>
            <td>
                <asp:TextBox ID="txtHeight4" runat="server"  MaxLength="3"></asp:TextBox>
            </td> 
            <td>
                <asp:Panel ID="txtHeight4Tip" runat="server"></asp:Panel>
            </td>    
        </tr>
             
        <tr>
            <td class="form_table_input_info"> 链接地址：</td>
            <td>
                <asp:TextBox ID="txtLinkAddress4" runat="server" >http://</asp:TextBox>     
            </td>
            <td>
                <asp:Panel ID="txtLinkAddress4Tip" runat="server"></asp:Panel>
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
     </asp:Panel>
     
    <tr>
         <td class="form_table_input_info">广告权重：</td>
         <td>
              <asp:TextBox ID="txtPower" runat="server" MaxLength="5"></asp:TextBox>
         </td> 
         <td>
             <asp:Panel ID="txtPowerTip" runat="server"></asp:Panel>
         </td>    
    </tr> 
     
    <tr>
        <td class="form_table_input_info">统计浏览数：</td>
        <td>
             <asp:CheckBox ID="chxBorwsCount" runat="server" Text="是否统计" />
&nbsp;浏览数：<asp:TextBox ID="txtBrowseCount" runat="server" MaxLength="10" Width="60px"></asp:TextBox>
        </td> 
        <td>
            <asp:Panel ID="txtBrowseCountTip" runat="server"></asp:Panel>
        </td>    
    </tr> 
     
    <tr>
        <td class="form_table_input_info">统计点击数：</td>
        <td>
            <asp:CheckBox ID="chxClickCount" runat="server" Text="是否统计" />
&nbsp;点击数：<asp:TextBox ID="txtClickCount" runat="server" MaxLength="10" Width="60px"></asp:TextBox>
        </td> 
        <td>
            <asp:Panel ID="txtClickCountTip" runat="server"></asp:Panel>
        </td>    
    </tr> 
     
    <tr>
        <td class="form_table_input_info">广告过期时间：</td>
        <td>
            <asp:TextBox ID="dpStart" CssClass="date_input" runat="server"  Width="70"></asp:TextBox>
        </td> 
        <td>
            <div class="msgNormal">请选择广告的过期时间</div>
        </td>    
    </tr> 
     
    <tr>
        <td class="form_table_input_info">审核状态：</td>
        <td>
            <asp:CheckBox ID="chxExamine" runat="server" Text="审核通过" />
        </td> 
        <td>
            <div class="msgNormal">请选择是否通过审核</div>
        </td>    
    </tr> 
</table>
    
</asp:Content>
<asp:Content ContentPlaceHolderID="pagebottom" runat="server" ID="ContentBottom">
    <asp:Button ID="Button1" runat="server" CssClass="inputbutton" onclick="lbtnSave_Click" Text="保存" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'"/>
    <asp:HyperLink ID="returnLinkBottom" onclick="javascript:history.back()" runat="server"  CssClass="inputbutton" Width="65px" Height="24px" onMouseOver="javascript:document.getElementById(this.id).className='inputbutton_a'" onMouseOut="javascript:document.getElementById(this.id).className='inputbutton'">返  回</asp:HyperLink>
</asp:Content>
