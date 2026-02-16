using CollegeAPI.Modules.Subjects.Models;
using CollegeAPI.Models;
using CollegeAPI.Modules.Branches.Models;
using CollegeAPI.Modules.Students.Models;


namespace CollegeAPI.Modules.Semesters.Models
{
    public class Semester
    {
        public int SemesterId { get; set; }

        public int SemesterNo { get; set; }

        // Foreign key to Branch
        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        // Navigation properties
        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
        public ICollection<Student> Students { get; set; } = new List<Student>();

    }

}
