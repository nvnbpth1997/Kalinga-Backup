using RoomAllocation.Context;
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
        private readonly RoomAllocateContext db = new RoomAllocateContext();

        //GET: RoomAllocate
             
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        [Route("RoomAllocate/Allocate/{id}")]
        public ActionResult Allocate(int? id)
        {
           var subselect = (from ar in db.AllocateRooms
                             select ar.roomID).ToList();

            var filteredRooms = (from r in db.Rooms
                               where !subselect.Contains(r.roomID)
                               join u in db.Users on id equals u.userID
                               select new CombinedModel
                               {
                                   rooms = r, users = u
                               }).ToList();
            return View(filteredRooms);
        }

        
        public async Task<ActionResult> RoomSelect(int id, int id2)
        {
            Room room = await db.Rooms.FindAsync(id);
            User user = await db.Users.FindAsync(id2);

            AllocateRoom allocateRoom = new AllocateRoom();
            allocateRoom.roomID = room.roomID;
            allocateRoom.userID = user.userID;
            db.AllocateRooms.Add(allocateRoom);

            user.user_totalCost = user.user_totalCost + room.room_cost;
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
            }

            CombinedModel c = new CombinedModel();
            c.rooms = room;
            c.users = user;
            c.allocatedRooms = allocateRoom;
            await db.SaveChangesAsync();
            return View(c);
        }

    }
}