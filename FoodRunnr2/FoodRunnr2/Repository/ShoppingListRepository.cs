using FoodRunner.Models;
using FoodRunnr2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodRunnr2.Repository
{
    public class ShoppingListRepository
    {
        private DataContext _db = new DataContext();

        public DynamicGetItemViewModel addItem(int productId, int shoppingListId)
        {
            bool isNew = false;
            ShoppingCartProduct temp = new ShoppingCartProduct();
            DynamicGetItemViewModel result = new DynamicGetItemViewModel();
            temp = _db.ShoppingCartProducts.Where(p => p.ProductId == productId).Where(m => m.ShoppingCartId == shoppingListId).FirstOrDefault();
            if(temp != null)
            {
                temp.Quantity++;
                isNew = false;
                _db.SaveChanges();
            }
            else
            {
                ShoppingCartProduct newItem = new ShoppingCartProduct()
                {
                    Quantity = 1,
                    ProductId = productId,
                    ShoppingCartId = shoppingListId
                };

                _db.ShoppingCartProducts.Add(newItem);
                _db.SaveChanges();
                temp = newItem;
                isNew = true;
            }
                result.ImageUrl = _db.Products.Where(p => p.Id == temp.ProductId).FirstOrDefault().ProductImageUrl;
                result.ProductId = temp.ProductId;
                result.ShoppingCartId = temp.ShoppingCartId;
                result.Quantity = temp.Quantity;
                result.IsNew = isNew;
            return result;
        }

        public ShoppingCartProduct getItems(int productId, int shoppingListId)
        {
            var temp = _db.ShoppingCartProducts.Where(p => p.ProductId == productId).Where(m => m.ShoppingCartId == shoppingListId).FirstOrDefault();
            return temp;
        }
    }
}