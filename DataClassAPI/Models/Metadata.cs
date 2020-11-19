using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataClassAPI.Models
{
    public class Metadata
    {
        public int DataID { get; set; }
        public string idNumber { get; set; }
        public string FullName { get; set; }
        public string Initials { get; set; }
        public string email { get; set; }
        public string PictureFile { get; set; }
        public string TextFile { get; set; }
        public string ExcelFile { get; set; }

    }
}