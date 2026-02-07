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
        public void GetStudentById(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(ConString);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"Select * from Students where StudentId={id}", sqlConnection);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "Students");
            foreach(DataRow row in dataSet.Tables["students"].Rows)
            {
                int StudentId = Convert.ToInt32(row["StudentID"]);
                string StudentName = row["Name"].ToString();
                string Course = row["Course"].ToString();
                int Marks = Convert.ToInt32(row["Marks"]);
                Console.WriteLine($"ID: {StudentId}, Name: {StudentName}, Course: {Course}, Marks: {Marks}");
            }
        }
        public void AddNewStudent()
        {
            SqlConnection sqlConnection = new SqlConnection(conString);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from Students", sqlConnection);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "Students");
            DataRow row = dataSet.Tables["Students"].NewRow();

            Console.WriteLine("Enter Students Details");
            Console.Write("Enter StudentId: ");
            int id = int.Parse(Console.ReadLine());
            row[0] = id;
            Console.Write("Enter StudentName: ");
            string Name = Console.ReadLine();
            row[1] = Name;
            Console.Write("Enter StudentCourse: ");
            string course = Console.ReadLine();
            row[2] = course;
            Console.Write("Enter StudentMarks: ");
            int marks = int.Parse(Console.ReadLine());
            row[3] = marks;

            dataSet.Tables["Students"].Rows.Add(row);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
            sqlDataAdapter.Update(dataSet, "Students");

            Console.WriteLine("Students Register");
        }
    }
}
