using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VietualSELaboratory.Areas.Identity.Data;

namespace VietualSELaboratory.Data
{
    public class AuthDbContext : IdentityDbContext<ApplicationUser>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

            builder
                .Entity<IdentityRole>()
                .HasData(new IdentityRole
                    {
                        Id = "2c5e174e-3b0e-446f-86af-483d56fd7210", 
                        Name = "Teacher", 
                        NormalizedName = "TEACHER".ToUpper()
                    },
                    new IdentityRole
                    {
                        Name = "Student",
                        NormalizedName = "Student".ToUpper()
                    }
                );

            var hasher = new PasswordHasher<IdentityUser>();

            //Seeding the User to AspNetUsers table
            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser()
                {
                    Id = "8e445865-a24d-4543-a6c6-9443d048cdb9", // primary key
                    UserName = "admin@lpnu.ua",
                    NormalizedUserName = "admin@lpnu.ua".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "123123"),
                    EmailConfirmed = true,
                    Email = "admin@lpnu.ua"
                }
            );

            //Seeding the relation between our user and role to AspNetUserRoles table
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                    UserId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                }
            );
        }
    }
}
