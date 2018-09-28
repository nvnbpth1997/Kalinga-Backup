using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracking.Entities
{
    public class Residence
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Residence_id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mid Required")]
        public string Mid { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Block Name Required")]
        public string Blockname { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Floor Name Required")]
        public string Floorname { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Unit Name Required")]
        public string Unitname { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Room Name Required")]
        public string Roomname { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Bed Name Required")]
        public string Bedname { get; set; }
    }
}
