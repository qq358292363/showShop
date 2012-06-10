<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productclass.aspx.cs" Inherits="ShowShop.Web.admin.include.productclass" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<title>选择商品分类</title>
<style  type="text/css">
.LableSelectItem 
{
	background-color:highlight;
	cursor: pointer;
	color: white;
	text-decoration: none;
}
.LableItem 
{
	cursor:pointer;
}
.SubItem 
{
	margin-left:15px;
}
.RootItem 
{
	margin-left:15px;
}
body 
{
	font-size:12px;
}
</style>
</head>
<script language="JavaScript" type="text/javascript" src="../scripts/prototype.js"></script>
<script language="JavaScript" type="text/javascript" src="../scripts/public.js"></script>

<body ondragstart="return false;" onselectstart="return false;">
    <form name="form1">
    商品分类：<input type="text" id="ClsName" readonly name="ClsName" style="width:50%" />&nbsp;<input type="button" class="form" name="Submit" value="确定" onclick="ReturnValue();" />
    &nbsp;<input type="button" class="form" name="Cancel" value="取消" onclick="CancelValue();" />
    <input type="hidden" id="ClsID" name="ClsID" value="" />
    <div id="Parent0" class="RootItem">
    栏目加载中...
    </div>
    </form>
</body>
</html>
<script language="javascript" type="text/javascript">
<!--
var SelectClass="";
function SwitchImg(ImgObj,ParentId){
	var ImgSrc="",SubImgSrc;
	ImgSrc=ImgObj.src;
	SubImgSrc=ImgSrc.substr(ImgSrc.length-5,12);
	
	if (SubImgSrc=="p.gif"){
		ImgObj.src=ImgObj.src.replace(SubImgSrc,"s.gif");
		ImgObj.alt="点击收起子栏目";
		SwitchSub(ParentId,true);
	}else{
		if (SubImgSrc=="s.gif"){
			ImgObj.src=ImgObj.src.replace(SubImgSrc,"p.gif");
			ImgObj.alt="点击展开子栏目";
			SwitchSub(ParentId,false);
		}else{
			return false;
		}
	}
}
function SwitchSub(ParentId,ShowFlag){
//	if ($("Parent"+ParentId).HasSub=="True"){
		if (ShowFlag){
			$("Parent"+ParentId).style.display="";
			if ($("Parent"+ParentId).innerHTML=="" || $("Parent"+ParentId).innerHTML=="栏目加载中..."){
				$("Parent"+ParentId).innerHTML="栏目加载中...";
				GetSubClass(ParentId);
			}
		}else{
			$("Parent"+ParentId).style.display="none";
		}
//	}
}
function SelectLable(Obj)
{
	var SelectedInfo="";
	if (SelectClass!=""){
		SelectedInfo=SelectClass.split("***");
		$(SelectedInfo[0]).className='LableItem';
	}
	Obj.className='LableSelectItem';
	SelectClass=Obj.id+"***"+Obj.innerText;
}
function GetRootClass(){
	GetSubClass("0");
}


function GetSubClass(ParentId){
	var url="productclass_ajax.aspx";
	var Action="ParentId="+ParentId;
	var myAjax = new Ajax.Request(
		url,
		{method:'get',
		parameters:Action,
		onComplete:GetSubClassOk
		}
		);
}
function GetSubClassOk(OriginalRequest){
	var ClassInfo;
	if (OriginalRequest.responseText!="" && OriginalRequest.responseText.indexOf("|||")>-1)
	{
		ClassInfo=OriginalRequest.responseText.split("|||");
		
		if (ClassInfo[0]=="<div id=\"ProList\">Succee"){
			$("Parent"+ClassInfo[1]).innerHTML=ClassInfo[2];
		}else{
			$("Parent"+ClassInfo[1]).innerHTML="<a href=\"点击重试\" onclick=\"$('Parent"+ClassInfo[1]+"').innerHTML='栏目加载中...';GetSubClass('"+ClassInfo[1]+"');return false;\">点击重试</a>";
		}
	}else{
		alert("读取栏目错误.\n请联系管理员.");
		return false;
	}
}



window.onload=GetRootClass;
//window.onunload=SetReturnValue;



function ListGo(Path,ParentPath)
{
	document.Templetslist.Path.value=Path;
	document.Templetslist.ParentPath.value=ParentPath;
	document.Templetslist.submit();
}
function sFiles(cid,cname)
{
    document.getElementById('ClsID').value = cid;
    document.getElementById('ClsName').value = cname;
//            var param = "Option=judge&cid=" + cid;
//            var options = 
//            { method: 'post',parameters: param,onComplete:
//                 function(transport)
//                 {
//                     var retv = transport.responseText;
//                     if(retv!="ok")
//                     {
//                         alert(retv);
//                         return false;
//                     }
//                     else
//                     {
//                        if(document.getElementById('ClsID').value=="")
//                        {
//                            document.getElementById('ClsID').value = cid;
//                        }
//                        else
//                        {
//                            var id=document.getElementById('ClsID').value.split(',');
//                            var IsAdd=true;
//                            for(var i=0;i<id.length;i++)
//                            {
//                                if(id[i]==cid)
//                                {
//                                   IsAdd=false;
//                                }
//                            } 
//                            if(IsAdd)
//                            {
//                                document.getElementById('ClsID').value =document.getElementById('ClsID').value+","+cid; 
//                            }
//                        }
//                        if(document.getElementById('ClsName').value == "")
//                        {
//                            document.getElementById('ClsName').value = cname;
//                        }
//                        else
//                        {
//                            var IsAdd=true;
//                            var Name=document.getElementById('ClsName').value.split(',');
//                            for(var i=0;i<Name.length;i++)
//                            {
//                                if(Name[i]==cname)
//                                {
//                                   IsAdd=false;
//                                }
//                            } 
//                            if(IsAdd)
//                            {
//                                document.getElementById('ClsName').value =document.getElementById('ClsName').value+","+cname;
//                            }
//                        }
//                     }
//                 }
//            }
//        new Ajax.Request('productclass.aspx', options);

}
function CancelValue()
{
    var cid = document.getElementById('ClsID').value;
	var cnm = document.getElementById('ClsName').value;
    document.getElementById('ClsID').value="";
    document.getElementById('ClsName').value="";
}
function ReturnValue()
{
	var cid = document.getElementById('ClsID').value;
	var cnm = document.getElementById('ClsName').value;
	var arryret = new Array(cid,cnm);
	parent.ReturnFun(arryret);
}
//-->
</script>