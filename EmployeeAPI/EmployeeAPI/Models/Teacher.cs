namespace EmployeeAPI.Models
{
    public class Teacher
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int DepartmentId { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; } = true;
        public string PhotoPath { get; set; }
        public DateOnly Dob { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public string Gender { get; set; }

        public int MobileNumber { get; set; }

        public string Designation { get; set; }

        public DateOnly Joined { get; set; }

    }
}
