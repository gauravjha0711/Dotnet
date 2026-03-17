namespace StudentManagementSystem.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int Duration { get; set; }
        //public int DepartmentId { get; set; }s
        //// Navigation properties
        //public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}
