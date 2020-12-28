using Domain.RDBMS.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Domain.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void SeedRolesAndUsers(this ModelBuilder builder)
        {
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
