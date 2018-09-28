using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RoomAllocation.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int userID { get; set; }

        [DisplayName("MID")]
        public string user_mid { get; set; }
        [DisplayName("Name")]
        public string user_name { get; set; }
        [DisplayName("Track Name")]
        public string user_trackName { get; set; }
        public int user_totalCost { get; set; }

    }
}