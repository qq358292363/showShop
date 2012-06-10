﻿using System;
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
using System.Collections.Generic;

namespace ShowShop.Web.admin.member
{
    public partial class popedom_manage : System.Web.UI.Page
    {
        public static bool statebl = true;//特殊权限关闭
        public static bool ispower = false;//添加
        public static int RoleID = 0;
        ShowShop.BLL.Member.Roles_Permissions bll = new ShowShop.BLL.Member.Roles_Permissions();
        protected void Page_Load(object sender, EventArgs e)
        {
 
            if ((!IsPostBack) || ((Request["Event"] != null) && (Request["Event"] != "")))
            {
                ShowShop.Common.PromptInfo.Popedom("007002005","对不起，您没有权限进行管理");
                //初始化信息(订单信息，银行信息，支付信息)
                if (ChangeHope.WebPage.PageRequest.GetQueryInt("id")>0)
                {

                    RoleID = ChangeHope.WebPage.PageRequest.GetQueryInt("id");
                }
            }
        }

        //初始化权限设置
        private void InitPowers(int RoleID)
        {
            List<ShowShop.Model.Member.Roles_Permissions> list = bll.GetListByColumn("ID", RoleID);
            if (list != null)
            {
                if (list.Count > 0)
                    ispower = true;
                foreach (ListItem lItem in CheckBoxList1.Items)
                {
                    lItem.Selected = false;
                }
                bool bl = false;
                if (list.Count == 1)
                {
                    Type type = typeof(ShowShop.Common.PowerEnum.PowerType);
                    string name = Enum.GetName(type, list[0].OperateCode);
                    switch (name)
                    {
                        case "look":
                            CheckBoxList1.Items[0].Selected = true;
                            bl = true;
                            break;
                        case "add":
                            CheckBoxList1.Items[0].Selected = true;
                            CheckBoxList1.Items[1].Selected = true;
                            bl = true;
                            break;
                        case "update":
                            CheckBoxList1.Items[0].Selected = true;
                            CheckBoxList1.Items[2].Selected = true;
                            bl = true;
                            break;
                        case "del":
                            CheckBoxList1.Items[0].Selected = true;
                            CheckBoxList1.Items[3].Selected = true;
                            bl = true;
                            break;
                        case "deladd":
                            CheckBoxList1.Items[0].Selected = true;
                            CheckBoxList1.Items[1].Selected = true;
                            CheckBoxList1.Items[3].Selected = true;
                            bl = true;
                            break;
                        case "delupdate":
                            CheckBoxList1.Items[0].Selected = true;
                            CheckBoxList1.Items[2].Selected = true;
                            CheckBoxList1.Items[3].Selected = true;
                            bl = true;
                            break;
                        case "updateadd":
                            CheckBoxList1.Items[0].Selected = true;
                            CheckBoxList1.Items[1].Selected = true;
                            CheckBoxList1.Items[2].Selected = true;
                            bl = true;
                            break;
                        case "all":
                            CheckBoxList1.Items[0].Selected = true;
                            CheckBoxList1.Items[1].Selected = true;
                            CheckBoxList1.Items[2].Selected = true;
                            CheckBoxList1.Items[3].Selected = true;
                            bl = true;
                            break;
                    }
                }
                if (bl)
                {
                    TreeView1.Enabled = false;
                }
                else
                {
                    if (list.Count > 0)
                    {
                        foreach (TreeNode tNode in TreeView1.Nodes)
                        {
                            InitChildPowers(tNode, ref list);
                        }
                    }
                }
            }

        }
        //初始化限设置
        private void InitChildPowers(TreeNode tNode, ref List<ShowShop.Model.Member.Roles_Permissions> list)
        {
            int nodeValue = 0;
            if (ChangeHope.Common.ValidateHelper.IsNumber(tNode.Value))//防止xml输入错误数据引起的错误、、处理方式：跳过错误数据的处理
            {
                if (list == null)
                    return;
                else if (list.Count < 1)
                    return;
                nodeValue = int.Parse(tNode.Value);
                bool bl = false;//转移操作
                foreach (ShowShop.Model.Member.Roles_Permissions rModel in list)
                {
                    if (nodeValue == rModel.OperateCode)
                    {
                        tNode.Checked = true;
                        tNode.Expanded = true;
                        if (list.Remove(rModel))
                        {
                            bl = true;
                            break;
                        }
                    }
                }
                if (bl)
                {
                    foreach (TreeNode node in tNode.ChildNodes)
                    {
                        InitChildPowers(node, ref list);//递归
                    }
                }
            }
        }
        private void UpdatePowers(List<ShowShop.Model.Member.Roles_Permissions> newList, List<ShowShop.Model.Member.Roles_Permissions> oldList)
        {
            //分析要删除的权限信息，分析要增加的信息：数据库已有信息和当前得到的信息的比较
            List<ShowShop.Model.Member.Roles_Permissions> AddList = new List<ShowShop.Model.Member.Roles_Permissions>();
            bool bl = true;
            ArrayList al = new ArrayList();

            foreach (ShowShop.Model.Member.Roles_Permissions nrModel in newList)
            {
                bl = true;

                foreach (ShowShop.Model.Member.Roles_Permissions orModel in oldList)
                {
                    if (orModel.OperateCode == nrModel.OperateCode)
                    {
                        bl = false;
                        //  oldList.Remove(orModel);
                        al.Add(orModel);
                        // break;
                    }
                    else
                    { 
                    
                    }
                }
                if (bl)
                {
                    AddList.Add(nrModel);
                }
                foreach (object o in al)
                {
                    ShowShop.Model.Member.Roles_Permissions rp = (ShowShop.Model.Member.Roles_Permissions)o;
                    if (oldList.Contains(rp))
                    {
                        oldList.Remove(rp);
                    }
                }
                al = new ArrayList();

            }
            try
            {
                if (oldList.Count > 0)
                {
                    bll.Del(oldList);
                }
                bll.Add(AddList);
     
                
            }
            catch
            { }
        }

        private void AddPowers(int RoleID)
        {
            TreeNode tn = new TreeNode();

            List<ShowShop.Model.Member.Roles_Permissions> list = new List<ShowShop.Model.Member.Roles_Permissions>();
            ShowShop.Model.Member.Roles_Permissions rModel = null;
            foreach (TreeNode tNode in TreeView1.CheckedNodes)
            {
                rModel = new ShowShop.Model.Member.Roles_Permissions();
                rModel.ID = RoleID;
                if (ChangeHope.Common.ValidateHelper.IsNumber(tNode.Value))
                {
                    rModel.OperateCode = int.Parse(tNode.Value);
                }
                else
                {
                    continue;
                }
                list.Add(rModel);
                rModel = null;
            }
            bll.Add(list);
        }
        private List<ShowShop.Model.Member.Roles_Permissions> GetNewList(int RoleID)
        {
            List<ShowShop.Model.Member.Roles_Permissions> list = new List<ShowShop.Model.Member.Roles_Permissions>();
            ShowShop.Model.Member.Roles_Permissions rModel = null;
            foreach (TreeNode tNode in TreeView1.CheckedNodes)
            {
                rModel = new ShowShop.Model.Member.Roles_Permissions();
                rModel.ID = RoleID;
                if (ChangeHope.Common.ValidateHelper.IsNumber(tNode.Value))
                {
                    rModel.OperateCode = int.Parse(tNode.Value);
                }
                else
                {
                    continue;
                }
                list.Add(rModel);
                rModel = null;
            }
            return list;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<ShowShop.Model.Member.Roles_Permissions> oldList = bll.GetListByColumn("id", RoleID);
            List<ShowShop.Model.Member.Roles_Permissions> newList = GetNewList(RoleID);
            //try
            //{
                if (statebl)//特殊权限关闭
                {
                    if (oldList.Count > 0)
                    {
                        //if (!ShowShop.Common.PowerPass.isPass("007003004", ShowShop.Common.PowerEnum.PowerType.update))
                        //{
                        //    //bp = new BasePage();
                        //    //bp.PageError("对不起，你没有修改角色权限的权限！", "../index.aspx");
                        //}
                        UpdatePowers(newList, oldList);
                    }
                    else
                    {
                        //if (!ShowShop.Common.PowerPass.isPass("007003002", ShowShop.Common.PowerEnum.PowerType.add))
                        //{
                        //    //bp = new BasePage();
                        //    //bp.PageError("对不起，你没有添加角色权限的权限！", "../index.aspx");
                        //}
                        bll.Add(newList);
                    }
                }
                else
                {
                    int counter = 0;
                    string powerStr = "";
                    foreach (ListItem lItem in CheckBoxList1.Items)
                    {
                        if (lItem.Selected)
                        {
                            powerStr += lItem.Value + ",";
                        }
                    }
                    powerStr = powerStr.TrimEnd(',');
                    string[] powerArr = powerStr.Split(',');
                    counter = powerArr.Length;
                    int roleValue = 0;
                    if (counter == 1) //look
                    {
                        roleValue =ShowShop.Common.PowerEnum.PowerType.look.GetHashCode();
                    }
                    else if (counter == 2) //add,del,update
                    {
                        switch (powerArr[1])
                        {
                            case "add":
                                roleValue = ShowShop.Common.PowerEnum.PowerType.add.GetHashCode();
                                break;
                            case "del":
                                roleValue = ShowShop.Common.PowerEnum.PowerType.del.GetHashCode();
                                break;
                            case "update":
                                roleValue = ShowShop.Common.PowerEnum.PowerType.update.GetHashCode();
                                break;
                        }
                    }
                    else if (counter == 3) //deladd, delupdate, updateadd
                    {
                        switch (powerArr[1])
                        {
                            case "add":
                                switch (powerArr[2])
                                {
                                    case "del":
                                        roleValue = ShowShop.Common.PowerEnum.PowerType.deladd.GetHashCode();
                                        break;
                                    case "update":
                                        roleValue = ShowShop.Common.PowerEnum.PowerType.updateadd.GetHashCode();
                                        break;
                                }
                                break;
                            case "del":
                                switch (powerArr[2])
                                {
                                    case "add":
                                        roleValue = ShowShop.Common.PowerEnum.PowerType.deladd.GetHashCode();
                                        break;
                                    case "update":
                                        roleValue = ShowShop.Common.PowerEnum.PowerType.delupdate.GetHashCode();
                                        break;
                                }
                                break;
                            case "update":
                                switch (powerArr[2])
                                {
                                    case "add":
                                        roleValue = ShowShop.Common.PowerEnum.PowerType.updateadd.GetHashCode();
                                        break;
                                    case "del":
                                        roleValue = ShowShop.Common.PowerEnum.PowerType.delupdate.GetHashCode();
                                        break;
                                }
                                break;
                        }
                    }
                    else //all,other
                    {
                        roleValue = ShowShop.Common.PowerEnum.PowerType.all.GetHashCode();
                    }
                    //try//权限设置
                    //{
                        if (ispower)
                        {
                            //if (! ShowShop.Common.PowerPass.isPass("007003004", ShowShop.Common.PowerEnum.PowerType.update))
                            //{
                            //    //bp = new BasePage();
                            //    //bp.PageError("对不起，你没有修改角色权限的权限！", "../index.aspx");
                            //}
                        }
                        else
                        {
                            //if (!ShowShop.Common.PowerPass.isPass("007003002", ShowShop.Common.PowerEnum.PowerType.add))
                            //{
                            //    //bp = new BasePage();
                            //    //bp.PageError("对不起，你没有添加角色权限的权限！", "../index.aspx");
                            //}
                        }
                        ShowShop.Model.Member.Roles_Permissions rpModel = new ShowShop.Model.Member.Roles_Permissions();
                        rpModel.ID = RoleID;
                        rpModel.OperateCode = roleValue;
                        bll.Delete(RoleID);

                        List<ShowShop.Model.Member.Roles_Permissions> rpList = new List<ShowShop.Model.Member.Roles_Permissions>();
                        rpList.Add(rpModel);
                        bll.Add(rpList);
                    //}
                    //catch { }
                }
                ChangeHope.WebPage.BasePage.PageRight("设置成功。", "popedom_manage.aspx");
                //Response.Redirect("popedom_manage.aspx", true);
            //}
            //catch { }
        }

        protected void TreeView1_DataBound(object sender, EventArgs e)
        {
            InitPowers(RoleID);
        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool bl = false;
            int c = 0;
            string str = "注:你选择了</br><font style='color:red'>";
            bool isLook = false;
            foreach (ListItem lItem in CheckBoxList1.Items)
            {
                if (lItem.Selected)
                {
                    if (lItem.Value != "look")
                    {
                        isLook = true;
                    }
                        bl = true;
                        str += lItem.Text + "，";
                        c++; 
                }
            }
            if (isLook)
            {
                CheckBoxList1.Items[0].Selected = true;
            }
            if (bl)
            {
                TreeView1.Enabled = false;
                foreach (TreeNode tNode in TreeView1.Nodes)
                {
                    tNode.CollapseAll();
                }
                statebl = false;//特殊权限启用
            }
            else
            {
                statebl = true;//特殊权限关闭default
                TreeView1.Enabled = true;
            }
            if (c == CheckBoxList1.Items.Count)
            {
                str = "注:你选择了</br><font style='color:red;'>所有权限,一般只有默认的管理员才应该拥有此权限</font>";
            }
            else
            {
                str = str.TrimEnd('，');
                str += "</font>";
            }
            showMSG.Text = str;
        }

    }
}

