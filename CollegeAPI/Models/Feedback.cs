using CollegeAPI.Modules.Students.Models;
using CollegeAPI.Modules.Subjects.Models;
using CollegeAPI.Modules.Teachers.Models;

namespace CollegeAPI.Models
{
    public class Feedback
    {
        public int FeedbackId { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public string Comments { get; set; }

        public int Rating { get; set; }
    }


}
