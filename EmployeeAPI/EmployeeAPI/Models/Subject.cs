using System.Xml;

namespace EmployeeAPI.Models
{
    public class Subject
    {
        public int SubjectId { get; set; }

        public string SubjectName { get; set; }

        // Foreign key to Semester
        public int SemesterId { get; set; }
        public Semester Semester { get; set; }

        // Navigation properties
        public ICollection<TeacherSubject> TeacherSubjects { get; set; }
        public ICollection<StudentSubject> StudentSubjects { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public ICollection<Mark> Marks { get; set; }


    }

}
