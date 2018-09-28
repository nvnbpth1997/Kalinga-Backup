using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracking.Entities
{
    public class Settings
    {
        [Key]
        public int Sid { get; set; }
        public string Time { get; set; }
        public int Thresholdcount { get; set; }
        public string LateswipeText { get; set; }
        public string NotswipeText { get; set; }
        public string Category { get; set; }
    }
}
