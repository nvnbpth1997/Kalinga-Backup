using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracking.Entities
{
    public class SwipeTrack
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Uid { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mid Required")]
        public string Mid { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Location Required")]
        public string Location { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Date-time Required")]
        public DateTime Datetime { get; set; }
        public string PreLocation { get; set; }
        public DateTime PreDatetime { get; set; }

    }
}
