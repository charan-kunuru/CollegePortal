namespace CollegeAPI.Modules.Auth.Services.Interface
{
    public interface IPasswordHasher
    {
        string Hash(string password);
        bool Verify(string password, string hash);

    }
}
