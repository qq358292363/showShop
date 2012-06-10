<%@ Page Language="C#" MasterPageFile="../admin_page.master" AutoEventWireup="true" CodeBehind="site_sysinfo.aspx.cs" Inherits="ShowShop.Web.admin.systeminfo.site_sysinfo" Title="系统信息" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script type="text/javascript" src="../scripts/ajax.js"></script>
<script type="text/javascript" src="../scripts/validate.js"></script>
<script type="text/javascript">
        function CheckObject()
        {
            if(!IsNull($("txtObjectName")))
            {
                alert('请输入组件名称');
                return false;
            }
            
            var objectName=$("txtObjectName").value;
            var url = '../plugin/check_object.aspx?objName='+encodeURIComponent(objectName);
            GetStringInfo(url,'lblCheckInfo');
        }
        
        function UpdateThePacket()
        {
            var isUpdateTemlete=0;
            if(document.getElementById("UpdateTemlete").checked)
            {
                isUpdateTemlete=1;
            }
            
            document.getElementById("ctl00_workspace_lbLatestVesion").innerHTML="程序正在更新，请稍后....";
            var url = '../../filehandle/updatepacket.aspx?UpdateTemlete='+isUpdateTemlete+'&fresh=';
            var myAjax = new Ajax.Request(
             url+Math.random(),
            {
                 method: 'post',
                 onComplete: showResponse
             });
        }
        function showResponse(originalRequest)
        {        
            document.getElementById("ctl00_workspace_lbLatestVesion").innerHTML = originalRequest.responseText;
            alert(document.getElementById("ctl00_workspace_lbLatestVesion").innerHTML );
            window.location.reload();
        }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="pagetitle" runat="server">系统信息</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="pageinfo" runat="server">系统的基本配置信息</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="workspace" runat="server">
    <table border="0" width="100%" cellpadding="0" cellspacing="0">
	    <tr>
		    <td width="50%">
		        <table width="100%"  cellspacing="0" cellpadding="0" border="1" bordercolorlight="#B4C9C6" bordercolordark="#FFFFFF">
                    <caption><br>版本信息</caption>
                    <tr>
                        <td class="form_ctrl_row">
                            <img src="../images/point.gif" alt=""/>&nbsp;&nbsp;您正在使用YxShop搭建商城，当前版本是：
                            <a href="http://www.yx-shop.cn " target="_parent"><asp:Label ID="lbVesion" runat="server"></asp:Label></a>
                        </td>
                    </tr>
                    <tr>
                        <td class="form_ctrl_row">
                            <img src="../images/point.gif" alt=""/>&nbsp;&nbsp;易想官方最新版本是：
                            <asp:Label ID="lbLatestVesion" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="form_ctrl_row">
                            易想：中国行业网站开发第一品牌 ，<a href="http://www.changehope.com" target="_top">进入易想官方</a>
                        </td>
                    </tr>
		        </table>
		    
		    </td>
		    <td width="50%">
		        <table width="100%"  cellspacing="0" cellpadding="0" border="1" bordercolorlight="#B4C9C6" bordercolordark="#FFFFFF">
                    <caption><br>系统信息</caption>
                    <tr>
                        <td class="form_ctrl_row">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="form_ctrl_row">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="form_ctrl_row">&nbsp;</td>
                    </tr>
		        </table>
		    </td>
	    </tr>
	    <tr>
		    <td>
		        <table width="100%"  cellspacing="0" cellpadding="0" border="1" bordercolorlight="#B4C9C6" bordercolordark="#FFFFFF">
		            <caption><br>订单统计信息</caption>
                    <tr>
                        <td class="form_text_row">待发货订单：</td>
                        <td class="form_ctrl_row">&nbsp;</td>

                    </tr>
                    <tr>
                        <td class="form_text_row">未确认订单：</td>
                        <td class="form_ctrl_row">&nbsp;</td>

                    </tr>
                    <tr>
                        <td class="form_text_row"> 待支付订单：</td>
                        <td class="form_ctrl_row">&nbsp;</td>

                    </tr>
                    <tr>
                        <td class="form_text_row">已成交订单：</td>
                        <td class="form_ctrl_row">&nbsp;</td>
                    </tr>
    			
			         <tr>
			               <td class="form_text_row">新缺货登记：</td>
			               <td class="form_ctrl_row">&nbsp;</td>

			         </tr>
        			
			         <tr>
			             <td width="30%"></td>
			             <td width="70%"></td>
			         </tr>
		         </table>
		    </td>
		    <td>
		        <table width="100%"  cellspacing="0" cellpadding="0" border="1" bordercolorlight="#B4C9C6" bordercolordark="#FFFFFF">
		            <caption><br>实体商品统计信息</caption>
                    <tr>
                        <td class="form_text_row">商品总数：</td>
                        <td class="form_ctrl_row">&nbsp;</td>

                    </tr>
                    <tr>
                        <td class="form_text_row">库存警告商品数：</td>
                        <td class="form_ctrl_row">&nbsp;</td>

                    </tr>
                    <tr>
                        <td class="form_text_row">新品推荐数：</td>
                        <td class="form_ctrl_row">&nbsp;</td>

                    </tr>
                    <tr>
                        <td class="form_text_row">热销商品数：</td>
                        <td class="form_ctrl_row">&nbsp;</td>
                    </tr>
    			
			         <tr>
			               <td class="form_text_row">促销商品数：</td>
			               <td class="form_ctrl_row">&nbsp;</td>

			         </tr>
        			
			         <tr>
			             <td width="30%"></td>
			             <td width="70%"></td>
			         </tr>
		         </table>
		    </td>
	    </tr>
	    
	    <tr>
		    <td>
		        <table width="100%"  cellspacing="0" cellpadding="0" border="1" bordercolorlight="#B4C9C6" bordercolordark="#FFFFFF">
		            <caption><br>.NET服务器常用参数</caption>
                    <tr>
                        <td class="form_text_row">服务器名称：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="ltlServerName" runat="server"></asp:Literal></td>

                    </tr>
                    <tr>
                        <td class="form_text_row">服务器IP地址：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="ltlServerIP" runat="server"></asp:Literal></td>

                    </tr>
                    <tr>
                        <td class="form_text_row">服务器域名：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="ltlServerDomain" runat="server"></asp:Literal></td>

                    </tr>
                    <tr>
                        <td class="form_text_row">HTTP访问端口：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="ltlServerPort" runat="server"></asp:Literal></td>
                    </tr>
			         <tr>
			               <td class="form_text_row">服务器本机时间：</td>
			               <td class="form_ctrl_row"><asp:Literal ID="ltlServerTime" runat="server"></asp:Literal></td>
			         </tr>
        			<tr>
			               <td class="form_text_row">服务器IIS版本：</td>
			               <td class="form_ctrl_row"><asp:Literal ID="ltlServerIISVersion" runat="server"></asp:Literal></td>

			         </tr>
			         <tr>
			               <td class="form_text_row">服务端脚本超时：</td>
			               <td class="form_ctrl_row"><asp:Literal ID="ltlServerOvertime" runat="server"></asp:Literal></td>
			         </tr>
			         <tr>
			               <td class="form_text_row">虚拟目录绝对路径：</td>
			               <td class="form_ctrl_row"><asp:Literal ID="ltlServerPath" runat="server"></asp:Literal></td>
			         </tr>
			         <tr>
			               <td class="form_text_row"> .NET解释引擎版本：</td>
			               <td class="form_ctrl_row"><asp:Literal ID="ltlServerNetVersion" runat="server"></asp:Literal></td>
			         </tr>
			         <tr>
			               <td class="form_text_row"> 服务器操作系统：</td>
			               <td class="form_ctrl_row"><asp:Literal ID="ltlOSVersion" runat="server"></asp:Literal></td>
			         </tr>
			         <tr>
			             <td width="30%"></td>
			             <td width="70%"></td>
			         </tr>
		         </table>
		    </td>
		    <td>
		        <table width="100%"  cellspacing="0" cellpadding="0" border="1" bordercolorlight="#B4C9C6" bordercolordark="#FFFFFF">
		            <caption><br>.NET服务器常用组件</caption>
                    <tr>
                        <td class="form_text_row">Access数据库组件：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="ltlAccess" runat="server"></asp:Literal></td>

                    </tr>
                    <tr>
                        <td class="form_text_row">FSO文件操作组件：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="ltlFSO" runat="server"></asp:Literal></td>

                    </tr>
                    <tr>
                        <td class="form_text_row">CDONTS邮件发送组件：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="ltlCDONTS" runat="server"></asp:Literal></td>

                    </tr>
                    <tr>
                        <td class="form_text_row">JMAIL邮件发送组件：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="ltlJMAIL" runat="server"></asp:Literal></td>
                    </tr>
			         <tr>
			               <td class="form_text_row">ASPEmail邮件发送组件：</td>
			               <td class="form_ctrl_row"><asp:Literal ID="ltlASPMail" runat="server"></asp:Literal></td>
			         </tr>
        			<tr>
			               <td class="form_text_row">LyfUpload上传组件：</td>
			               <td class="form_ctrl_row"><asp:Literal ID="ltlLyfUpload" runat="server"></asp:Literal></td>

			         </tr>
			         <tr>
			               <td class="form_text_row">ASPUpload上传组件：</td>
			               <td class="form_ctrl_row"><asp:Literal ID="ltlASPUpload" runat="server"></asp:Literal></td>
			         </tr>
			         <tr>
			               <td class="form_text_row">ASPCN上传组件：</td>
			               <td class="form_ctrl_row"><asp:Literal ID="ltlASPCN" runat="server"></asp:Literal></td>
			         </tr>
			         <tr>
			               <td class="form_text_row" rowspan="2"> 其他组件信息查询</td>
			               <td class="form_ctrl_row"><span id="lblCheckInfo"></span>&nbsp;</td>
			         </tr>
			         <tr>
			               <td class="form_ctrl_row">组件名称：<input type="text" name="txtObjectName" id="txtObjectName" value=""/>
                               <input type="button" name="btnCheckObject" value="检 测" id="btnCheckObject" class="button_blue" onclick="CheckObject()" />
                           </td>
			         </tr>
			         <tr>
			             <td width="30%"></td>
			             <td width="70%"></td>
			         </tr>
		         </table>
		    
		    </td>
	    </tr>
	    
	    
	     <tr>
		    <td>
		        <table width="100%"  cellspacing="0" cellpadding="0" border="1" bordercolorlight="#B4C9C6" bordercolordark="#FFFFFF">
		            <caption><br>当前虚拟目录资源状况</caption>
                    <tr>
                        <td class="form_text_row">系统Session总数：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="ltlSessionCount" runat="server"></asp:Literal>&nbsp;</td>

                    </tr>
                    <tr>
                        <td class="form_text_row">系统Application总数：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="ltlApplactionCount" runat="server"></asp:Literal>&nbsp;</td>

                    </tr>
        			
			        <tr>
			             <td width="30%"></td>
			             <td width="70%"></td>
			         </tr>
		         </table>
		    </td>
		    <td>
		        <table width="100%"  cellspacing="0" cellpadding="0" border="1" bordercolorlight="#B4C9C6" bordercolordark="#FFFFFF">
		            <caption><br>系统性能测定</caption>
                    <tr>
                        <td class="form_text_row">服务器CPU数目：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="ltlCPUCount" runat="server"></asp:Literal>&nbsp;</td>

                    </tr>
                    <tr>
                        <td class="form_text_row">执行后台数据时间：</td>
                        <td class="form_ctrl_row"><asp:Literal ID="ltlTimes" runat="server"></asp:Literal>&nbsp;</td>

                    </tr>
        			
			        <tr>
			             <td width="30%"></td>
			             <td width="70%"></td>
			         </tr>
		         </table>
		    </td>
	    </tr>
</table>
</asp:Content>
