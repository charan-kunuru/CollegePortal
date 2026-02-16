using CollegeAPI.Modules.Students.Models;
using CollegeAPI.Modules.Subjects.Models;

namespace CollegeAPI.Models
{
    public class Attendance
    {
        public int AttendanceId { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public DateTime Date { get; set; }

        public string Status { get; set; } // Present / Absent
    }

}
