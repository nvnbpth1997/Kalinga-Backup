using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracking.Entities
{
    public class Holidays
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Hid { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Input/Output Required")]
        public DateTime Datetime { get; set; }
        
}
}
