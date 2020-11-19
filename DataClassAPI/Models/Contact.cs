using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataClassAPI.Models
{
    public class Contact
    {
        public int ContactID { get; set; }
        public string CellNum { get; set; }
        public string Email { get; set; }
        public string idNumber { get; set; }
    }
}