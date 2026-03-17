using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ADODotnetDemo
{
    internal class ConnectEnvDemo
    {
        SqlConnection connection;
        SqlCommand cmd;
        SqlDataReader dataReader;

        public ConnectEnvDemo()
        {

        }

        public void GetAllStudent()
        {
            connection = new SqlConnection("Data Source=DESKTOP-84AGQQF\\SQLEXPRESS2025;Initial Catalog=sms;Integrated Security=True;");
            connection.Open();
            cmd = new SqlCommand("SELECT * FROM Students", connection);
            dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                int id = Convert.ToInt32(dataReader["StudentId"]);
                string name = dataReader["Name"].ToString();
                string course = dataReader["Course"].ToString();
                int marks = Convert.ToInt32(dataReader["Marks"]);

                Console.WriteLine($"Id: {id}, Name: {name}, Course: {course}, Marks: {marks}");
            }

            connection.Close();
        }

    }
}