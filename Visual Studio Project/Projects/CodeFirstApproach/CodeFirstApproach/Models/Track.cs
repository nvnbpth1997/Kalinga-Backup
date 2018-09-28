using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
//public string RoomAllocated { get; set; }



namespace CodeFirstApproach.Models
{
    [Table("Track")]
    public class Track
    {
        [Key]
        public string Track_Id { get; set; }
        public string Track_Name { get; set; }
        public string LeadName { get; set; }
    }
}