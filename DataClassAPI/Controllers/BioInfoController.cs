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
    public class BioInfoController : ApiController
    {
        public HttpResponseMessage Get()
        {
            string query = @"SELECT
                            BioID,
                            FName,
                            LName,
                            Age,
                            Gender,
                            DateOfBirth,
                            idNumber
                            FROM
                            dbo.BioInfo";
            DataTable table = new DataTable();
            using(var con = new SqlConnection(ConfigurationManager.
                ConnectionStrings["DataClassDB"].ConnectionString))
                using(var cmd = new SqlCommand(query,con))
                using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);

        }

        public string Post(BioInfo bi)
        {
            try
            {
                string query = @"INSERT INTO
                                dbo.BioInfo
                                VALUES
                                (    
                                '" + bi.FName + @"',
                                '" + bi.LName + @"',
                                '" + bi.Age + @"',
                                '" + bi.Gender + @"',
                                '" + bi.DateOfBirth + @"',
                                '" + bi.idNumber + @"'
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

        public string Put(BioInfo bi)
        {
            try
            {
                string query = @"
                               UPDATE dbo.BioInfo SET
                               BioID = '" + bi.BioID + @"'
                               ,FName = '" + bi.FName + @"'
                               ,LName = '" + bi.LName + @"'
                               ,Age = '" + bi.Age + @"'
                               ,Gender = '" + bi.Gender + @"'
                               ,DateOfBirth = '" + bi.DateOfBirth + @"'
                               ,idNumber = '" + bi.idNumber + @"'
                               WHERE BioID = '" + bi.BioID + @"'
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
                               DELETE FROM dbo.BioInfo
                               WHERE BioID= " + id + @"
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
