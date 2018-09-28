using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Tracking.Entities
{
    public class ExcelData
    {
        [JsonProperty("SWIPE DATA")]
        public string Swipedata { get; set; }
        [JsonProperty("MID")]
        public string Mid { get; set; }
        [JsonProperty("NAME")]
        public string Name { get; set; }
        [JsonProperty("DATE & TIME")]
        public string Datetime { get; set; }
        [JsonProperty("CARD NUMBER")]
        public string Cardnumber { get; set; }

    }
}
