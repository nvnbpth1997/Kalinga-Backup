using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracking.Entities
{
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Admin_Id { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mid Required")]
        public string Mid { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Name Required")]
        public string Name { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email Required")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Role Name Required")]
        public string RoleName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Access Level Required")]
        public int AccessLevel { get; set; }

    }
}
