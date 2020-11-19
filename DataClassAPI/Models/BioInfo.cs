using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataClassAPI.Models
{
    public class BioInfo
    {
        public int BioID { get; set; } 
        public string FName { get; set; }
        public string LName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string DateOfBirth { get; set; }
        public string idNumber { get; set; }

    }
}