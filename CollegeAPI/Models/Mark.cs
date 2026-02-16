using CollegeAPI.Modules.Students.Models;
using CollegeAPI.Modules.Subjects.Models;
using System.ComponentModel.DataAnnotations.Schema;
namespace CollegeAPI.Models
{
    public class Mark
    {
        public int MarkId { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        public string ExamType { get; set; } // Internal1, Internal2, Final

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Score { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal MaxMarks { get; set; }

        public DateTime ExamDate { get; set; }
    }

}
