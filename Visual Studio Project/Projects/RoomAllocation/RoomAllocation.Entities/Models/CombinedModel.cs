using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoomAllocation.Models
{
    public class CombinedModel
    {
        public User users { get; set; }
        public Room rooms { get; set; }
        public AllocateRoom allocatedRooms { get; set; }
    }
}