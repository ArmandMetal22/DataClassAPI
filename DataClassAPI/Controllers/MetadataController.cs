using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataClassAPI.Models;
using System.Web;

namespace DataClassAPI.Controllers
{
    public class MetadataController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"SELECT
                            DataID,
                            idNumber,
                            FullName,
                            Initials,
                            email,
                            PictureFile,
                            TextFile,
                            ExcelFile
                            FROM
                            dbo.Metadata";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["DataClassDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);

        }

        public string Post(Metadata md)
        {
            try
            {
                string query = @"INSERT INTO
                                dbo.Metadata
                                VALUES
                                (    
                                '" + md.idNumber + @"',
                                '" + md.FullName + @"',
                                '" + md.Initials + @"',
                                '" + md.email + @"',
                                '" + md.PictureFile + @"',
                                '" + md.TextFile + @"',
                                '" + md.ExcelFile + @"'
                                )
                                ";
                //string query = "INSERT INTO dbo.Contact (Contact.CellNum, Contact.Email, Contact.idNumber) VALUES (@CellNum, @Email, @idNumber)";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["DataClassDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "INSERT Successful! :)";
            }
            catch (Exception)
            {
                return "INSERT Unsuccessful! :(";
            }

        }

        public string Put(Metadata md)
        {
            try
            {
                string query = @"
                               UPDATE dbo.Metadata SET
                               DataID = '" + md.DataID + @"',
                               idNumber = '" + md.idNumber + @"',
                               FullName = '" + md.FullName + @"',
                               Initials = '" + md.Initials + @"',
                               email = '" + md.email + @"',
                               PictureFile = '" + md.PictureFile + @"',
                               TextFile = '" + md.TextFile + @"',
                               ExcelFile = '" + md.ExcelFile + @"'
                               WHERE DataID = '" + md.DataID + @"'
                               ";
               
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["DataClassDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "UPDATE Successful! :)";
            }
            catch (Exception)
            {
                return "UPDATE Unsuccessful! :(";
            }

        }

        public string Delete(int id)
        {
            try
            {
                string query = @"
                               DELETE FROM dbo.Metadata
                               WHERE DataID= " + id + @"
                               ";
                //string query = "INSERT INTO dbo.Contact (Contact.CellNum, Contact.Email, Contact.idNumber) VALUES (@CellNum, @Email, @idNumber)";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["DataClassDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "DELETE Successful! :)";
            }
            catch (Exception)
            {
                return "DELETE Unsuccessful! :(";
            }

        }

        [Route("api/Metadata/SaveFile")]
        public string SaveFile()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var sPath = HttpContext.Current.Server.MapPath("~/Photos/" + filename);

                postedFile.SaveAs(sPath);

                return filename;
            }
            catch (Exception)
            {
                return "anonymous.png";
            }
        }

    }
}
