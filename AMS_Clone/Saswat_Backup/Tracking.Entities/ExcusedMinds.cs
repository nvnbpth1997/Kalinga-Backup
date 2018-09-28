using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracking.Entities
{
    public class ExcusedMinds
    {
        [JsonProperty("MID")]
        public string MID { get; set; }

        [JsonProperty("NAME")]
        public string Name { get; set; }

        [JsonProperty("LEAD")]
        public string Lead { get; set; }

        [JsonProperty("VENUE")]
        public string Venue { get; set; }

        [JsonProperty("COMMENTS")]
        public string Comments { get; set; }
    }
}
