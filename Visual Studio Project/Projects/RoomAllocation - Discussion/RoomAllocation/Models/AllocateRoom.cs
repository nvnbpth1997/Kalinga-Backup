using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RoomAllocation.Models
{
    public class AllocateRoom
    {
        [Key]
        public int AllocateRoomID { get; set; }

        [ForeignKey("Room")]
        [Index(IsUnique = true)]
        public int roomID { get; set; }

        public Room Room { get; set; }

        [ForeignKey("User")]
        public int userID { get; set; }

        public User User { get; set; }
    }
}