var outlookbar=new outlook();
var t;


//快捷菜单
//t=outlookbar.addtitle('快捷菜单','快捷导航',1);
//outlookbar.additem('商品添加',t,'product/product_info_edit.aspx');
//outlookbar.additem('商品管理',t,'product/product_list.aspx');
//outlookbar.additem('添加会员',t,'member/member_edit.aspx');
//outlookbar.additem('网站参数配置',t,'systeminfo/site_setting.aspx');
////outlookbar.additem('商品参数配置',t,'systeminfo/shop_setting.aspx');
//outlookbar.additem('商品分类管理',t,'product/productclass_list.aspx?w_d_fatherid=0');
////outlookbar.additem('商品批量编辑',t,'product/product_list.aspx');
//outlookbar.additem('会员管理 ',t,'member/member_list.aspx');

//商品管理
t=outlookbar.addtitle('商品管理','商品管理',1);
outlookbar.additem('商品管理',t,'product/product_list.aspx');
outlookbar.additem('商品添加', t, 'product/product_info_edit.aspx');
//outlookbar.additem('商品类型管理',t,'product/product_type_list.aspx');
outlookbar.additem('商品分类管理',t,'product/productclass_list.aspx?w_d_fatherid=0');
outlookbar.additem('商品品牌管理',t,'product/productbrand_list.aspx');
outlookbar.additem('商品单位管理', t, 'product/productunit_list.aspx');
outlookbar.additem('属性管理', t, 'product/Product_Property.aspx');
//outlookbar.additem('商品批量导入',t,'product/product_import.aspx');
//outlookbar.additem('商品批量导出',t,'product/product_batch_export.aspx');
//outlookbar.additem('商品批量编辑',t,'product/product_batch_edit.aspx');
//outlookbar.additem('淘宝数据导入',t,'product/product_taobaoimport.aspx');
//t=outlookbar.addtitle('促销管理','商品管理',1);
//outlookbar.additem('团购商品管理',t,'product/product_integratepurchas_list.aspx');
//outlookbar.additem('拍卖商品管理',t,'product/product_auction_list.aspx');
//订单管理
t=outlookbar.addtitle('订单管理','订单管理',1);
outlookbar.additem('订单管理',t,'order/order_order_list.aspx');
t=outlookbar.addtitle('购物管理','订单管理',1);
outlookbar.additem('购物车管理',t,'order/order_shop_list.aspx');

t=outlookbar.addtitle('明细记录','订单管理',1);
outlookbar.additem('资金明细',t,'product/product_funds_list.aspx');
outlookbar.additem('商品销售明细',t,'product/product_sale_list.aspx');
outlookbar.additem('发退货明细',t,'product/product_back_list.aspx');
outlookbar.additem('订单过户明细',t,'product/product_trans_list.aspx');


//用户管理
t=outlookbar.addtitle('管理员','用户管理',1);
outlookbar.additem('管理员管理',t,'member/admin_list.aspx');
outlookbar.additem('角色管理',t,'member/role_list.aspx');
t=outlookbar.addtitle('会员管理','用户管理',1);
outlookbar.additem('会员管理',t,'member/member_list.aspx');
outlookbar.additem('会员等级管理',t,'member/member_rank_list.aspx');
t=outlookbar.addtitle('充值卡管理','用户管理',1);
outlookbar.additem('充值卡管理',t,'ordercard/ordercard_list.aspx');
outlookbar.additem('未使用的充值卡',t,'ordercard/ordercard_list.aspx?w_d_whetherRelease=0&w_d_productid=0');
outlookbar.additem('已使用的充值卡',t,'ordercard/ordercard_list.aspx?w_d_whetherRelease=1');
var now= new Date();
var year=now.getYear();
var month=now.getMonth()+1;
var day=now.getDate();
var hour=now.getHours();
var minute=now.getMinutes();
var second=now.getSeconds();
outlookbar.additem('已失效的充值卡',t,'ordercard/ordercard_list.aspx?w_e_expirationdate='+year+"-"+month+"-"+day+" "+hour+":"+minute+":"+second);
outlookbar.additem('已售出的充值卡',t,'ordercard/ordercard_list.aspx?w_d_whetherRelease=2&w_n_productid=0');
outlookbar.additem('未售出的充值卡',t,'ordercard/ordercard_list.aspx?w_d_whetherRelease=0&w_n_productid=0');
//t=outlookbar.addtitle('资金明细','用户管理',1);
//outlookbar.additem('所有资金明细记录',t,'member/userinandexp_list.aspx?type=all');
//outlookbar.additem('所有银行收入记录',t,'member/userinandexp_list.aspx?type=in');
//outlookbar.additem('所有银行支出记录',t,'member/userinandexp_list.aspx?type=out');
//outlookbar.additem('所有已确认的记录',t,'member/userinandexp_list.aspx?type=sure');
//outlookbar.additem('所有未确认的记录',t,'member/userinandexp_list.aspx?type=cancel');
//outlookbar.additem('所有其他收入记录',t,'member/capital_rest.aspx?type=in');
//outlookbar.additem('所有其他支出记录',t,'member/capital_rest.aspx?type=out');
//t=outlookbar.addtitle('有效期明细','用户管理',1);
//outlookbar.additem('所有有效期明细记录',t,'member/member_detail_date.aspx?type=all');
//outlookbar.additem('所有添加有效期记录',t,'member/member_detail_date.aspx?type=add');
//outlookbar.additem('所有扣除有效期记录',t,'member/member_detail_date.aspx?type=make');
//t=outlookbar.addtitle('点卷明细','用户管理',1);
//outlookbar.additem('所有点卷明细记录',t,'member/coupons_record_list.aspx?type=all');
//outlookbar.additem('所有添加点卷记录',t,'member/coupons_record_list.aspx?type=in');
//outlookbar.additem('所有扣除点卷记录',t,'member/coupons_record_list.aspx?type=out');

//店铺管理 
//t=outlookbar.addtitle('店铺管理','店铺管理',1);
//outlookbar.additem('店铺类型管理',t,'shop/shopcategory_list.aspx');
//outlookbar.additem('店铺等级管理',t,'shop/shoplevel_list.aspx');
//outlookbar.additem('店铺信息管理',t,'shop/shop_list.aspx');
//outlookbar.additem('店铺域名管理',t,'shop/shop_domain_name.aspx');
//outlookbar.additem('店铺公告管理',t,'shop/shop_affiche_list.aspx');
//outlookbar.additem('快速开启店铺',t,'shop/shop_add.aspx');
//t=outlookbar.addtitle('模板标签','店铺管理',1);
////outlookbar.additem('模型管理',t,'systeminfo/mouldtype_list.aspx?w_d_isstoremould=1');
//outlookbar.additem('店铺模板管理',t,'shop/shop_color_template.aspx');
//outlookbar.additem('店铺标签管理',t,'templates/label/labelclass_list.aspx?w_d_isstorelabel=1');



//资讯频道
t=outlookbar.addtitle('资讯频道','资讯频道',1);
outlookbar.additem('频道管理',t,'systeminfo/articlechannel_list.aspx');
outlookbar.additem('资讯管理',t,'systeminfo/article_list.aspx');

////模板标签
//t=outlookbar.addtitle('模版标签','模版标签',1);
//outlookbar.additem('模板管理',t,'templates/template.aspx');
//outlookbar.additem('自由标签管理',t,'templates/label/freedomlabel_list.aspx');

//网站配置
t=outlookbar.addtitle('网站配置','系统设置',1);
outlookbar.additem('网站参数配置',t,'systeminfo/site_setting.aspx');
//outlookbar.additem('商品参数配置',t,'systeminfo/shop_setting.aspx');
outlookbar.additem('用户参数配置',t,'systeminfo/user_setting.aspx');
outlookbar.additem('邮件参数配置',t,'systeminfo/mail_setting.aspx');
//outlookbar.additem('缩略图参数配置',t,'systeminfo/thumbnails_setting.aspx');
outlookbar.additem('地区分站配置',t,'systeminfo/area_setting.aspx?w_d_parentid=0');
//outlookbar.additem('商城模型管理',t,'systeminfo/mouldtype_list.aspx?w_d_isstoremould=0');
//outlookbar.additem('自定义会员注册 ',t,'member/memberproperty_list.aspx');
//t=outlookbar.addtitle('银行帐户','系统设置',1);
//outlookbar.additem('银行帐户管理',t,'systeminfo/bank_list.aspx');
//outlookbar.additem('银行信息管理',t,'systeminfo/bankinfo_list.aspx');
t = outlookbar.addtitle('评论管理', '系统设置', 1);
outlookbar.additem('留言信息管理', t, 'accessories/leaveword_list.aspx');
outlookbar.additem('点评信息管理', t, 'product/product_comment_list.aspx');
t = outlookbar.addtitle('友情链接', '系统设置', 1);
outlookbar.additem('友情链接管理', t, 'accessories/hailhellowlink_list.aspx');
outlookbar.additem('添加友情链接', t, 'accessories/hailhellowlink_edit.aspx');
t=outlookbar.addtitle('其他信息','系统设置',1);
outlookbar.additem('支付平台管理',t,'systeminfo/paymentmanage_list.aspx');
outlookbar.additem('配送方式管理',t,'systeminfo/deliver_list.aspx');
outlookbar.additem('快递公司管理',t,'product/express_list.aspx');
outlookbar.additem('收藏管理', t, 'accessories/collection_list.aspx');
outlookbar.additem('热门搜索设置', t, 'accessories/topsearchesseting_list.aspx');

//附件管理
//t=outlookbar.addtitle('广告管理','附件管理',1);
//outlookbar.additem('广告管理',t,'accessories/advertise_list.aspx');
//outlookbar.additem('生成JS',t,'accessories/advertise_createjs.aspx');

//t=outlookbar.addtitle('数据管理','附件管理',1);
//outlookbar.additem('备份数据库',t,'accessories/backdatabase.aspx');
//outlookbar.additem('运行指定的SQL语句',t,'accessories/exesql.aspx');





//t=outlookbar.addtitle('其它信息','附件管理',1);
////outlookbar.additem('缺货登记管理',t,'accessories/outofstock_list.aspx');
//outlookbar.additem('收藏管理',t,'accessories/collection_list.aspx');
//outlookbar.additem('热门搜索设置',t,'accessories/topsearchesseting_list.aspx');
////outlookbar.additem('调查问卷管理',t,'accessories/questionnaire_list.aspx');
////outlookbar.additem('评论表单管理',t,'accessories/commentform_list.aspx');
////outlookbar.additem('图片管理',t,'accessories/picturemanaging.aspx');

var preClassName = ""; 
function list_sub_detail(Id, item) 
{ 
if(preClassName != "") 
{ 
getObject(preClassName).className = "left_back" 
} 
if(getObject(Id).className == "left_back") 
{ 
getObject(Id).className = "left_back_onclick"; 
outlookbar.getbyitem(item); 
preClassName = Id 
} 
} 
function getObject(objectId) 
{ 
if(document.getElementById && document.getElementById(objectId)) 
{ 
return document.getElementById(objectId) 
} 
else if(document.all && document.all(objectId)) 
{ 
return document.all(objectId) 
} 
else if(document.layers && document.layers[objectId]) 
{ 
return document.layers[objectId] 
} 
else 
{ 
return false 
} 
} 
function outlook() 
{ 
this.titlelist = new Array(); 
this.itemlist = new Array(); 
this.addtitle = addtitle; 
this.additem = additem; 
this.getbytitle = getbytitle; 
this.getbyitem = getbyitem; 
this.getdefaultnav = getdefaultnav 
} 
function theitem(intitle, insort, inkey, inisdefault) 
{ 
this.sortname = insort; 
this.key = inkey; 
this.title = intitle; 
this.isdefault = inisdefault 
} 
function addtitle(intitle, sortname, inisdefault) 
{ 
outlookbar.itemlist[outlookbar.titlelist.length] = new Array(); 
outlookbar.titlelist[outlookbar.titlelist.length] = new theitem(intitle, sortname, 0, inisdefault); 
return(outlookbar.titlelist.length - 1) 
} 
function additem(intitle, parentid, inkey) 
{ 
if(parentid >= 0 && parentid <= outlookbar.titlelist.length) 
{ 
insort = "item_" + parentid; 
outlookbar.itemlist[parentid][outlookbar.itemlist[parentid].length] = new theitem(intitle, insort, inkey, 0); 
return(outlookbar.itemlist[parentid].length - 1) 
} 
else additem = - 1 
} 
function getdefaultnav(sortname) 
{ 
var output = ""; 
for(i = 0; i < outlookbar.titlelist.length; i ++ ) 
{ 
if(outlookbar.titlelist[i].isdefault == 1 && outlookbar.titlelist[i].sortname == sortname) 
{ 
output += "<div class=list_tilte id=sub_sort_" + i + " onclick=\"hideorshow('sub_detail_"+i+"')\">"; 
output += "<span>" + outlookbar.titlelist[i].title + "</span>"; 
output += "</div>"; 
output += "<div class=list_detail id=sub_detail_" + i + "><ul>"; 
for(j = 0; j < outlookbar.itemlist[i].length; j ++ ) 
{ 
output += "<li id=" + outlookbar.itemlist[i][j].sortname + j + " onclick=\"changeframe('"+outlookbar.itemlist[i][j].title+"', '"+outlookbar.titlelist[i].title+"', '"+outlookbar.itemlist[i][j].key+"')\"><a href=#>" + outlookbar.itemlist[i][j].title + "</a></li>" 
} 
output += "</ul></div>" 
} 
} 
getObject('right_main_nav').innerHTML = output 
} 
function getbytitle(sortname) 
{ 
var output = "<ul>"; 
for(i = 0; i < outlookbar.titlelist.length; i ++ ) 
{ 
if(outlookbar.titlelist[i].sortname == sortname) 
{ 
output += "<li id=left_nav_" + i + " onclick=\"list_sub_detail(id, '"+outlookbar.titlelist[i].title+"')\" class=left_back>" + outlookbar.titlelist[i].title + "</li>" 
} 
} 
output += "</ul>"; 
getObject('left_main_nav').innerHTML = output 
} 
function getbyitem(item) 
{ 
var output = ""; 
for(i = 0; i < outlookbar.titlelist.length; i ++ ) 
{ 
if(outlookbar.titlelist[i].title == item) 
{ 
output = "<div class=list_tilte id=sub_sort_" + i + " onclick=\"hideorshow('sub_detail_"+i+"')\">"; 
output += "<span>" + outlookbar.titlelist[i].title + "</span>"; 
output += "</div>"; 
output += "<div class=list_detail id=sub_detail_" + i + " style='display:block;'><ul>"; 
for(j = 0; j < outlookbar.itemlist[i].length; j ++ ) 
{ 
output += "<li id=" + outlookbar.itemlist[i][j].sortname + "_" + j + " onclick=\"changeframe('"+outlookbar.itemlist[i][j].title+"', '"+outlookbar.titlelist[i].title+"', '"+outlookbar.itemlist[i][j].key+"')\"><a href=#>" + outlookbar.itemlist[i][j].title + "</a></li>" 
} 
output += "</ul></div>" 
} 
} 
getObject('right_main_nav').innerHTML = output 
} 
function changeframe(item, sortname, src) 
{ 
if(item != "" && sortname != "") 
{ 
window.top.frames['mainFrame'].getObject('show_text').innerHTML = sortname + "  <img src=images/slide.gif broder=0 />  " + item 
} 
if(src != "") 
{ 
window.top.frames['manFrame'].location = src 
} 
} 
function hideorshow(divid) 
{ 
subsortid = "sub_sort_" + divid.substring(11); 
if(getObject(divid).style.display == "none") 
{ 
getObject(divid).style.display = "block"; 
getObject(subsortid).className = "list_tilte" 
} 
else 
{ 
getObject(divid).style.display = "none"; 
getObject(subsortid).className = "list_tilte_onclick" 
} 
} 
function initinav(sortname) 
{ 
outlookbar.getdefaultnav(sortname); 
outlookbar.getbytitle(sortname); 
document.getElementById("right_main_nav").style.height=document.documentElement.clientHeight-68;
}