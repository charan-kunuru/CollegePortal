
using CollegeAPI.Modules.Students.Models;
using CollegeAPI.Modules.Teachers.Models;

namespace CollegeAPI.Modules.Users.Models
{
    public class User
    {

        public int Id { get; set; }

        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public string Role { get; set; }

        public  bool IsActive { get; set; } = true;

        public Teacher ? Teacher { get; set; }

       public Student ? Student { get; set; }

    }
}
