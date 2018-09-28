using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using AMSWebApi.Models;

namespace AMSWebApi.Controllers
{
    public class ImagesController : ApiController
    {
        private AmsDbContext db = new AmsDbContext();

        // GET: api/Images
        public IQueryable<Image> GetImages()
        {
            return db.Images;
        }

        [HttpGet]
        [Route("api/Images/Download/{mid}")]
        // GET: api/Images/5
        [ResponseType(typeof(Image))]
        public IHttpActionResult GetImage(string mid)
        {
            Image image = db.Images.SingleOrDefault(x => x.ImageName.Contains(mid));
            if (image == null)
            {
                return NotFound();
            }
            return Ok(image);
        }

        // PUT: api/Images/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutImage(int id, Image image)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != image.ID)
            {
                return BadRequest();
            }

            db.Entry(image).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ImageExists(id))
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

        // POST: api/Images
        [ResponseType(typeof(Image))]
        public async Task<IHttpActionResult> PostImage()
        {
            
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            int i = 0;
            var httpRequest = HttpContext.Current.Request;
            //Upload Image
            foreach (var file in httpRequest.Files)
            {
                Image image = new Image();
                var postedFile = httpRequest.Files[i];
                image.ImageName = postedFile.FileName;
                using (var binaryReader = new BinaryReader(postedFile.InputStream))
                {
                    byte[] imageContent = binaryReader.ReadBytes(postedFile.ContentLength);
                    image.ImageURL = "data:image/jpg;base64," + Convert.ToBase64String(imageContent);
                }
                i++;
                db.Images.Add(image);
                await db.SaveChangesAsync();
            }
            //var postedFile = httpRequest.Files["Image"];

            //image.ImageName = postedFile.FileName;
            //using (var binaryReader = new BinaryReader(postedFile.InputStream))
            //{
            //    byte[] imageContent = binaryReader.ReadBytes(postedFile.ContentLength);
            //    image.ImageURL = "data:image/jpg;base64," + Convert.ToBase64String(imageContent);
            //}
            return Ok();
        }

        // DELETE: api/Images/5
        [ResponseType(typeof(Image))]
        public async Task<IHttpActionResult> DeleteImage(int id)
        {
            Image image = await db.Images.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }

            db.Images.Remove(image);
            await db.SaveChangesAsync();

            return Ok(image);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ImageExists(int id)
        {
            return db.Images.Count(e => e.ID == id) > 0;
        }
    }
}