using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CosmeticStore.Models
{
    public class Favourite
    {
        [Key]
        public int fid { get; set; }
        [ForeignKey("User")]
        public int uid { get; set; }
        public User User { get; set; }

        [ForeignKey("Cosmetic")]
        public int cid { get; set; }
        public Cosmetic Cosmetic { get; set; }
    }
}