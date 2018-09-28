using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RoomAllocation.Models
{
    [Table("Room")]
    public class Room
    {
        [Key]
        public int roomID { get; set; }

        [DisplayName("Room ID")]
        public string room_RID { get; set; }
        [DisplayName("Block Name")]
        public string room_blockName { get; set; }
        [DisplayName("Floor No.")]
        public int room_floorNumber { get; set; }
    }
}