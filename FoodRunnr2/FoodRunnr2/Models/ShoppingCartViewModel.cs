using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodRunnr2.Models
{
    public class ShoppingCartViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public IList<ShoppingCartItemViewModel> Items { get; set; }
    }
    public class ShoppingCartItemViewModel
    {
        public int Quantity { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProduceImageUrl { get; set; }
    }
}