using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO2
{
    internal class DisconnectEnvDemo
    {
        string ConString = "Data Source=DESKTOP-84AGQQF\\SQLEXPRESS2025;Initial Catalog = SchoolDB; Integrated Security = True;";
        public void GetAllStudent()
        {
            SqlConnection sqlConnection = new SqlConnection(ConString);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("SELECT * FROM students", sqlConnection);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "students");
            foreach (DataRow row in dataSet.Tables["students"].Rows)
            {
                int StudentId = Convert.ToInt32(row["StudentID"]);
                string StudentName = row["Name"].ToString();
                string Course = row["Course"].ToString();
                int Marks = Convert.ToInt32(row["Marks"]);
                Console.WriteLine($"ID: {StudentId}, Name: {StudentName}, Course: {Course}, Marks: {Marks}");
            }
        }
    }
}
