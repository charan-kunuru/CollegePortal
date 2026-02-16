using CollegeAPI.Modules.Semesters.Models;
using CollegeAPI.Modules.Students.Models;
using CollegeAPI.Modules.Teachers.Models;

namespace CollegeAPI.Modules.Branches.Models
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }

        public ICollection<Semester> Semesters { get; set; }
        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<Student> Students { get; set; }
    }

}
