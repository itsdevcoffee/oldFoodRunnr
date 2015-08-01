﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FoodRunner.Models;
using FoodRunnr2.Models;
using Newtonsoft.Json;

namespace FoodRunnr2.Controllers.Api
{
    public class ShoppingCartsController : ApiController
    {

        private DataContext db = new DataContext();

        // GET: api/ShoppingCarts
        public IList<ShoppingCartViewModel> GetShoppingCarts()
        {
            return db.ShoppingCarts.Select(s => new ShoppingCartViewModel
            {
                Id = s.Id,
                UserName = s.Username,
                Items = s.Products.Select(p => new ShoppingCartItemViewModel
                {
                    ProductName = p.Product.ProductName,
                    ProductPrice = p.Product.ProductPrice,
                    ProduceImageUrl = p.Product.ProductImageUrl,
                    Quantity = p.Quantity
                }).ToList()
            }).ToList();
        }



        // GET: api/ShoppingCarts/5
        [ResponseType(typeof(ShoppingCart))]
        public IHttpActionResult GetShoppingCart(int id)
        {
            ShoppingCart shoppingCart = db.ShoppingCarts.Find(id);
            if (shoppingCart == null)
            {
                return NotFound();
            }

            return Ok(shoppingCart);
        }

        // PUT: api/ShoppingCarts/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutShoppingCart(int id, ShoppingCart shoppingCart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != shoppingCart.Id)
            {
                return BadRequest();
            }

            db.Entry(shoppingCart).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ShoppingCartExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ShoppingCarts
        [ResponseType(typeof(ShoppingCart))]
        public IHttpActionResult PostShoppingCart(ShoppingCart shoppingCart)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ShoppingCarts.Add(shoppingCart);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = shoppingCart.Id }, shoppingCart);
        }

        // DELETE: api/ShoppingCarts/5
        [ResponseType(typeof(ShoppingCart))]
        public IHttpActionResult DeleteShoppingCart(int id)
        {
            ShoppingCart shoppingCart = db.ShoppingCarts.Find(id);
            if (shoppingCart == null)
            {
                return NotFound();
            }

            db.ShoppingCarts.Remove(shoppingCart);
            db.SaveChanges();

            return Ok(shoppingCart);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ShoppingCartExists(int id)
        {
            return db.ShoppingCarts.Count(e => e.Id == id) > 0;
        }
    }
}