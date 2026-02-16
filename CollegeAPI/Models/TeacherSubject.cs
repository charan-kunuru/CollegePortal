using CollegeAPI.Modules.Subjects.Models;
namespace CollegeAPI.Modules.Teachers.Models
{
    public class TeacherSubject
    {
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }

}
