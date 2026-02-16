using CollegeAPI.Models;
using CollegeAPI.Modules.Semesters.Models;
using CollegeAPI.Modules.Teachers.Models;

using CollegeAPI.Modules.Students.Models;
using System.Xml;

namespace CollegeAPI.Modules.Subjects.Models
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
