using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracking.Entities
{
    public class CMExcel
    {
        [JsonProperty("Mid")]
        public string Mid { get; set; }

        [JsonProperty("FirstName")]
        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }

        [JsonProperty("PhoneNo")]
        public string PhoneNo { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }

        [JsonProperty("Gender")]
        public string Gender { get; set; }

        [JsonProperty("Photograph")]
        public string Photograph { get; set; }

        [JsonProperty("Batch")]
        public string Batch { get; set; }




    }
}
