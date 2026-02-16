using CollegeAPI.Modules.Auth.Services.Interface;
using CollegeAPI.Modules.Users.Models;
using CollegeAPI.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace CollegeAPI.Data.Seed;
public static class AdminSeeder
{
    public static async Task SeedAdmin(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var hasher = scope.ServiceProvider.GetRequiredService<IPasswordHasher>();

        // Check if admin already exists
        if (!await context.Users.AnyAsync(u => u.Role == "Admin"))
        {
            var admin = new User
            {
               
                UserName="Charan Kunuru",
                PasswordHash = hasher.Hash("Charan@123"),
                Role = "Admin",
                IsActive = true
            };

            context.Users.Add(admin);
            await context.SaveChangesAsync();
        }
    }
}
