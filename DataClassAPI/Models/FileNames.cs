using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataClassAPI.Models
{
    public class FileNames
    {
        public int FileID { get; set; }
        public string PictureFile { get; set; }
        public string TextFile { get; set; }
        public string ExcelFile { get; set; }

    }
}