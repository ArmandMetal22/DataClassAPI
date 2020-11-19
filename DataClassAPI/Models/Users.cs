using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataClassAPI.Models
{
    public class Users
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Userpassword { get; set; }
        public string Useremail { get; set; }
        public string idNumber { get; set; }

        public  static List<Users> GenerateUsersList()
        {
            List<Users> users = new List<Users>
            {
                new Users{UserID = 1, Username = "ArmandMetal22", Userpassword="1234", Useremail="armandmet15@mweb.co.za", idNumber = "9903165028081"}
            };
            return users;
        }
    }
}