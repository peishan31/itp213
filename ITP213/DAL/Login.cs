using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITP213.DAL
{
    public class Login
    {
        public int accountID { set; get; }
        public string accountType { set; get; }
        public string name { set; get; }
        public string email { set; get; }
        public string mobile { set; get; }
        public DateTime dateOfBirth { set; get; }
        public string password { set; get; }
    }
}