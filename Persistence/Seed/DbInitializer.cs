using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Utility;

namespace Persistence.Seed;

public class DbInitializer : IDbInitializer
{
    private readonly DataContext _context;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly UserManager<ApplicationUser> _userManager;

    public DbInitializer(
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager,
        DataContext context)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _context = context;
    }

    public void Initilize()
    {
        //Apply pending migrations
        try
        {
            if (_context.Database.GetPendingMigrations().Count() > 0) _context.Database.Migrate();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        //Create roles
        if (!_roleManager.RoleExistsAsync(SD.ADMIN_ROLE).GetAwaiter().GetResult())
        {
            _roleManager.CreateAsync(new IdentityRole(SD.ADMIN_ROLE)).GetAwaiter().GetResult();

            // Create Admin User
            _userManager.CreateAsync(new ApplicationUser
            {
                Email = "admin@cmms.com",
                UserName = "admin@cmms.com",
                FullName = "System Admin",
                PhoneNumber = "2838933"
            }, "Pa$$w0rd1").GetAwaiter().GetResult();

            var user = _context.ApplicationUsers
                .FirstOrDefaultAsync(x => x.Email == "admin@cmms.com").GetAwaiter().GetResult();

            _userManager.AddToRoleAsync(user, SD.ADMIN_ROLE).GetAwaiter().GetResult();
        }

        if (_context.SystemLanguages.ToListAsync().GetAwaiter().GetResult().Count <= 0)
        {
            var languages = new List<SystemLanguage>
            {
                new()
                {
                    Code = "en-US", Name = "English", FrontEndCode = "en", CreatedAt = DateTime.Now,
                    LastUpdatedAt = DateTime.Now
                },
                new()
                {
                    Code = "pt-PT", Name = "Portuguese", FrontEndCode = "pt", CreatedAt = DateTime.Now,
                    LastUpdatedAt = DateTime.Now
                }
            };

            _context.SystemLanguages.AddRange(languages);
            _context.SaveChanges();
        }
    }
}