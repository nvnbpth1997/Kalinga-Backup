using RoomAllocation.BusinessLayer;
using RoomAllocation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace RoomAllocation.Controllers
{
    public class RoomAllocateController : Controller
    {
        readonly AllocateManager allocateManager = new AllocateManager();

        //GET: RoomAllocate
               
        public ActionResult Index()
        {
            return View(allocateManager.filteredUsers());
        }

        [Route("RoomAllocate/Allocate/{id}")]
        public ActionResult Allocate(int? id)
        {  
            return View(allocateManager.filteredRooms(id));
        }

        
        public ActionResult RoomSelect(int id, int id2)
        {
            return View(allocateManager.Details(id, id2));
        }

    }
}