using System.ComponentModel.DataAnnotations;
namespace EmployeeAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        
        public int UserId { get; set; }

        public User User { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public int BranchId { get; set; }
        public Branch Branch { get; set; }

        public int SemesterId { get; set; }
        public Semester Semester { get; set; }



        public int Age { get; set; }

        public string Section { get; set; }

        public bool IsActive { get; set; } = true;

        public string PhotoPath { get; set; }

        public  DateOnly Dob{get; set; }

        public DateTime Joined{ get; set; }

        public string UserEmail { get; set; }

        public string Address { get; set; }
        
        public string SeatType { get; set; }

        public string Gender { get; set; }

        public string FatherName { get; set; }

        public string MotherName { get; set; }

        public int MobileNumber { get; set; }


        public ICollection<StudentSubject> StudentSubjects { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
        public ICollection<Fee> Fees { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }

        public ICollection<Mark> Marks { get; set; }


    }

}
