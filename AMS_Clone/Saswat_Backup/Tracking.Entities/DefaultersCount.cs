using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracking.Entities
{
    public class DefaultersCount
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Count_Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mid Required")]
        public string Mid { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Late Swipe Required")]
        public int LateSwipe { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Not Swipe Required")]
        public int NotSwipe { get; set; }
    }
}
