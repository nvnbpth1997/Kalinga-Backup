using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CodeFirstApproach.Models
{
    [Table("Mind")]
    public class Mind
    {
        [Key]
        public string MID { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Contact { get; set; }
        [ForeignKey("Track")]
        public string TrackId { get; set; }
        public Track Track { get; set; }
    }
}