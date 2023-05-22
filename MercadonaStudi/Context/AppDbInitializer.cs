using Microsoft.AspNetCore.Identity;
using MercadonaStudi.Models;
using static System.Net.WebRequestMethods;


namespace MercadonaStudi.Context
{
    public class AppDbInitializer
    {
        #region Seed() : Ajoute des catégories, promotions et produits dans la bdd s'il n'en existe pas au lancement de l'application
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

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
                            Image = "https://images.pexels.com/photos/7333159/pexels-photo-7333159.jpeg",
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
        #endregion


        #region SeedUsersAndRolesAsync() : Ajoute un utilisateur admin au lancement de l'application s'il n'existe pas
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync("Admin"))
                    await roleManager.CreateAsync(new IdentityRole("Admin"));

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        Name = "Admin User",
                        UserName = "admin",
                        Email = adminUserEmail,
                        EmailConfirmed = true,
                    };
                    await userManager.CreateAsync(newAdminUser, "Admin@123");
                    await userManager.AddToRoleAsync(newAdminUser, "Admin");
                }
            }
        }
        #endregion
    }
}
