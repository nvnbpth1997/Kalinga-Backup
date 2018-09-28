using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracking.Entities
{
   public class ExcuseData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Excused_id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Mid Required")]
        public string Mid { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Name Required")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Lead Required")]
        public string Lead { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Venue Required")]
        public string Venue { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Comments Required")]
        public string  Comments { get; set; }

    }
}
