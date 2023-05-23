using MercadonaStudi.Context;
using MercadonaStudi.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace MercadonaStudi.Test
{
    internal class AppDbContextMock
    {
        private DbConnection _dbConnection;
        private DbContextOptions<AppDbContext> _contextOptions;

        public AppDbContext Context { get; }

        public AppDbContextMock()
        {
            // Création et ouverture d'une connexion
            _dbConnection = new SqliteConnection("Filename=:memory:");
            _dbConnection.Open();

            // Création d'un contexte de test
            _contextOptions = new DbContextOptionsBuilder<AppDbContext>().UseSqlite(_dbConnection).Options;

            // Création d'une nouvelle instance du contexte
            Context = new AppDbContext(_contextOptions);
            Context.Database.EnsureCreated();

            // Remplissage de la base de données
            Context.Categories.AddRange(new List<Category>()
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

            Context.Offers.AddRange(new List<Offer>()
            {
                new Offer()
                {
                    StartDate = DateTime.Now.AddDays(-10),
                    EndDate = DateTime.Now.AddDays(10),
                    Percentage = 0
                }
            });

            Context.Products.AddRange(new List<Product>()
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

            Context.SaveChanges();
        }

        public void Dispose() => _dbConnection.Dispose();

    }
}
