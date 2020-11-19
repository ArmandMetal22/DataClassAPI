using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using DataClassAPI.Models;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace DataClassAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public void ExportToCSV()
        {
            StringWriter sw = new StringWriter();

            sw.WriteLine("\"UserID\", \"Username\", \"Userpassword\", \"Useremail\", \"idNumber\"");
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=ExportedUsersList.txt");
            Response.ContentType = "text/plain";

            var users = Users.GenerateUsersList();

            foreach (var user in users)
            {
                sw.WriteLine(string.Format("\"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\"",
                    user.UserID,
                    user.Username,
                    user.Userpassword,
                    user.Useremail,
                    user.idNumber));
            }

            Response.Write(sw.ToString());
            Response.End();
        }

        public void ExportToExcel()
        {
            StringWriter sw = new StringWriter();

            sw.WriteLine("\"UserID\", \"Username\", \"Userpassword\", \"Useremail\", \"idNumber\"");
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=ExportedUsersList.csv");
            Response.ContentType = "text/csv";

            var users = Users.GenerateUsersList();

            foreach (var user in users)
            {
                sw.WriteLine(string.Format("\"{0}\", \"{1}\", \"{2}\", \"{3}\", \"{4}\"",
                    user.UserID,
                    user.Username,
                    user.Userpassword,
                    user.Useremail,
                    user.idNumber));
            }

            Response.Write(sw.ToString());
            Response.End();
        }
    }
}
