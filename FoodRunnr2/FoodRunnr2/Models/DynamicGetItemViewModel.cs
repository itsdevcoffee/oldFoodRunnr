using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodRunnr2.Models
{
    public class DynamicGetItemViewModel
    {
        public string ImageUrl { get; set; }
        public int ProductId { get; set; }
        public int ShoppingCartId { get; set; }
        public int Quantity { get; set; }
        public bool IsNew { get; set; }
    }
}