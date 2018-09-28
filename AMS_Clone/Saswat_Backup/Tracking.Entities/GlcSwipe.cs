using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tracking.Entities
{
    public class GlcSwipe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Swipe_id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Mid Required")]
        public string Mid { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Loction Required")]
        public string Location { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Input/Output Required")]
        public string I_O {get;set;}
        [Required(AllowEmptyStrings = false, ErrorMessage = "Date-Time Required")]
        public DateTime Datetime { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Swipe Type Required")]
        public string Swipetype { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Insert Date Required")]
        public string InsertedOn { get; set; }
    }
}
