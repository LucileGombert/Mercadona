using MercadonaStudi.Controllers;
using MercadonaStudi.Models;

namespace MercadonaStudi.Test
{
    public class CategoriesControllerTest
    {
        private AppDbContextMock _appDbContextMock = new AppDbContextMock();

        public void Dispose() => _appDbContextMock.Dispose();


        [Fact]
        //Permet de tester que le résultat obtenu est bien de type List<Category>
        public void GetAllCategories_All_ReturnListCategoryResult()
        {
            // Arrange
            CategoriesController controller = new CategoriesController(_appDbContextMock.Context);

            // Act
            var result = controller.GetAllCategories();

            // Assert
            var actionResult = Assert.IsType<List<Category>>(result);
            Assert.Equal(_appDbContextMock.Context.Categories, actionResult);
        }


        [Fact]
        //Permet de tester que le résultat obtenu (nombre de catégories) est bien égal au nombre de catégories présente dans la base de données
        public void GetAllCategories_All_ReturnAllCategories()
        {
            // Arrange
            CategoriesController controller = new CategoriesController(_appDbContextMock.Context);

            // Act
            var result = controller.GetAllCategories();

            // Assert
            Assert.Equal(_appDbContextMock.Context.Categories.Count(), result.Count());
        }
    }
}
