using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QuickApp.Core.Models.Account;
using QuickApp.Core.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickApp.Core.Services
{
    public class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public DatabaseSeeder(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedAsync()
        {
            await _context.Database.MigrateAsync();

            // Seed Roles
            var roles = new List<ApplicationRole>
            {
                new ApplicationRole { Name = "Admin" },
                new ApplicationRole { Name = "User" }
            };

            foreach (var role in roles)
            {
                if (await _roleManager.FindByNameAsync(role.Name) == null)
                {
                    await _roleManager.CreateAsync(role);
                }
            }

            // Seed Users
            var adminUser = new ApplicationUser
            {
                UserName = "admin",
                Email = "admin@example.com",
                EmailConfirmed = true,
                FullName = "Admin User"
            };

            if (await _userManager.FindByNameAsync(adminUser.UserName) == null)
            {
                await _userManager.CreateAsync(adminUser, "Admin@123");
                await _userManager.AddToRoleAsync(adminUser, "Admin");
            }

            // Seed additional data as necessary
            // ...

            await _context.SaveChangesAsync();
        }
    }
}
