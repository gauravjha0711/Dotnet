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
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter($"Select * from students where StudentId={id}", sqlConnection);
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
        //public void GetStudentById(int id)
        //{
        //    SqlConnection sqlConnection = new SqlConnection(ConString);
        //    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from students", sqlConnection);
        //    DataSet dataSet = new DataSet();
        //    sqlDataAdapter.Fill(dataSet, "Students");
        //    bool isTrue = false;
        //    for (int i = 0; i < dataSet.Tables["Students"].Rows.Count; i++)
        //    {
        //        if (Convert.ToInt32(dataSet.Tables["Students"].Rows[i]["StudentId"]) == id)
        //        {
        //            Console.WriteLine($"Students Id: {dataSet.Tables["Students"].Rows[i][0]} | Name: {dataSet.Tables["Students"].Rows[i][1]} | Course: {dataSet.Tables["Students"].Rows[i][2]} | Marks : {dataSet.Tables["Students"].Rows[i][3]}");
        //            isTrue = true;
        //        }
        //    }
        //    if (!isTrue)
        //    {
        //        Console.WriteLine("Student Not Found");
        //    }
        //}
        public void AddNewStudent()
        {
            SqlConnection sqlConnection = new SqlConnection(ConString);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from students", sqlConnection);
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


        public void UpdateStudentById()
        {

            SqlConnection sqlConnection = new SqlConnection(ConString);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from Students", sqlConnection);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "Students");

            Console.Write("Enter the students to update: ");
            int.TryParse(Console.ReadLine(), out int id);

            Console.WriteLine("Enter the name to update");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the course to update");
            string course = Console.ReadLine();

            Console.WriteLine("Enter the marks to update");
            int.TryParse(Console.ReadLine(), out int marks);

            bool isStudentFound = false;

            for (int i = 0; i < dataSet.Tables["Students"].Rows.Count; i++)
            {
                if (int.TryParse(dataSet.Tables["Students"].Rows[i]["id"].ToString(), out int studentId) && studentId == id)
                {
                    dataSet.Tables["Students"].Rows[i]["name"] = name;
                    dataSet.Tables["Students"].Rows[i]["course"] = course;
                    dataSet.Tables["Students"].Rows[i]["marks"] = marks;
                    isStudentFound = true;
                    break;
                }
            }

            if (!isStudentFound)
            {
                Console.WriteLine("No student found with the given id");
                return;

            }
            else
            {
                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
                sqlDataAdapter.Update(dataSet, "Students");
                Console.WriteLine("Student updated successfully");
            }
        }


        public void DeleteStudent()
        {
            SqlConnection sqlConnection = new SqlConnection(conString);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from Students", sqlConnection);
            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "Students");
            Console.Write("Enter StudentId: ");
            int id = int.Parse(Console.ReadLine());
            bool istrue = false;

            for (int i = 0; i < dataSet.Tables["Students"].Rows.Count; i++)
            {
                if ((Convert.ToInt32(dataSet.Tables["Students"].Rows[i][0])) == id)
                {
                    dataSet.Tables["Students"].Rows[i].Delete();
                    istrue = true;
                    break;
                }
            }
            if (!istrue)
            {
                Console.WriteLine("Student Not Fount");
            }
            else
            {
                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
                sqlDataAdapter.Update(dataSet, "Students");
                Console.WriteLine("Update Student");
            }
        }


    }
}
