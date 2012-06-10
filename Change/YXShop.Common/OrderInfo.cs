using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web;

namespace ShowShop.Common
{
    public class OrderInfo
    {
        #region 运费计算
        public static string TotalFreight(int Distribution, float ProductWeight,float ProductPrice,int ProductCount)
        {
            ShowShop.BLL.SystemInfo.PostArea pabll = new ShowShop.BLL.SystemInfo.PostArea();
            ShowShop.Model.SystemInfo.PostArea pamodel = pabll.GetModelID(Distribution);
            double freight = 0;
            if (pamodel != null)
            {
                switch (pamodel.Deliverymode)
                {
                    case 2:
                        if (pamodel.Freeamount >= ProductPrice)
                        {
                            freight = Convert.ToDouble(pamodel.Basicfees);
                        }
                        break;
                    case 3:
                        if (pamodel.Freeamount >= ProductPrice)
                        {
                            if (pamodel.Feescalculationway == 1)
                            {
                                if (ProductWeight <= 500)
                                {
                                    freight = pamodel.Basicfees;
                                }
                                else if (ProductWeight > 500)
                                {
                                    int freightCount = Convert.ToInt32(ProductWeight / 500);
                                    if (ProductWeight % 500 != 0)
                                    {
                                        freightCount = freightCount + 1;
                                    }
                                    freight = pamodel.Overweight * (freightCount - 1);
                                }
                            }
                            else
                            {
                                freight = pamodel.Initialfees * ProductCount;
                            }
                        }
                        
                        break;
                    case 4:
                        if (pamodel.Freeamount >= ProductPrice)
                        {
                            freight = Convert.ToDouble(pamodel.Basicfees);
                        }
                        break;
                    case 6:
                        if (pamodel.Freeamount >= ProductPrice)
                        {
                            if (pamodel.Feescalculationway == 1)
                            {
                                if (ProductWeight <= 1000)
                                {
                                    freight = Convert.ToDouble(pamodel.Basicfees);
                                }
                                else if (ProductWeight <= 5000 && 1000 < ProductWeight)
                                {
                                    int freightCount = Convert.ToInt32(ProductWeight / 500);
                                    if (ProductWeight % 500 != 0)
                                    {
                                        freightCount = freightCount + 1;
                                    }
                                    freight = pamodel.Overweight * (freightCount - 1);
                                }
                                else if (ProductWeight > 5000)
                                {
                                    int freightCount = Convert.ToInt32(ProductWeight / 500);
                                    if (ProductWeight % 500 != 0)
                                    {
                                        freightCount = freightCount + 1;
                                    }
                                    freight = pamodel.Overweight2 * (freightCount - 1);
                                }
                            }
                            else
                            {
                                freight = pamodel.Initialfees * ProductCount;
                            }
                        }
                        break;
                    case 7:
                        if (pamodel.Freeamount >= ProductPrice)
                        {
                            if (pamodel.Feescalculationway == 1)
                            {
                                if (ProductWeight <= 1000)
                                {
                                    freight = Convert.ToDouble(pamodel.Basicfees + pamodel.Packagingcosts);
                                }
                                else if (ProductWeight <= 5000 && 1000 < ProductWeight)
                                {
                                    int freightCount = Convert.ToInt32(ProductWeight / 1000);
                                    if (ProductWeight % 1000 != 0)
                                    {
                                        freightCount = freightCount + 1;
                                    }
                                    freight = (pamodel.Overweight * (freightCount - 1)) + pamodel.Packagingcosts;
                                }
                                else if (ProductWeight > 5000)
                                {
                                    int freightCount = Convert.ToInt32(ProductWeight / 1000);
                                    if (ProductWeight % 1000 != 0)
                                    {
                                        freightCount = freightCount + 1;
                                    }
                                    freight = (pamodel.Overweight2 * (freightCount - 1)) + pamodel.Packagingcosts;
                                }
                            }
                            else
                            {
                                freight = pamodel.Initialfees * ProductCount;
                            }
                        }
                        break;
                    case 8:
                        if (pamodel.Freeamount >= ProductPrice)
                        {
                            if (pamodel.Feescalculationway == 1)
                            {
                                if (ProductWeight <= 1000)
                                {
                                    freight = pamodel.Basicfees;
                                }
                                else if (ProductWeight > 1000)
                                {
                                    int freightCount = Convert.ToInt32(ProductWeight / 1000);
                                    if (ProductWeight % 1000 != 0)
                                    {
                                        freightCount = freightCount + 1;
                                    }
                                    freight = pamodel.Overweight * (freightCount - 1);
                                }
                            }
                            else
                            {
                                freight = pamodel.Initialfees * ProductCount;
                            }
                        }
                        break;
                    case 9:
                        if (pamodel.Freeamount >= ProductPrice)
                        {
                            if (pamodel.Feescalculationway == 1)
                            {
                                if (ProductWeight <= 1000)
                                {
                                    freight = pamodel.Basicfees;
                                }
                                else if (ProductWeight > 1000)
                                {
                                    int freightCount = Convert.ToInt32(ProductWeight / 1000);
                                    if (ProductWeight % 1000 != 0)
                                    {
                                        freightCount = freightCount + 1;
                                    }
                                    freight = pamodel.Overweight * (freightCount - 1);
                                }
                            }
                            else
                            {
                                freight = pamodel.Initialfees * ProductCount;
                            }
                        }
                        break;
                    case 10:
                        if (pamodel.Freeamount >= ProductPrice)
                        {
                            if (pamodel.Feescalculationway == 1)
                            {
                                if (ProductWeight <= 1000)
                                {
                                    freight = pamodel.Basicfees;
                                }
                                else if (ProductWeight > 1000)
                                {
                                    freight = pamodel.Basicfees + pamodel.Overweight;
                                }
                            }
                            else
                            {
                                freight = pamodel.Initialfees * ProductCount;
                            }
                        }
                        break;
                    case 11:
                        if (pamodel.Freeamount >= ProductPrice)
                        {
                            if (pamodel.Feescalculationway == 1)
                            {
                                if (ProductWeight <= 1000)
                                {
                                    freight = pamodel.Basicfees;
                                }
                                else if (ProductWeight > 1000)
                                {
                                    int freightCount = Convert.ToInt32(ProductWeight / 1000);
                                    if (ProductWeight % 1000 != 0)
                                    {
                                        freightCount = freightCount + 1;
                                    }
                                    freight = pamodel.Overweight * (freightCount - 1);
                                }
                            }
                            else
                            {
                                freight = pamodel.Initialfees * ProductCount;
                            }
                        }
                        break;
                }

            }
            return freight.ToString("f2");
        }
        #endregion

      
    }
}
