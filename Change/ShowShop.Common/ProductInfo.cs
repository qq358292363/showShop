using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;

namespace ShowShop.Common
{
    public class ProductInfo
    {
        #region 配件计算
        public static void FittingDisposal(string SparepartId, string FittingsProductId, string FittingsProductCount, out int FittingProductCount, out string fittingProductInfo, out double fittingTotalPrice,out double fittingProductWeight,out double fittingProductIntergal)
        {
            ShowShop.BLL.Product.ProductInfo productbll = new ShowShop.BLL.Product.ProductInfo();
            ShowShop.BLL.Product.ProductSparepart spabll = new ShowShop.BLL.Product.ProductSparepart();
            int favourableType = -1;
            double favourableLimit = 0;
            int productCount = 0;
            string fittingInfo = "";
            double strfittingPrice = 0;
            double productWeight = 0;
            double productIntergal = 0;
            if (!string.IsNullOrEmpty(SparepartId.Trim()) && Convert.ToInt32(SparepartId) > 0)
            {
                ShowShop.Model.Product.ProductSparepart sparModel = spabll.GetModelID(Convert.ToInt32(SparepartId));
                if (sparModel != null)
                {
                    favourableLimit = Convert.ToDouble(sparModel.FavourableLimit.ToString());
                    favourableType = sparModel.FavourableType;
                }
            }
            
            if (!string.IsNullOrEmpty(FittingsProductId))
            {
                string[] fittingProIdArr = FittingsProductId.Split(',');
                string[] fittingProCountArr = FittingsProductCount.Split(',');
                for (int c = 0; c < fittingProCountArr.Length; c++)
                {
                    if (!string.IsNullOrEmpty(fittingProCountArr[c].Trim()))
                    {
                        productCount += Convert.ToInt32(fittingProCountArr[c]);
                    }
                }
                for (int f = 0; f < fittingProIdArr.Length; f++)
                {
                    if (!string.IsNullOrEmpty(fittingProIdArr[f].Trim()))
                    {
                        DataTable prodt = productbll.GetAppointField("pro_ID,pro_Name,pro_ShopPrice,pro_RatingDiscount,pro_Specifications,pro_Weight,pro_DonateIntegral", " and pro_ID=" + fittingProIdArr[f]);
                        if (prodt.Rows.Count > 0)
                        {
                            productIntergal += Convert.ToDouble(prodt.Rows[0]["pro_DonateIntegral"].ToString());
                            productWeight += Convert.ToDouble(prodt.Rows[0]["pro_Weight"].ToString());
                            double price = Convert.ToDouble(prodt.Rows[0]["pro_ShopPrice"].ToString());
                            string memberPrice = prodt.Rows[0]["pro_RatingDiscount"].ToString();
                            if (!string.IsNullOrEmpty(prodt.Rows[0]["pro_Specifications"].ToString()))
                            {
                                //ShowShop.BLL.Product.ProductSpecification proSpe = new ShowShop.BLL.Product.ProductSpecification();
                                //List<ShowShop.Model.Product.ProductSpecification> proSpeList = proSpe.GetSpecification(Convert.ToInt32(prodt.Rows[0]["pro_ID"].ToString()));
                                //if (proSpeList.Count > 0)
                                //{
                                //    price = Convert.ToDouble(proSpeList[0].SalePrice);
                                //    memberPrice = proSpeList[0].MemberPrice;
                                //}
                            }
                            if (HttpContext.Current.Session["MemberID"] != null && !string.IsNullOrEmpty(memberPrice.Trim()))
                            {
                                price = ShowShop.Common.ProductInfo.DiscountedPrice(int.Parse(HttpContext.Current.Session["MemberID"].ToString()), price, memberPrice);
                            }

                            double fittingPrice = price;
                            if (HttpContext.Current.Session["MemberID"] != null)
                            {
                                fittingPrice = DiscountedPrice(Convert.ToInt32(HttpContext.Current.Session["MemberID"].ToString()), fittingPrice, prodt.Rows[0]["pro_RatingDiscount"].ToString());
                            }
                            
                            if (!string.IsNullOrEmpty(fittingProCountArr[f].Trim()))
                            {
                                fittingPrice = fittingPrice * Convert.ToInt32(fittingProCountArr[f]);
                            }
                            if (favourableType == 0 && favourableLimit > 0)
                            {
                                fittingPrice = fittingPrice * favourableLimit;
                            }
                            else if (favourableType == 1 && favourableLimit > 0)
                            {
                                fittingPrice = fittingPrice - favourableLimit;
                            }
                            strfittingPrice += fittingPrice;
                            fittingInfo += "&nbsp;+&nbsp;" + prodt.Rows[0]["pro_Name"].ToString() + "&nbsp;(" + fittingProCountArr[f] + ")";
                        }
                    }
                }
            }
            fittingProductWeight = productWeight;
            FittingProductCount = productCount;
            fittingTotalPrice = strfittingPrice;
            fittingProductInfo = fittingInfo;
            fittingProductIntergal=productIntergal;
        }
        #endregion

        #region 规格计算
        public static void SpecificationDisposal(int ProductId, string Specification, string MemberPrice,double Price, out double ProductPrice, out string ProductNo)
        {
            //ShowShop.BLL.Product.ProductSpecification spebll = new ShowShop.BLL.Product.ProductSpecification();
            ////规格
            //List<ShowShop.Model.Product.ProductSpecification> speList = spebll.GetSpecification(" and ProductId=" + ProductId + " and Specifications='" + Specification + "'");
            string itemNo = "";
            //if (speList.Count > 0)
            //{
            //    itemNo = speList[0].ProductCode;
            //    Price = Convert.ToDouble(speList[0].SalePrice.ToString());
            //    MemberPrice = speList[0].MemberPrice;
            //}
            if (HttpContext.Current.Session["MemberID"] != null)
            {
                Price = DiscountedPrice(Convert.ToInt32(HttpContext.Current.Session["MemberID"].ToString()), Price, MemberPrice);
            }
            ProductPrice = Price;
            ProductNo = itemNo;
        }
        #endregion

        #region 会员折扣
        public static double DiscountedPrice(int memberid, double price, string discountprice)//会员ID,商品id
        {
            double reprice = price;
            try
            {
                ShowShop.BLL.Member.MemberAccount memberbll = new ShowShop.BLL.Member.MemberAccount();
                ShowShop.Model.Member.MemberAccount membermodel = memberbll.GetModel(memberid);
                if (membermodel != null)
                {
                    int level = int.Parse(membermodel.UserGroup.ToString());
                    ShowShop.BLL.Member.MemberRank rankbll = new ShowShop.BLL.Member.MemberRank();
                    ShowShop.Model.Member.MemberRank rankmodel = rankbll.GetModel(level);
                    double Discount = 1;
                    if (rankmodel != null)
                    {
                        Discount = Convert.ToDouble(rankmodel.Discount.ToString());
                    }
                    string[] StrDiscountPrice = discountprice.Split('|');
                    if (StrDiscountPrice.Length > 0)
                    {
                        for (int i = 0; i < StrDiscountPrice.Length - 1; i++)
                        {
                            string[] DiscountPrice = StrDiscountPrice[i].Split(',');
                            string num = DiscountPrice[0].ToString();
                            if (Convert.ToInt32(num) == level)
                            {
                                reprice = Convert.ToDouble(DiscountPrice[0].ToString());
                                break;
                            }
                            else
                            {
                                if (rankmodel != null)
                                {
                                    reprice = price * Discount / 100;
                                }

                            }
                        }
                    }
                    else
                    {
                        reprice = price * Discount / 100;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return reprice;
        }

        #endregion
    }
}
