using RoomAllocation.Context;
using RoomAllocation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomAllocation.DataAccessLayer
{
   public class AllocateDataAccess
    {
        readonly RoomAllocateContext db = new RoomAllocateContext();
        public IEnumerable<CombinedModel> filteredUsers()
        {
            var filteredUsers = (from u in db.Users
                                 join ar in db.AllocateRoom on u.userID equals ar.userID into uar
                                 from ar in uar.DefaultIfEmpty().Distinct()
                                 join r in db.Rooms on ar.roomID equals r.roomID into rar
                                 from r in rar.DefaultIfEmpty().Distinct()
                                 select new CombinedModel { rooms = r, users = u, allocatedRooms = ar }).ToList();
            return filteredUsers;
        }

        public IEnumerable<CombinedModel> filteredRooms(int? id)
        {
            var subselect = (from ar in db.AllocateRoom
                             select ar.roomID).ToList();

            var filteredRooms = (from r in db.Rooms
                                 where !subselect.Contains(r.roomID)
                                 join u in db.Users on id equals u.userID
                                 select new CombinedModel
                                 {
                                     rooms = r,
                                     users = u
                                 }).ToList();
            return filteredRooms;
        }

        public CombinedModel Details(int id, int id2)
        {
            AllocateRoom allocateRoom = new AllocateRoom();
            allocateRoom.roomID = id;
            allocateRoom.userID = id2;
            db.AllocateRoom.Add(allocateRoom);
            db.SaveChanges();

            CombinedModel c = new CombinedModel();
            c.rooms = db.Rooms.Find(id); 
            c.users = db.Users.Find(id2);
            c.allocatedRooms = allocateRoom;

            return c;
        }
    }
}
