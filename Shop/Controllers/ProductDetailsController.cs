using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Shop.Models;
using Shop.Models.Entities;

namespace Shop.Controllers
{
    public class ProductDetailsController : ApiController
    {
        private ShopContext db = new ShopContext();

        // GET: api/ProductDetails
        public IQueryable<ProductDetail> GetProductDetails()
        {
            return db.ProductDetails;
        }

        // GET: api/ProductDetails/5
        [ResponseType(typeof(ProductDetail))]
        public async Task<IHttpActionResult> GetProductDetail(int id)
        {
            ProductDetail productDetail = await db.ProductDetails.FindAsync(id);
            if (productDetail == null)
            {
                return NotFound();
            }

            return Ok(productDetail);
        }

        // PUT: api/ProductDetails/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutProductDetail(int id, ProductDetail productDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productDetail.Id)
            {
                return BadRequest();
            }

            db.Entry(productDetail).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductDetailExists(id))
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

        // POST: api/ProductDetails
        [ResponseType(typeof(ProductDetail))]
        public async Task<IHttpActionResult> PostProductDetail(ProductDetail productDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductDetails.Add(productDetail);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = productDetail.Id }, productDetail);
        }

        // DELETE: api/ProductDetails/5
        [ResponseType(typeof(ProductDetail))]
        public async Task<IHttpActionResult> DeleteProductDetail(int id)
        {
            ProductDetail productDetail = await db.ProductDetails.FindAsync(id);
            if (productDetail == null)
            {
                return NotFound();
            }

            db.ProductDetails.Remove(productDetail);
            await db.SaveChangesAsync();

            return Ok(productDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductDetailExists(int id)
        {
            return db.ProductDetails.Count(e => e.Id == id) > 0;
        }
    }
}