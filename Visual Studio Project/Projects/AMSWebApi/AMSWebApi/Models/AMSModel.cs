using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AMSWebApi.Models
{
    [Table("AMSTable")]
    public class AMSModel
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(8)]
        [Required]
        public string MID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string  LastName { get; set; }
        [Index(IsUnique = true)]
        [MaxLength(10)]
        [Required]
        public string Mobile { get; set; }
        [Index(IsUnique = true)]
        [MaxLength(450)]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Gender { get; set; }

        [Required]
        public DateTime Day { get; set; }

        [Required]
        public string SwipeInTime { get; set; }
        [Required]
        public int SwipeStatus { get; set; }
    }
}