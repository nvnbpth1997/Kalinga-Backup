using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracking.Entities
{
    public class CmRecords
    {
        [Key]
       public string Mid { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "First name Required")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name Required")]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone number Required")]
        public string PhoneNo { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Id Required")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Gender Required")]
        public string Gender { get; set; } 
        public string Photograph { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Batch Type Required")]
        public string Batch { get; set; }
    }
}
