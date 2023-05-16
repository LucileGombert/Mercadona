using MercadonaStudi.Models;
using Microsoft.AspNetCore.Identity;

namespace MercadonaStudi.Context
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();


                // Ajoute des enregistrements dans la bdd s'il n'en existe pas
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(new List<Category>()
                    {
                        new Category()
                        {
                            Label = "Fruits"
                        },
                        new Category()
                        {
                            Label = "Légumes"
                        }
                    });
                    context.SaveChanges();
                }
                
                if (!context.Offers.Any())
                {
                    context.Offers.AddRange(new List<Offer>()
                    {
                        new Offer()
                        {
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            Percentage = 0
                        }
                    });
                    context.SaveChanges();
                }

                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            Title = "Tomates",
                            Description = "Tomates origine France",
                            Image = "https://images.pexels.com/photos/257794/pexels-photo-257794.jpeg",
                            Price = 3,
                            DiscountedPrice = 0,
                            CategoryId = 1,
                            OfferId = 1,
                        },
                        new Product()
                        {
                            Title = "Pommes",
                            Description = "Pommes origine France",
                            Image = "https://images.pexels.com/photos/2966150/pexels-photo-2966150.jpeg",
                            Price = 5,
                            DiscountedPrice = 0,
                            CategoryId = 1,
                            OfferId = 1,
                        },
                        new Product()
                        {
                            Title = "Radis",
                            Description = "Radis origine Espagne",
                            Image = "https://images.pexels.com/photos/1257078/pexels-photo-1257078.jpeg",
                            Price = 2,
                            DiscountedPrice = 0,
                            CategoryId = 2,
                            OfferId = 1,
                        }
                    });
                    context.SaveChanges();
                }
            }
        }

        //public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        //{
        //    using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        //    {

        //        //Roles
        //        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        //        if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        //        if (!await roleManager.RoleExistsAsync(UserRoles.User))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        //        //Users
        //        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        //        string adminUserEmail = "admin@etickets.com";

        //        var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
        //        if (adminUser == null)
        //        {
        //            var newAdminUser = new ApplicationUser()
        //            {
        //                FullName = "Admin User",
        //                UserName = "admin-user",
        //                Email = adminUserEmail,
        //                EmailConfirmed = true
        //            };
        //            await userManager.CreateAsync(newAdminUser, "Coding@1234?");
        //            await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
        //        }


        //        string appUserEmail = "user@etickets.com";

        //        var appUser = await userManager.FindByEmailAsync(appUserEmail);
        //        if (appUser == null)
        //        {
        //            var newAppUser = new ApplicationUser()
        //            {
        //                FullName = "Application User",
        //                UserName = "app-user",
        //                Email = appUserEmail,
        //                EmailConfirmed = true
        //            };
        //            await userManager.CreateAsync(newAppUser, "Coding@1234?");
        //            await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
        //        }
        //    }
        //}
    }
}
