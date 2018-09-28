using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracking.Entities
{
    public class MindDetails
    {
        //From CmRecords
        public string Mid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Photograph { get; set; }
        //From GlcSwipe
        public string Location { get; set; }
        public string I_O { get; set; }
        public DateTime Datetime { get; set; }
        public string Swipetype { get; set; }
        public string InsertedOn { get; set; }
        //From LeadDetails
        public string LeadName { get; set; }
        public string LeadEmail { get; set; }
        public string LeadPhoneNo { get; set; }
        //From Residence
        public string ResidenceString { get; set; }
        //From DefaultersCount
        public int LateSwipe { get; set; }
        public int NotSwipe { get; set; }
    }
}
