using CollegeAPI.Modules.Auth.Services.Interface;

namespace CollegeAPI.Modules.Auth.Services
{
    public class BCryptPasswordHasher:IPasswordHasher
    {
        public string Hash(string password)
    => BCrypt.Net.BCrypt.HashPassword(password);

        public bool Verify(string password, string hash)
            => BCrypt.Net.BCrypt.Verify(password, hash);
    }
}
