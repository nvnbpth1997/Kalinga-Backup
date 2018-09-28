using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using RoomAllocation.Models;

namespace RoomAllocation.Context
{
    public class RoomAllocateContext : DbContext
    {
        public RoomAllocateContext() : base("RoomAllocation")
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<AllocateRoom> AllocateRooms { get; set; }
    }

   
}