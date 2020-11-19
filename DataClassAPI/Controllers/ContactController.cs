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
    public class ContactController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"SELECT
                            ContactID,
                            CellNum,
                            Email,
                            idNumber
                            FROM
                            dbo.Contact";
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

        public string Post(Contact c)
        {
            try
            {
                string query = @"INSERT INTO
                                dbo.Contact
                                VALUES
                                (    
                                '" + c.CellNum + @"',
                                '" + c.Email + @"',
                                '" + c.idNumber + @"'
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

        public string Put(Contact c)
        {
            try
            {
                /*string query = @"
                               UPDATE dbo.Contact SET
                               ContactID = '" + c.ContactID + @"',
                               CellNum = '" + c.CellNum + @"',
                               Email = '" + c.Email + @"',
                               idNumber = '" + c.idNumber + @"'
                               WHERE ContactID = '" + c.ContactID + @"'
                               ";*/
                string query = @"UPDATE dbo.Contact 
                                ('ContactID', 'CellNum', 'Email', 'idNumber')
                                VALUES
                                ('" + c.ContactID + @"', '" + c.CellNum+ @"', '" + c.Email + @"', '" + c.idNumber + @"')
                                WHERE ContactID = @ContactID
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
                               DELETE FROM dbo.Contact
                               WHERE ContactID= "+id+@"
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
