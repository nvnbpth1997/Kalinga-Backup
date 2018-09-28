using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracking.Entities
{
    public class LeadDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeadDetail_Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mid Required")]
        public string Mid { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Lead Name Required")]
        public string LeadName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Lead Email Required")]
        public string LeadEmail { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Allocated Space Required")]
        public string LeadPhoneNo { get; set; }

    }
}
