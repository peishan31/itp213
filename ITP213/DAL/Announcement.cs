﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITP213.DAL
{
    public class Announcement
    {
        public int announcementID { set; get; } //
        public string announcementTitle { set; get; } //
        public string announcementMessage { set; get; } //
        public string staffID {set; get;} //
        public string staffName { set; get; }
        public int tripID { set; get; }
        public string tripNameAndTripType { set; get; } 
        public string tripName { set; get; } //
        public string createdOn { set; get; } //
    }
}