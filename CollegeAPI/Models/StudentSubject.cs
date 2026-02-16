using CollegeAPI.Modules.Students.Models;
using CollegeAPI.Modules.Subjects.Models;

namespace CollegeAPI.Models
{
    public class StudentSubject
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }

}
