using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FoodRunner.Models
{
    public class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public virtual ICollection<ShoppingCartProduct> Products { get; set; }
    }

}