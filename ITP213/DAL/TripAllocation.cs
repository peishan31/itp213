using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITP213.DAL
{
    public class TripAllocation
    {
        public string name { set; get; }
        public int accountID { set; get; }
        // for displaying student's names
        public string course { set; get; }
        public string adminNo { set; get; }
        // for displaying lecturer's names: name, staffID, accountID, school
        public string staffID { set; get; }
        public string school { set; get; }
        public int tripID { set; get; }
        public string tripName { set; get; }
        public string tripType { set; get; }
        public string overseasTripStatus { set; get; }
        public string departureDate { set; get; } // on hold
        public string arrivalDate { set; get; } // on hold
        public string country { set; get; }
    }
}