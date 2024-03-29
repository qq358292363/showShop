﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YXShop.Model.Order;

namespace YXShop.IDAL.Order
{
    /// <summary>
    /// Interface to the Item DAL
    /// </summary>
    public interface IItem
    {

        /// <summary>
        /// Search items by productId
        /// </summary>
        /// <param name="productId">ProductId to search for</param>
        /// <returns>Interface to Model Collection Generic of the results</returns>
        IList<ItemInfo> GetItemsByProduct(string productId);

        /// <summary>
        /// Get information on a specific item
        /// </summary>
        /// <param name="itemId">Unique identifier for an item</param>
        /// <returns>Business Entity representing an item</returns>
        ItemInfo GetItem(string itemId);
    }
}
