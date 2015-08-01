using FoodRunner.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FoodRunnr2.Models
{
    public class DataContext : DbContext
    {
        public IDbSet<Product> Products { get; set; }
        public IDbSet<ShoppingCart> ShoppingCarts { get; set; }
        public IDbSet<ShoppingCartProduct> ShoppingCartProducts { get; set; }
    }
}