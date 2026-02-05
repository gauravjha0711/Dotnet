using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO2
{
    internal class ConnectedEnv
    {
        string ConString = @"Data Source=DESKTOP-84AGQQF\SQLEXPRESS2025;Initial Catalog = SchoolDB; Integrated Security = True;";
        SqlDataReader dataReader;
        public void GetAllStudent()
        {
            string sqlCmd = "SELECT * FROM students";
            SqlConnection sqlConnection = new SqlConnection(ConString);
            sqlConnection.Open();
            Console.WriteLine("Connection Opened");
            //hard coding SQL DML query in Command Object leads to sql injection by hackers,
            //so we should avoid it and use parameterized query instead
            SqlCommand sqlCommand = new SqlCommand(sqlCmd, sqlConnection);
            dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                int StudentId = Convert.ToInt32(dataReader["StudentID"]);
                string StudentName = dataReader["Name"].ToString();
                string Course = dataReader["Course"].ToString();
                int Marks = Convert.ToInt32(dataReader["Marks"]);
                Console.WriteLine($"ID: {StudentId}, Name: {StudentName}, Course: {Course}, Marks: {Marks}");

            }
            dataReader.Close();
            sqlConnection.Close();

        }
        public void GetStudentById(int id)
        {
            string sqlCmd = "SELECT * FROM students WHERE StudentID = @id";
            SqlConnection sqlConnection = new SqlConnection(ConString);
            sqlConnection.Open();
            Console.WriteLine("Connection Opened");
            SqlCommand sqlCommand = new SqlCommand(sqlCmd, sqlConnection);
            sqlCommand.Parameters.AddWithValue("@id", id);
            dataReader = sqlCommand.ExecuteReader();
            if (dataReader.Read())
            {
                int StudentId = Convert.ToInt32(dataReader["StudentID"]);
                string StudentName = dataReader["Name"].ToString();
                string Course = dataReader["Course"].ToString();
                int Marks = Convert.ToInt32(dataReader["Marks"]);
                Console.WriteLine($"ID: {StudentId}, Name: {StudentName}, Course: {Course}, Marks: {Marks}");
            }
            else
            {
                Console.WriteLine("No student found with the given ID.");

            }
            dataReader.Close();
            sqlConnection.Close();
        }
    }
}
