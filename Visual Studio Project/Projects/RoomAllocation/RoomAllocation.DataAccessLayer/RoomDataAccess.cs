using RoomAllocation.Context;
using RoomAllocation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomAllocation.DataAccessLayer
{
    public class RoomDataAccess
    {
        RoomAllocateContext db = new RoomAllocateContext();
        public DbSet<Room> RoomDetails()
        {
            return db.Rooms;
        }

        public Room FindRoom(int? id)
        {
            return db.Rooms.Find(id);
        }

        public int AddRoom(Room room)
        {
            db.Rooms.Add(room);
            return db.SaveChanges();
        }

        public int RemoveRoom(Room room)
        {
            db.Rooms.Remove(room);
            return db.SaveChanges();
        }

        public void EditUser(EntityState entity, Room room)
        {
            db.Entry(room).State = entity;
            db.SaveChanges();
        }

    }
}
