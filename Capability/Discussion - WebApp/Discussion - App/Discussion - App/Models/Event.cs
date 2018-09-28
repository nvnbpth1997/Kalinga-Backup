using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Discussion___App.Models
{
    [Table("Event")]
    public class Event
    {
        [Key]
        public int ID { get; set; }
        public string eventName { get; set; }
        public string participantName { get; set; }
    }
}