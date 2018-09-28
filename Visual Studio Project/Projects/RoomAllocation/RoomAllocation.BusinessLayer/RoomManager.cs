using RoomAllocation.DataAccessLayer;
using RoomAllocation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomAllocation.BusinessLayer
{
    public class RoomManager
    {
        readonly RoomDataAccess roomDataAccess = new RoomDataAccess();
        public IEnumerable<Room> RoomDetails()
        {
            return roomDataAccess.RoomDetails().ToList();
        }

        public Room FindRoom(int? id)
        {
            return roomDataAccess.FindRoom(id);
        }

        public int AddRoom(Room room)
        {
            return roomDataAccess.AddRoom(room);
        }

        public int RemoveRoom(Room room)
        {
            return roomDataAccess.RemoveRoom(room);
        }

        public void EditRoom(EntityState entity, Room room)
        {
            roomDataAccess.EditUser(entity, room);
        }
    }
}
