using BootCamp.Data.Context;
using BootCamp.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace BootCamp.Data.Seed
{
    public class Seeder
    {
        public async static Task Seed(RoleManager<IdentityRole> roleManager, UserManager<Trainee> userManager, MyAppContext dbContext)
        {
            await dbContext.Database.EnsureCreatedAsync();
            await SeedRoles(roleManager, dbContext);
            await SeedUser(userManager, roleManager, dbContext);
            await SeedAddress(dbContext);
            await SeedTests(dbContext);
            await SeedPhoneNumber(dbContext);
        }
        private static async Task SeedRoles(RoleManager<IdentityRole> roleManager, MyAppContext dbContext)
        {
            if (!dbContext.Roles.Any())
            {
                var roles = SeederHelper<string>.GetData("Roles.json");
                foreach (var role in roles)
                {
                    await roleManager.CreateAsync(new IdentityRole { Name = role });
                }
            }
        }
        private static async Task SeedUser(UserManager<Trainee> userManager, RoleManager<IdentityRole> roleManager, MyAppContext dbContext)
        {
            if (!dbContext.Users.Any())
            {
                var users = SeederHelper<Trainee>.GetData("Trainee.json");
                foreach (var user in users)
                {
                    user.EmailConfirmed = true;
                    var result = await userManager.CreateAsync(user, "Boot@123");

                    if (result.Succeeded)
                    {
                        // Check if the role exists before attempting to add it
                        var customerRoleExists = await roleManager.RoleExistsAsync("Trainee");
                        if (customerRoleExists)
                        {
                            await userManager.AddToRoleAsync(user, "Trainee");
                        }
                    }
                }
            }
        }

        private static async Task SeedAddress(MyAppContext dbContext)
        {
            if (!dbContext.Addresses.Any())
            {
                var addresses = SeederHelper<Address>.GetData("Address.json");
                await dbContext.Addresses.AddRangeAsync(addresses);
                await dbContext.SaveChangesAsync();
            }
        }

        private static async Task SeedTests(MyAppContext dbContext)
        {
            if (!dbContext.Tests.Any())
            {
                var tests = SeederHelper<Test>.GetData("Tests.json");
                await dbContext.Tests.AddRangeAsync(tests);
                await dbContext.SaveChangesAsync();
            }
        }

        private static async Task SeedPhoneNumber(MyAppContext dbContext)
        {
            if (!dbContext.PhoneNumbers.Any())
            {
                var phoneNumber = SeederHelper<PhoneNumber>.GetData("PhoneNumber.json");
                await dbContext.PhoneNumbers.AddRangeAsync(phoneNumber);
                await dbContext.SaveChangesAsync();
            }
        }

    }
}
