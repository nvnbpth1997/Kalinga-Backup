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
    public class AMSModelsController : ApiController
    {
        private AmsDbContext db = new AmsDbContext();
        // GET: api/AMSModels
        public IQueryable<AMSModel> GetEmployees()
        {
            return db.Employees.Where(x => x.Day == DateTime.Today).OrderBy(a => a.FirstName);
        }

        // GET: api/AMSModels/5
        [HttpGet]
        [Route("api/AMSModels/BySwipe/{value}")]
        public IQueryable<AMSModel> GetEmployees(int value)
        {
            return db.Employees
                 .Where(m => m.SwipeStatus == value).Where(x => x.Day == DateTime.Today).OrderBy(a => a.FirstName);          
        }

        //[HttpGet]
        //[Route("api/AMSModels/{id}")]
        //public AMSModel GetEmployee(int id)
        //{
        //    return db.Employees.Find(id);
        //}

        [HttpGet]
        [Route("api/AMSModels/ByDefaulter")]
        public IQueryable<AMSModel> GetDefaulters()
        {
            return db.Employees
                   .GroupBy(a => new { a.MID, a.SwipeStatus })
                   .Where(a => a.Count(b => a.Key.SwipeStatus == -1) >1)
                   .Select(a=>a.FirstOrDefault()).OrderBy(a => a.FirstName);
        }


        [HttpGet]
        [Route("api/AMSModels/ByDefaulterTrack/{value}")]
        public IQueryable<AMSModel> GetDefaultersTrack(int value)
        {
            DateTime To = DateTime.Today;
            DateTime From = To.AddMonths(value);
            return db.Employees
                   .Where(a => (a.Day >= From && a.Day <= To) && (a.SwipeStatus == -1))
                   .GroupBy(a => a.MID)
                   .Select(a => a.FirstOrDefault()).OrderBy(a=>a.FirstName);
        }

        [HttpGet]
        [Route("api/AMSModels/ByDefaulterDateTrack/{from}/{to}")]
        public IQueryable<AMSModel> GetDefaultersTrack(DateTime from, DateTime to)
        {
            return db.Employees
                   .Where(a => (a.Day >= from && a.Day <= to) && (a.SwipeStatus == -1))
                   .GroupBy(a => a.MID)
                   .Select(a => a.FirstOrDefault()).OrderBy(a => a.FirstName);
        }

        
        //[ResponseType(typeof(AMSModel))]
        //public async Task<IHttpActionResult> GetAMSModel(int id)
        //{
        //    AMSModel aMSModel = await db.Employees.FindAsync(id);
        //    if (aMSModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(aMSModel);
        //}

        // PUT: api/AMSModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAMSModel(int id, AMSModel aMSModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != aMSModel.ID)
            {
                return BadRequest();
            }

            db.Entry(aMSModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AMSModelExists(id))
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

        // POST: api/AMSModels
        //[ResponseType(typeof(AMSModel))]
        //public async Task<IHttpActionResult> PostAMSModel(AMSModel aMSModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Employees.Add(aMSModel);
        //    await db.SaveChangesAsync();

        //    return CreatedAtRoute("DefaultApi", new { id = aMSModel.ID }, aMSModel);

        //public byte[] imageToByteArray(System.Drawing.Image imageIn)
        //{
        //    MemoryStream ms = new MemoryStream();
        //    imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
        //    return ms.ToArray();
        //}
        //}

        //[HttpPost]
        //[Route("api/AMSModels/UploadImage")]
        //public HttpResponseMessage UploadImage()
        //{
        //    Image image = new Image();
        //    var httpRequest = HttpContext.Current.Request;
        //    //Upload Image
        //    var postedFile = httpRequest.Files["Image"];

        //    image.ImageName = postedFile.FileName;
        //    using (var binaryReader = new BinaryReader(postedFile.InputStream))
        //    {
        //        image.ImageContent = binaryReader.ReadBytes(postedFile.ContentLength);
        //    }
           
        //    //Save to DB
        //    db.Images.Add(image);
        //    db.SaveChanges();

        //    return Request.CreateResponse(HttpStatusCode.Created);
        //}

    // DELETE: api/AMSModels/5
    [ResponseType(typeof(AMSModel))]
        public async Task<IHttpActionResult> DeleteAMSModel(int id)
        {
            AMSModel aMSModel = await db.Employees.FindAsync(id);
            if (aMSModel == null)
            {
                return NotFound();
            }

            db.Employees.Remove(aMSModel);
            await db.SaveChangesAsync();

            return Ok(aMSModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AMSModelExists(int id)
        {
            return db.Employees.Count(e => e.ID == id) > 0;
        }
    }
}