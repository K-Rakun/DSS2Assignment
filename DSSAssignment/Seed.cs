using DSSAssignment.Data;
using DSSAssignment.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DSSAssignment
{
    public class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new DSSAssignmentContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<DSSAssignmentContext>>()))
            {


                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(

                    new Movie
                    {
                        Name = "Ghostbusters ",
                        Price = 12
                    },

                    new Movie
                    {
                        Name = "Ghostbusters 2",
                        Price = 13
                    },

                    new Movie
                    {
                        Name = "Rio Bravo",
                        Price = 20
                    }
                );
                context.SaveChanges();
            }
        }

        

        public static async Task SeedAdmin(UserManager<IdentityUser> userManager)
        {
            //Seed Default User
            var defaultUser = new IdentityUser
            {
                UserName = "admin",
                Email = "admin@gmail.com",
                EmailConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Password1!");
                    await userManager.AddToRoleAsync(defaultUser, "admin");
                }

            }
        }
    }
}
