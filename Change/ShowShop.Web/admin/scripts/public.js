/*浮动在页面上方的页面*/
function ShowImg(control)
{
    $(control.id+"Img").src=control.value;
}


function getRootPath(){
var strFullPath=window.document.location.href;
var strPath=window.document.location.pathname;
var pos=strFullPath.indexOf(strPath);
var prePath=strFullPath.substring(0,pos);
var postPath=strPath.substring(0,strPath.substr(1).indexOf('/')+1);
return(prePath+postPath);
}



function selectFile(type,obj,height,width,dummypaht)
{
    var ShowObj = obj;
    if(isArray(obj) && obj.length > 1)
        ShowObj = obj[1];
    showfDiv(ShowObj,"loading...",width);
    LastSelectObj = obj;
	var  options={  
			           method:'get',  
			           parameters:"widths="+width+"&heights="+ height,  
			           onComplete:function(transport)
				        {  
					        var returnvalue=transport.responseText;
					        if (returnvalue.indexOf("??")>-1)
						        showfDiv(ShowObj,'Error',width);
					        else
						        var tempstr=returnvalue;
						        showfDiv(ShowObj,tempstr,width);
				        }  
				   }; 
	var arrtype=type.split("|")[0]
	
    switch(arrtype)
    {
        case "Product_info_class":
            new  Ajax.Request(dummypaht+'admin/include/iframe.aspx?FileType=Product_info_class',options);
            break;
        case "Productclass":
            new  Ajax.Request(dummypaht+'admin/include/iframe.aspx?FileType=Productclass',options);
            break;
        case "Label_Url_Productclass":
            new  Ajax.Request(dummypaht+'admin/include/iframe.aspx?FileType=Label_Url_Productclass',options);
            break;  
        case "productclassone":
            new  Ajax.Request(dummypaht+'admin/include/iframe.aspx?FileType=productclassone',options);
            break;
        case "Random_Productclass"://任意选对商品分类
            new  Ajax.Request(dummypaht+'admin/include/iframe.aspx?FileType=Random_Productclass',options);
            break;
        case "Area":
            new  Ajax.Request(dummypaht+'admin/include/iframe.aspx?FileType=Area',options);
            break;
        case "Product":
            new  Ajax.Request(dummypaht+'admin/include/iframe.aspx?FileType=Product',options);
            break;
        case "OrderCardProduct":
            new  Ajax.Request(dummypaht+'admin/include/iframe.aspx?FileType=OrderCardProduct',options);
            break;
        case "integratepurchasProduct":
            new  Ajax.Request(dummypaht+'admin/include/iframe.aspx?FileType=integratepurchasProduct',options);
            break;
        case "AuctionProduct":
            new  Ajax.Request(dummypaht+'admin/include/iframe.aspx?FileType=AuctionProduct',options);
            break;
       case "Memberlist":
            new  Ajax.Request(dummypaht+'admin/include/iframe.aspx?FileType=Memberlist',options);
            break;
       case "ShopStyle":
            new  Ajax.Request(dummypaht+'admin/include/iframe.aspx?FileType=ShopStyle',options);
            break;
        case "ProductSparepart":
            new  Ajax.Request(dummypaht+'admin/include/iframe.aspx?FileType=ProductSparepart',options);
            break;
    }
}
//判断是否数组
function isArray(obj)
{   
  if(obj.constructor == window.Array)   
    return true;
  else   
   return false;
}
position = function(x,y)
{
    this.x = x;
    this.y = y;
}
getPosition = function(oElement)
{
    var objParent = oElement
    var oPosition = new position(0,0);
    while (objParent.tagName != "BODY")
    {
        oPosition.x += objParent.offsetLeft;
        oPosition.y += objParent.offsetTop;
        objParent = objParent.offsetParent;
    }
    return oPosition;
} 
function showfDiv(obj,content,width)
{
    var pos = getPosition(obj);
    var objDiv = document.getElementById("s_id");
    if (objDiv==null)
    {
        objDiv = document.createElement("div");
        objDiv.id="s_id";
    }
    objDiv.className="selectStyle";
    objDiv.style.position = "absolute";
	var tempheight=pos.y;
	var tempwidth1,tempheight1;
	var windowwidth=document.body.clientWidth;
	
	var isIE5 = (navigator.appVersion.indexOf("MSIE 5")>0) || (navigator.appVersion.indexOf("MSIE")>0 && parseInt(navigator.appVersion)> 4);
	var isIE55 = (navigator.appVersion.indexOf("MSIE 5.5")>0);
	var isIE6 = (navigator.appVersion.indexOf("MSIE 6")>0);
	var isIE7 = (navigator.appVersion.indexOf("MSIE 7")>0);

	if(isIE5||isIE55||isIE6||isIE7){var tempwidth=pos.x+305;}else{var tempwidth=pos.x+312;}
	objDiv.style.width = width+"px";
    objDiv.innerHTML = content;
	if (tempwidth>windowwidth)
	{
		tempwidth1=tempwidth-windowwidth
		objDiv.style.left = (pos.x-tempwidth1) + "px";
	}
	else
	{
		if(isIE5||isIE55||isIE6||isIE7){objDiv.style.left = (pos.x) + "px";}else{objDiv.style.left = (pos.x) + "px";}
	}
	if(isIE5||isIE55||isIE6||isIE7){objDiv.style.top = (pos.y+22) + "px";}else{objDiv.style.top = (pos.y+22) + "px";}

    objDiv.style.display = "";
    document.ondblclick=function () { if(objDiv.style.display==""){objDiv.style.display="none";} }
    document.body.appendChild(objDiv);
}
/*移动*/
drag=function (a,o){
	    var d=document;if(!a)a=window.event;
		if(!a.pageX)a.pageX=a.clientX;
		if(!a.pageY)a.pageY=a.clientY;
	    var x=a.pageX,y=a.pageY;
	    if(o.setCapture)
		    o.setCapture();
	    else if(window.captureEvents)
		    window.captureEvents(Event.MOUSEMOVE|Event.MOUSEUP);
	    var backData = {x : o.style.top, y : o.style.left};
	    d.onmousemove=function(a){
		    if(!a)a=window.event;
		    if(!a.pageX)a.pageX=a.clientX;
		    if(!a.pageY)a.pageY=a.clientY;
		    var tx=a.pageX-x+parseInt(o.style.left),ty=a.pageY-y+parseInt(o.style.top);
		    o.style.left=tx+"px";
		    o.style.top=ty+"px";
			x=a.pageX;
			y=a.pageY;
	    };

	    d.onmouseup=function(a){
		    if(!a)a=window.event;
		    if(o.releaseCapture)
			    o.releaseCapture();
		    else if(window.captureEvents)
			    window.captureEvents(Event.MOUSEMOVE|Event.MOUSEUP);
		    d.onmousemove=null;
		    d.onmouseup=null;
		    if(!a.pageX)a.pageX=a.clientX;
		    if(!a.pageY)a.pageY=a.clientY;
		    if(!document.body.pageWidth)document.body.pageWidth=document.body.clientWidth;
		    if(!document.body.pageHeight)document.body.pageHeight=document.body.clientHeight;
		    if(a.pageX < 1 || a.pageY < 1 || a.pageX > document.body.pageWidth || a.pageY > document.body.pageHeight){
			    o.style.left = backData.y;
			    o.style.top = backData.x;
		    }
	    };
    }
    /*确认*/
function ReturnFun(Return_Strs)
{
    if(isArray(LastSelectObj))
    {
        for(var i=0;i<LastSelectObj.length;i++)
        {
            SetValue(LastSelectObj[i],Return_Strs[i]);
        }
    }
    else
    {
        SetValue(LastSelectObj,Return_Strs);
    }
    document.getElementById("s_id").style.display="none";
}
function SetValue(obj,val)
{
    if (obj==null || typeof(obj)=="undefined")
    {
        alert("选择失败，请重新选择。");
    }
    else
    {
        if(val == null || typeof(val)=="undefined")
            val = '';
        obj.value = val;
    }	            
}


function ShowImg(control)
{
    $(control.id+"Img").src=control.value;
    
}

function ShowDiv(tabid,num)
{
    var tab;
    for(var i=0;i<num;i++)
    {
        tab=$("tab"+i);
        if(i==tabid)
        {
            tab.style.display='block';
        }
        else
        {
            tab.style.display='none';
        }
    }
}

function ReturnLabelValueText(value)
{

    try
    {
        if(value!="")
        {
            var oEditor = FCKeditorAPI.GetInstance("ctl00_workspace_txtContent");
            if (oEditor.EditMode==FCK_EDITMODE_WYSIWYG)
            {
               oEditor.InsertHtml(value);
            }
            else
            {
              return false;
            }
        }
    }
    catch(e)
    {
        insert(value);
    }
    finally
    {
        document.getElementById("LabelDivid").style.display="none";
        return;
    }
}
function showPath(type,obj,title,label_width,height,path,id)
{
    var label_temp1 = "<div onmousedown=\"drag(event,$('LabelDivid'));\" style=\"text-decoration: none;padding-left:3px;background-color:#EDEFEA;font-size: 12px;color: #4499CC;font-weight:\" class=\"titile_bg\" style=\"cursor:move;\">\
    <table style=\"width:100%;height:26px\">\
    <tr>\
    <td>\
    <font style='font-size:12px' color=\"#0099CC\">" + title + "</font></td>\
    <td style=\"width:40px\">\
    <span style='cursor:hand;font-size:12px;font-weight:bold;color:#0099CC' onclick=\"closediv($('LabelDivid'));\">关闭</span>\
    </td>\
    </tr>\
    </table>\
    </div>\
    <iframe src=";
    var label_temp2 = " frameborder=\"0\" id=\"select_main\" scrolling=\"yes\" name=\"select_main\" width=\"100%\" height=\""+height+"px\" />";
    var label_temp3 = "";
    
    switch(type)
    {
        case "ProductSparepart"://选择配件
            label_temp3 = label_temp1 + ""+path+"admin/include/sparepartproduct.aspx?sparepartId="+id+"" + label_temp2;
            break;
        case "StartSpecifications"://开启规格
            label_temp3 = label_temp1 + ""+path+"admin/include/specifications_add.aspx?type=1" + label_temp2;
            break;
        case "AddSpecifications"://新增规格
            label_temp3 = label_temp1 + ""+path+"admin/include/specifications_add.aspx?type=2" + label_temp2;
            break;
        case "UserShoppingInfo"://修改收货人信息
            label_temp3 = label_temp1 + ""+path+"admin/include/usershoppinginfo.aspx?userid=" + id + label_temp2;
            break;
        case "SetMemberPrice"://设置会员价格
            var strId=id.split(';');
            var shopPrice=document.getElementById(strId[0]).value;
            var memberPrice=document.getElementById(strId[1]).value;
            label_temp3 = label_temp1 + ""+path+"admin/include/memberpriceset.aspx?txtContrl="+strId[1]+"&shopPrice="+shopPrice+"&MemberPrice=" + memberPrice + label_temp2;
            break;
        default:
          break;
   }
   showlabelDiv(obj,label_temp3,label_width);
}
function show(type,obj,title,label_width,height)
{
    var label_temp1 = "<div onmousedown=\"drag(event,$('LabelDivid'));\" style=\"text-decoration: none;padding-left:3px;background-color:#EDEFEA;font-size: 12px;color: #4499CC;font-weight:\" class=\"titile_bg\" style=\"cursor:move;\">\
    <table style=\"width:100%;height:26px\">\
    <tr>\
    <td>\
    <font style='font-size:12px' color=\"#0099CC\">" + title + "</font></td>\
    <td style=\"width:40px\">\
    <span style='cursor:hand;font-size:12px;font-weight:bold;color:#0099CC' onclick=\"closediv($('LabelDivid'));\">关闭</span>\
    </td>\
    </tr>\
    </table>\
    </div>\
    <iframe src=";
    var label_temp2 = " frameborder=\"0\" id=\"select_main\" scrolling=\"yes\" name=\"select_main\" width=\"100%\" height=\""+height+"px\" />";
    var label_temp3 = "";
    switch(type)
    {
        case "systemlabel"://系统标签
            label_temp3 = label_temp1 + "label/selectlabel.aspx?w_d_tid=1" + label_temp2;
            break;
        case "definlabel"://用户标签
            label_temp3 = label_temp1 + "label/selectlabel.aspx?w_n_tid=1" + label_temp2;
            break;
        case "freelabel": //自由标签
            label_temp3 = label_temp1 + "label/selectfreelabel.aspx?w_d_free_labelclass=3" + label_temp2;
            break;
        case "ProductBrand":
            label_temp3 = label_temp1 + "productbrand_parameter.aspx" + label_temp2;
            break;
        case "ProductListMode":
            label_temp3 = label_temp1 + "productlistmode_parameter.aspx" + label_temp2;
            break;
        case "ProductClass":
            label_temp3 = label_temp1 + "productclass_parameter.aspx" + label_temp2;
            break;
        case "ProductList":
            label_temp3 = label_temp1 + "productlist_parameter.aspx?LabelClass=0" + label_temp2;
            break;
        case "StoreProductList":
            label_temp3 = label_temp1 + "productlist_parameter.aspx?LabelClass=1" + label_temp2;
            break;
        case "ProductContent":
            label_temp3 = label_temp1 + "productcontent_parameter.aspx" + label_temp2;
            break;
        case "TeamBuy":
            label_temp3 = label_temp1 + "Lable/TeamBuy_Parameter.aspx" + label_temp2;
            break;
        case "Friendlink":
            label_temp3=label_temp1+"friedlink_parameter.aspx"+label_temp2;
            break; 
        case "Survey":
            label_temp3=label_temp1+"Lable/Survey.aspx"+label_temp2;
            break;
        case "AdvancedSearch":
            label_temp3=label_temp1+"advancedsearch_parameter.aspx"+label_temp2;
            break;
        case "LeaveWrodInfo"://留言信息列表
            label_temp3=label_temp1+"leaveword_parameter.aspx"+label_temp2;
            break;
        case "LeaveWrodForm"://留言表单
            label_temp3=label_temp1+"leavewordform_parameter.aspx"+label_temp2;
            break;
        case "MemberRegForm"://用户注册表单
            label_temp3=label_temp1+"memberregform_parameter.aspx"+label_temp2;
            break;
        case "MemberAgree"://用户注册协议
            label_temp3=label_temp1+"memberagree_parameter.aspx"+label_temp2;
            break;
        case "shoppingcart":
            label_temp3=label_temp1+"shopintcart_parameter.aspx"+label_temp2;
            break;
        case "NewsList":
            label_temp3=label_temp1+"articlelist_parameter.aspx"+label_temp2;
            break;
        case "NewsContent":
            label_temp3=label_temp1+"refercontent_parameter.aspx"+label_temp2;
            break;
        case "ImportFile":
            label_temp3=label_temp1+"importfile.aspx"+label_temp2;
            break;
        case "websitetop":
            label_temp3=label_temp1+"label_top.aspx"+label_temp2;
            break;
        case "websitebottom":
            label_temp3=label_temp1+"label_bottom.aspx"+label_temp2;
            break;
        case "CreateURL":
            label_temp3=label_temp1+"label_createurl.aspx"+label_temp2;
            break;Advertise
        case "Advertise":
            label_temp3=label_temp1+"advertise_parameter.aspx"+label_temp2;
            break;
        case "CommentInfo":
             label_temp3=label_temp1+"commentinfo_parameter.aspx"+label_temp2;
             break;
        case "ReplyInfo":
             label_temp3=label_temp1+"replyinfo_parameter.aspx"+label_temp2;
             break;
        case "CommentForm":
             label_temp3=label_temp1+"commentform_parameter.aspx"+label_temp2;
             break;
        case "Login": //会员登陆
             label_temp3=label_temp1+"login_parameter.aspx"+label_temp2;
             break;
         case "usershopinginfo":
             label_temp3=label_temp1+"usershopinginfo_parameter.aspx"+label_temp2;
             break;
         case "ProductGroupBuyInfo"://团购商品活动信息
             label_temp3=label_temp1+"groupbuyactivityinfo_parameter.aspx"+label_temp2;
             break;
         case "scanproduct":
             label_temp3=label_temp1+"scantype_parameter.aspx"+label_temp2;
             break;
         case "History":
             label_temp3=label_temp1+"history_parameter.aspx"+label_temp2;
             break;  
         case "ProductExtract":
             label_temp3=label_temp1+"extract_parameter.aspx"+label_temp2;
             break;
         case "StoreInfo"://店铺信息
             label_temp3=label_temp1+"storeinfo_parameter.aspx"+label_temp2;
             break;
         case "StoreType"://店铺类型
             label_temp3=label_temp1+"storetype_parameter.aspx"+label_temp2;
             break;
         case "StoreSearch"://店铺搜索
             label_temp3=label_temp1+"storesearchform_parameter.aspx"+label_temp2;
             break;
         case "ProductProperty":
             label_temp3=label_temp1+"property_parameter.aspx"+label_temp2;
             break;
        default:
          break;
   }
    showlabelDiv(obj,label_temp3,label_width);
}

function showShopCart(type,obj,title,label_width,height,productId,path,specificationValue)
{
    var label_temp1 = "<div onmousedown=\"drag(event,$('LabelDivid'));\" style=\"text-decoration: none;padding-left:3px;background-color:#EDEFEA;font-size: 12px;color: #4499CC;font-weight:\" class=\"titile_bg\" style=\"cursor:move;\">\
    <table style=\"width:100%;height:26px\">\
    <tr>\
    <td>\
    <font style='font-size:12px' color=\"#0099CC\">" + title + "</font></td>\
    <td style=\"width:40px\">\
    <span style='cursor:hand;font-size:12px;font-weight:bold;color:#0099CC' onclick=\"javascript:removeChild($('LabelDivid'))\">双击关闭</span>\
    </td>\
    </tr>\
    </table>\
    </div>\
    <iframe src="+path;
    var label_temp2 = " frameborder=\"0\" scrolling=\"no\" id=\"select_main\" scrolling=\"yes\" name=\"select_main\" width=\"100%\" height=\""+height+"px\" />";
    var label_temp3 = "";
    switch(type)
    {
        case "showShopCart":
            label_temp3 = label_temp1 + "controls/floatingshopcart.aspx?productId="+productId+"&q_proSpecification="+specificationValue+"" + label_temp2;
            break;
        default:
          break;
   }
    showlabelDiv(obj,label_temp3,label_width);
}

function showlabelDiv(obj,content,width)
{
    var pos = getPosition(obj);
    var objDiv = document.getElementById("LabelDivid");
    if (objDiv==null)
    {
        objDiv = document.createElement("div");
        objDiv.id="LabelDivid";
    }
    objDiv.style.className="selectStyle";//For IE
    objDiv.style.border="1px double #B4C9C6";
    objDiv.style.backgroundColor="#F4FAFF";
    objDiv.style.color="#000000";
    objDiv.style.lineheight="18px";
    objDiv.style.padding="1px";
    objDiv.style.filter="progid:DXImageTransform.Microsoft.DropShadow(color=#C5C5C5,offX=2,offY=2,positives=true)";
    
    objDiv.style.position = "absolute";
	var tempheight=pos.y;
	var tempwidth1,tempheight1;
	var windowwidth=document.body.clientWidth;
	
	var isIE5 = (navigator.appVersion.indexOf("MSIE 5")>0) || (navigator.appVersion.indexOf("MSIE")>0 && parseInt(navigator.appVersion)> 4);
	var isIE55 = (navigator.appVersion.indexOf("MSIE 5.5")>0);
	var isIE6 = (navigator.appVersion.indexOf("MSIE 6")>0);
	var isIE7 = (navigator.appVersion.indexOf("MSIE 7")>0);

	if(isIE5||isIE55||isIE6||isIE7){var tempwidth=pos.x+305;}else{var tempwidth=pos.x+312;}
	objDiv.style.width = width+"px";
    objDiv.innerHTML = content;
	if (tempwidth>windowwidth)
	{
		tempwidth1=tempwidth-windowwidth
		objDiv.style.left = (pos.x-tempwidth1) + "px";
	}
	else
	{
		if(isIE5||isIE55||isIE6||isIE7){objDiv.style.left = (pos.x) + "px";}else{objDiv.style.left = (pos.x) + "px";}
	}
	if(isIE5||isIE55||isIE6||isIE7){objDiv.style.top = (pos.y+22) + "px";}else{objDiv.style.top = (pos.y+22) + "px";}

    objDiv.style.display = "";
    document.ondblclick=function () { if(objDiv.style.display==""){objDiv.style.display="none";} }
    document.body.appendChild(objDiv);
}
function closediv(objDiv)
{
   objDiv.parentNode.removeChild(objDiv);
}
function closedivreload()
{
   window.location.reload();
}
/*<--后台全选/取消全选，删除*/
function CheckAll(form) 
{
    for (var i=0;i<form.elements.length;i++)    
    {
        var e = form.elements[i];
        if (e.name != 'chkAll')   
        {
              e.checked = form.chkAll.checked; 
        }
    }
}
function GetAllChecked()
{
    var retstr = "";
    var tb = document.getElementById("tablist");
    
    var j = 0;
    for(var i=1;i<tb.rows.length;i++)
    {
        var objtr = tb.rows[i]; 
        if(objtr.cells.length < 4)
            continue;
        var objtd = objtr.cells[0]; 
        for(var k=0;k<objtd.childNodes.length;k++)
        {
       
            var objnd = objtd.childNodes[k];
            if(objnd.type == "checkbox")
            {
                if(objnd.checked)
                {
                    if(j>0)
                        retstr += ",";
                    retstr += objnd.value;
                    j++;
                }
                break;
            }
        }
    }
    return retstr;
}

/*选项卡切换*/
function ShowTabs(id,num)
{
    var tab;
    for(var i=0;i<num;i++)
    {
        tab=$("tab"+i);
        if(i==id)
        {
            $("TabTitle"+i).className="titlemouseover";
            tab.style.display='block';
        }
        else
        {
            $("TabTitle"+i).className="tabtitle";
            tab.style.display='none';
        }
    }
}  

function MaxLength(field,maxlimit){ 
   var j = field.value.replace(/[^\x00-\xff]/g,"**").length; 
   var tempString=field.value; 
   var tt=""; 
   if(j > maxlimit){
    for(var i=0;i<maxlimit;i++){
     if(tt.replace(/[^\x00-\xff]/g,"**").length < maxlimit)
      tt = tempString.substr(0,i+1);
     else 
      break; 
    } 
    if(tt.replace(/[^\x00-\xff]/g,"**").length > maxlimit) 
     tt=tt.substr(0,tt.length-1); 
     field.value = tt; 
   }else{ 
    ; 
   } 
} 


