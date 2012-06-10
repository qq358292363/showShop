using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShowShop.Model.Order;

namespace ShowShop.BLL.Order
{
    [Serializable]
    public class Cart
    {
        // 内部储存车	  
        private Dictionary<string, CartItemInfo> cartItems = new Dictionary<string, CartItemInfo>();

        
        /// <summary>
        /// Update the quantity for item that exists in the cart
        /// </summary>
        /// <param name="itemId">Item Id</param>
        /// <param name="qty">Quantity</param>
        public void SetQuantity(string itemId, int qty)
        {
            
            cartItems[itemId].Quantity = qty;
        }

        /// <summary>
        /// Return the number of unique items in cart
        /// </summary>
        public int Count
        {
            get { return cartItems.Count; }
        }

        /// <summary>
        /// Calculate the total for all the cartItems in the Cart
        /// </summary>
        public int Quantity
        {
            get
            {
                int Quantity = 0;
                foreach (CartItemInfo item in cartItems.Values)
                    Quantity += item.Quantity;
                return Quantity;
            }
        }

        /// <summary>
        /// 向购物车中添加商品信息
        /// </summary>
        /// <param name="ProId"></param>
        /// <param name="Color"></param>
        /// <param name="Quantity"></param>
        /// <param name="yardage"></param>
        public void Add(string ProId, string specification, int Quantity, string fittingsProductId, string fittingsProductCount,int sparepartId)
        {
            string CartKey = ChangeHope.Common.DEncryptHelper.GetRandomNumber();
            CartItemInfo cartItem=new CartItemInfo() ;
            foreach (CartItemInfo item in cartItems.Values)
            {
                if (item.ProductId == ProId && item.Specification == specification)
                {
                    bool isFittingsProductId = false;
                    if (!string.IsNullOrEmpty(fittingsProductId.Trim()))
                    {
                        string[] fitProArr = fittingsProductId.Split(',');
                        if (!string.IsNullOrEmpty(item.FittingsProductId.Trim()))
                        {
                            string[] shopFitProArr = item.FittingsProductId.Split(',');
                            for (int f = 0; f < fitProArr.Length; f++)
                            {
                                for (int s = 0; s < shopFitProArr.Length; s++)
                                {
                                    if (fitProArr[f] != shopFitProArr[s])
                                    {
                                        isFittingsProductId = true;
                                        break;
                                    }
                                }
                                if (isFittingsProductId)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    if (!isFittingsProductId)
                    {
                        CartKey = item.CartKey;
                    }
                    break;
                }
            }
            if (!cartItems.TryGetValue(CartKey, out cartItem))
            {
                CartItemInfo newItem = new CartItemInfo(CartKey, ProId, Quantity, specification, fittingsProductId, fittingsProductCount,sparepartId.ToString());
                cartItems.Add(CartKey, newItem); 
            }
            else
            {
                cartItem.Quantity += Quantity; 
            }
        }

        /// <summary>
        /// Add an item to the cart.
        /// When ItemId to be added has already existed, this method will update the quantity instead.
        /// </summary>
        /// <param name="item">Item to add</param>
        public void Add(CartItemInfo item)
        {
            CartItemInfo cartItem;
            if (!cartItems.TryGetValue(item.CartKey.ToString(), out cartItem))
                cartItems.Add(item.CartKey.ToString(), item);
            else
                cartItem.Quantity += item.Quantity;
        }

        /// <summary>
        /// 从购物车中删除
        /// </summary>
        /// <param name="itemId">删除ID</param>
        public void Remove(string itemId)
        {
            cartItems.Remove(itemId);
        }

        /// <summary>
        /// Returns all items in the cart. Useful for looping through the cart.
        /// </summary>
        /// <returns>Collection of CartItemInfo</returns>
        public ICollection<CartItemInfo> CartItems
        {
            get { return cartItems.Values; }
        }


        /// <summary>
        /// Clear the cart
        /// </summary>
        public void Clear()
        {
            cartItems.Clear();
        }
    }
}

