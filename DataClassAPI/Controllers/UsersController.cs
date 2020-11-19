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
    public class UsersController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"SELECT
                            UserID,
                            Username,
                            Userpassword,
                            Useremail,
                            idNumber
                            FROM
                            dbo.Users";
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

        public string Post(Users u)
        {
            try
            {
                string query = @"INSERT INTO
                                dbo.Users
                                VALUES
                                (    
                                '" + u.Username + @"',
                                '" + u.Userpassword + @"',
                                '" + u.Useremail + @"',
                                '" + u.idNumber + @"'
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

        public string Put(Users u)
        {
            try
            {
                string query = @"
                               UPDATE dbo.Users SET
                               UserID = '" + u.UserID + @"',
                               Username = '" + u.Username + @"',
                               Userpassword = '" + u.Userpassword + @"',
                               Useremail = '" + u.Useremail + @"',
                               idNumber = '" + u.idNumber + @"'
                               WHERE UserID = '" + u.UserID + @"'
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
                               DELETE FROM dbo.Users
                               WHERE UserID= " + id + @"
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
