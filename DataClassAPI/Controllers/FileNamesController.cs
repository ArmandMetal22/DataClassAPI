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

namespace DataClassAPI.Controllers
{
    public class FileNamesController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"SELECT
                            FileID,
                            PictureFile,
                            TextFile,
                            ExcelFile
                            FROM
                            dbo.FileNames";
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

        public string Post(FileNames fn)
        {
            try
            {
                string query = @"INSERT INTO
                                dbo.FileNames
                                VALUES
                                (    
                                '" + fn.PictureFile + @"',
                                '" + fn.TextFile + @"',
                                '" + fn.ExcelFile + @"'
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

        public string Put(FileNames fn)
        {
            try
            {
                string query = @"
                               UPDATE dbo.FileNames SET
                               PictureFile = '" + fn.PictureFile + @"',
                               TextFile = '" + fn.TextFile + @"',
                               ExcelFile = '" + fn.ExcelFile + @"'
                               WHERE FileID = '" + fn.FileID + @"'
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
                               DELETE FROM dbo.FileNames
                               WHERE FileID= " + id + @"
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
    }
}

