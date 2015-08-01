using FoodRunner.Models;
using FoodRunnr2.Models;
using FoodRunnr2.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FoodRunnr2.Controllers.Api
{
    public class ItemsController : ApiController
    {
        private DataContext db = new DataContext();
        private ShoppingListRepository _repo = new ShoppingListRepository();

        public IList<ItemViewModel> GetItems()
        {
            return db.Products.Select(i => new ItemViewModel
            {
                Id = i.Id,
                ProductName = i.ProductName,
                ProductPrice = i.ProductPrice,
                ProduceImageUrl = i.ProductImageUrl
            }).ToList();
        }

        public IHttpActionResult Post(ShoppingCartProduct product)
        {
            DynamicGetItemViewModel temp = _repo.addItem(product.ProductId, product.ShoppingCartId);
            return Ok(temp);
        }


    }
}
