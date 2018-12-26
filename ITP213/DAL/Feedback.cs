using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITP213.DAL
{
    public class Feedback
    {
        public int feedbackID { get; set; }
        public string feedbackFormName { get; set; }
        public int tripID { get; set; }
        public string staffID { get; set; }
        public string adminNo { get; set; }
    }
}