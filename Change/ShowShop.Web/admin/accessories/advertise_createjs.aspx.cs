using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace ShowShop.Web.admin.accessories
{
    
    public partial class advertise_createjs : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowShop.Common.PromptInfo.Popedom("012001006","对不起，您没有权限生成JS");
                BeginCreate();
            }
        }

        protected void BeginCreate()
        {
            string adurl = string.Empty;
            string width = string.Empty;
            string height = string.Empty;
            string picurl = string.Empty;
            string content = string.Empty;
            string jsname = string.Empty;
            string AdType = string.Empty;
            ShowShop.BLL.Accessories.AdvertiseManage bll = new ShowShop.BLL.Accessories.AdvertiseManage();
            ShowShop.Common.SysParameter sysParm = new ShowShop.Common.SysParameter();
            string ads_id = ChangeHope.WebPage.PageRequest.GetQueryString("Ads_ID");
            if (ads_id != "" && ads_id != null)
            {
                ShowShop.Model.Accessories.AdvertiseManage model = bll.GetModelByID(Convert.ToInt32(ads_id));
                if (model != null)
                {
                    adurl = model.LinkAddress;
                    width = model.SizeBreadth.ToString();
                    height = model.Hight.ToString();
                    picurl = sysParm.DummyPaht + model.UpspreadAdd;
                    content = model.Advertisecont;
                    jsname = model.Name;
                    AdType = model.Adtype.ToString();
                    CreateJs(adurl, width, height, picurl, content, jsname, Convert.ToInt16(AdType));

                    this.ltlMsg.Text = "操作成功，已生成"+model.Name+".JS广告";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionOk";
                }
            }
            else
            {
                List<ShowShop.Model.Accessories.AdvertiseManage> modeList = bll.GetAll();
                if (modeList.Count > 0)
                {
                    int i = 0;
                    foreach (ShowShop.Model.Accessories.AdvertiseManage model in modeList)
                    {
                        adurl = model.LinkAddress;
                        width = model.SizeBreadth.ToString();
                        height = model.Hight.ToString();
                        picurl = sysParm.DummyPaht + model.UpspreadAdd;
                        content = model.Advertisecont;
                        jsname = model.Name;
                        AdType = model.Adtype.ToString();
                        CreateJs(adurl, width, height, picurl, content, jsname, Convert.ToInt16(AdType));
                        i++;
                    }
                    this.ltlMsg.Text = "操作成功，共生成" + i.ToString() + "个广告";
                    this.pnlMsg.Visible = true;
                    this.pnlMsg.CssClass = "actionOk";
                }
            }
           
        }

        /// <summary>
        /// 动态生成JS广告代码
        /// </summary>
        /// <param name="adurl">链接地址</param>
        /// <param name="width">宽</param>
        /// <param name="height">高</param>
        /// <param name="picurl">图片地址</param>
        /// <param name="content">内容</param>
        /// <param name="jsname">广告名</param>
        /// <param name="adtype">广告类型</param>
        protected void CreateJs(string adurl, string width, string height, string picurl, string content, string jsname, int adtype)
        {
            ShowShop.Common.SysParameter sysParm = new ShowShop.Common.SysParameter();
            //先创建文件
            string path = "";
            //路径
            path = Server.MapPath("~") + "\\include" + "\\advertise\\"  + jsname + ".JS";
            StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.UTF8);
            string flash = "<a href='" + adurl + "' target='_blank'><object classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\" codebase=\"http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0\" width='" + width + "' height='" + height + "'>";
            StringBuilder adhtml = new StringBuilder();
            if (adtype == 3)//幻灯片广告
            {
                adhtml.Append("<!-- \n");
                adhtml.Append("var focus_width=" + width + "; \n");//图片宽
                adhtml.Append("var focus_height=" + height + "; \n");//图片高
                adhtml.Append("var text_height=0; \n");//设置显示文字标题高度,最佳为20（如果不显示标题值设为0即可）
                adhtml.Append("var swf_height = focus_height+text_height; \n");
                string AD = picurl.Replace("|", "|" +sysParm.DummyPaht);
                adhtml.Append("var pics = '" + AD + "';\n");
                adhtml.Append("var links = '" + adurl + "'; \n");
                adhtml.Append("var texts = '" + content + "'; \n");
                adhtml.Append("document.write('<object ID=\"focus_flash\" classid=\"clsid:d27cdb6e-ae6d-11cf-96b8-444553540000\" codebase=\"http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0\" width=\"'+ focus_width +'\" height=\"'+ swf_height +'\">'); \n");
                adhtml.Append("document.write('<param name=\"allowScriptAccess\" value=\"sameDomain\"><param name=\"movie\" value=\"" +sysParm.DummyPaht + "include/playswf.swf\"><param name=\"quality\" value=\"high\"><param name=\"bgcolor\" value=\"#FFFFFF\">'); \n");
                adhtml.Append("document.write('<param name=\"menu\" value=\"false\"><param name=wmode value=\"opaque\">'); \n");
                adhtml.Append("document.write('<param name=\"FlashVars\" value=\"pics='+pics+'&links='+links+'&texts='+texts+'&borderwidth='+focus_width+'&borderheight='+focus_height+'&textheight='+text_height+'\">'); \n");
                adhtml.Append("document.write('<embed ID=\"focus_flash\" src=\"" +  sysParm.DummyPaht + "include/playswf.swf\" wmode=\"opaque\" FlashVars=\"pics='+pics+'&links='+links+'&texts='+texts+'&borderwidth='+focus_width+'&borderheight='+focus_height+'&textheight='+text_height+'\" menu=\"false\" bgcolor=\"#C5C5C5\" quality=\"high\" width=\"'+ focus_width +'\" height=\"'+ swf_height +'\" allowScriptAccess=\"sameDomain\" type=\"application/x-shockwave-flash\" pluginspage=\"http://www.macromedia.com/go/getflashplayer\" />');\n");
                adhtml.Append("document.write('</object>'); \n");
                adhtml.Append("//-->");
            }
            string Stem_Swf = "";
            if (adtype == 1)//FLASH广告
            {
                Stem_Swf += "<object classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=7,0,19,0' width=" + width + " height=" + height + ">";
                Stem_Swf += "<param name='movie' value='" + picurl + "' />";
                Stem_Swf += "<param name='quality' value='high' />";
                Stem_Swf += "<embed src='" + picurl + "' quality='high' pluginspage='http://www.macromedia.com/go/getflashplayer' type='application/x-shockwave-flash' width=" + width + " height=" + height + "></embed>";
                Stem_Swf += "</object>";
            }
            string stem_float = "";
            if (adtype == 5)//漂浮广告
            {
                stem_float += "document.write(\"<div id='img' style='position:absolute;'>\");";
                stem_float += "document.write(\"<a href='" + adurl + "' target='_blank'><img src='" + picurl + "'onClick='pause_resume();' width=" + width + " height=" + height + "></a></div>\");\n";
                stem_float += "<!-- Begin \n";
                stem_float += "var xPos = 20;\n";
                stem_float += "var yPos = document.body.clientHeight;\n";
                stem_float += "var step = 1;\n";
                stem_float += "var delay = 30;\n ";
                stem_float += "var height = 0;\n";
                stem_float += "var Hoffset = 0;\n";
                stem_float += "var Woffset = 0;\n";
                stem_float += "var yon = 0;\n";
                stem_float += "var xon = 0;\n";
                stem_float += "var pause = true;\n";
                stem_float += "var interval;\n";
                stem_float += "img.style.top = yPos;\n";
                stem_float += "function changePos() {\n";
                stem_float += "width = document.body.clientWidth;\n";
                stem_float += "height = document.body.clientHeight;\n";
                stem_float += "Hoffset = img.offsetHeight;\n";
                stem_float += "Woffset = img.offsetWidth;\n";
                stem_float += "img.style.left = xPos + document.body.scrollLeft;\n";
                stem_float += "img.style.top = yPos + document.body.scrollTop;\n";
                stem_float += "if (yon) {\n";
                stem_float += "yPos = yPos + step;\n";
                stem_float += "}\n";
                stem_float += "else {\n";
                stem_float += "yPos = yPos - step;\n";
                stem_float += "}\n";
                stem_float += "if (yPos < 0) {\n";
                stem_float += "yon = 1;\n";
                stem_float += "yPos = 0;\n";
                stem_float += "}\n";
                stem_float += "if (yPos >= (height - Hoffset)) {\n";
                stem_float += "yon = 0;\n";
                stem_float += "yPos = (height - Hoffset);\n";
                stem_float += "}\n";
                stem_float += "if (xon) {\n";
                stem_float += "xPos = xPos + step;\n";
                stem_float += "}\n";
                stem_float += "else {\n";
                stem_float += "xPos = xPos - step;\n";
                stem_float += "}\n";
                stem_float += "if (xPos < 0) {\n";
                stem_float += "xon = 1;\n";
                stem_float += "xPos = 0;\n";
                stem_float += "}\n";
                stem_float += "if (xPos >= (width - Woffset)) {\n";
                stem_float += "xon = 0;\n";
                stem_float += "xPos = (width - Woffset);\n";
                stem_float += "}\n";
                stem_float += "}\n";
                stem_float += "function start() {\n";
                stem_float += "img.visibility = 'visible';\n";
                stem_float += "interval = setInterval('changePos()', delay);\n";
                stem_float += "}\n";
                stem_float += "function pause_resume() {\n";
                stem_float += "if(pause) {\n";
                stem_float += "clearInterval(interval);\n";
                stem_float += "pause = false;\n";
                stem_float += "}\n";
                stem_float += "else {\n";
                stem_float += "interval = setInterval('changePos()',delay);\n";
                stem_float += "pause = true;\n";
                stem_float += "}\n";
                stem_float += "}\n";
                stem_float += "start();\n";
                stem_float += "//  End -->\n";
            }
            string stemDL = "";
            if (adtype == 4)//对联广告
            {
                if (picurl != null)
                {
                    string pic = picurl.Substring((picurl.Length - 1), 1);
                    if (pic == "|")
                    {
                        //去掉最后一个"|"
                        pic = picurl.Substring(0, (picurl.Length - 1));
                    }
                    //得到数组
                    string[] img = null;
                    img = pic.Split('|');
                    int imgnum = img.Length;
                    //采用平分广告
                    int temp_pic_left = 0;//左边多少个
                    int temp_pic_right = 0;//右边多少个
                    if (imgnum % 2 == 0)
                    {
                        if (imgnum >= 2)
                        {
                            temp_pic_left = imgnum / 2;
                            temp_pic_right = imgnum / 2;
                        }
                        else
                        {
                            temp_pic_left = imgnum;
                        }
                    }
                    else
                    {
                        if (imgnum >= 2)
                        {
                            temp_pic_left = (imgnum / 2) + 1;
                            temp_pic_right = (imgnum / 2) - 1;
                        }
                        else
                        {
                            temp_pic_left = imgnum;
                        }
                    }
                    stemDL += "      //常数定义  \n ";
                    stemDL += "self.onError=null;  \n";
                    stemDL += " currentX   =   currentY   =   0;  \n";
                    stemDL += "whichIt   =   null;  \n";
                    stemDL += " lastScrollX   =   0;   //最后离左边距离的负值  \n";
                    stemDL += " lastScrollY   =0;     //最后离顶部的高度的负值  \n";
                    stemDL += "//----------------------start   fun秒执行一次 \n";
                    stemDL += "function   heartBeat(id1,id2)   {          \n";
                    stemDL += "diffY   =   document.body.scrollTop; \n";
                    stemDL += " diffX   =   document.body.scrollLeft; \n";
                    stemDL += " if(diffY   !=   lastScrollY)   {       \n";
                    stemDL += "percent   =   .1   *   (diffY   -   lastScrollY);  \n";
                    stemDL += "if(percent   >   0)   percent   =   Math.ceil(percent);   \n";
                    stemDL += " else   percent   =   Math.floor(percent);   \n";
                    stemDL += " id1.style.pixelTop   +=   percent; \n";
                    stemDL += "id2.style.pixelTop   +=   percent; \n";
                    stemDL += "lastScrollY   =   lastScrollY   +   percent;  \n";
                    stemDL += " }     ";
                    stemDL += "if(diffX   !=   lastScrollX)   {     \n";
                    stemDL += " percent   =   .1   *   (diffX   -   lastScrollX); \n";
                    stemDL += "if(percent   >   0)   percent   =   Math.ceil(percent);  \n";
                    stemDL += " else   percent   =   Math.floor(percent); \n";
                    stemDL += "id1.style.pixelTop   +=   percent;   \n";
                    stemDL += " id2.style.pixelTop   +=   percent; \n";
                    stemDL += " lastScrollX   =   lastScrollX   +   percent;    \n";
                    stemDL += "  } \n";
                    stemDL += " } \n";
                    stemDL += "//-----------------------end   fun   \n";
                    stemDL += "scr=screen.width \n";
                    stemDL += "left_1=(scr>800)?6:145   \n";
                    stemDL += "right_1=(scr>840)?920:580  \n";
                    //左侧图片   
                    stemDL += "document.write(\"<DIV   id=f1   style='left:   \"+left_1+\"px;   top:   215px;   POSITION:   absolute;'><table>";
                    for (int i = 0; i < temp_pic_left; i++)
                    {
                        stemDL += "<tr><td><img src='" + img[i] + "' border=0 width='70' height='70'></td></tr>";
                    }
                    stemDL += "</table></div>\") \n";
                    //右侧图片   
                    stemDL += "document.write(\"<DIV   id=f2   style='left:   \"+right_1+\"px;   top:   215px;   POSITION:   absolute;'><table>";
                    for (int j = temp_pic_left; j < imgnum; j++)
                    {
                        stemDL += "<tr><td><img src='" + img[j] + "' border=0 width='70' height='70'></td></tr>";
                    }
                    stemDL += "</table></div>\") \n";
                    stemDL += "action = window.setInterval(\"heartBeat(f1,f2)\", 50);  \n";
                }
            }
            switch (adtype)
            {
                case 0://图片广告
                    sw.WriteLine("document.write(\"<a href='" + adurl + "' target='_blank'><img border=0 src='" + picurl + "' width='" + width + "' height='" + height + "' alt='" + content + "'></a>\");");
                    break;
                case 1:
                    sw.Write("document.write(\"" + Stem_Swf + "\");");
                    break;
                case 3:
                    sw.Write(adhtml.ToString());
                    break;
                case 4:
                    sw.Write(stemDL);
                    break;
                case 5:
                    sw.Write(stem_float);
                    break;
            }
            sw.Flush();
            sw.Close();
        }

        
    }
}
