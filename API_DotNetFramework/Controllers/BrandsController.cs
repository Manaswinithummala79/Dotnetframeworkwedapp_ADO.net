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
using API_DotNetFramework;
using API_DotNetFramework.Models;
using Newtonsoft.Json;

namespace API_DotNetFramework.Controllers
{
    public class BrandsController : ApiController
    {
        private BikeStoresEntities db = new BikeStoresEntities();

        //public BrandsController()
        //{
        //    db.Configuration.ProxyCreationEnabled = false;
        //    db.Configuration.LazyLoadingEnabled = false;
        //}

        // GET: api/Brands
        [Route("api/Brands")]
        public async Task<IHttpActionResult> Getbrands()
        {
            var data = await db.brands.Select(b => new BrandDTO
            {
                Id = b.brand_id,
                Name = b.brand_name
            }).ToListAsync();
            return Ok(data);
        }

        // GET: api/Brands/5        
        [ResponseType(typeof(brand))]
        public async Task<IHttpActionResult> Getbrand(int id)
        {
            brand brand = await db.brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            return Ok(brand);
        }

        // PUT: api/Brands/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> Putbrand(int id, brand brand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != brand.brand_id)
            {
                return BadRequest();
            }

            db.Entry(brand).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!brandExists(id))
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

        // POST: api/Brands
        [ResponseType(typeof(brand))]
        public async Task<IHttpActionResult> Postbrand(brand brand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.brands.Add(brand);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = brand.brand_id }, brand);
        }

        // DELETE: api/Brands/5
        [ResponseType(typeof(brand))]
        public async Task<IHttpActionResult> Deletebrand(int id)
        {
            brand brand = await db.brands.FindAsync(id);
            if (brand == null)
            {
                return NotFound();
            }

            db.brands.Remove(brand);
            await db.SaveChangesAsync();

            return Ok(brand);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool brandExists(int id)
        {
            return db.brands.Count(e => e.brand_id == id) > 0;
        }
    }
}