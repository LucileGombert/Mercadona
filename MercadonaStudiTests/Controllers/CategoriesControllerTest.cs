//using MercadonaStudi.Controllers;
//using MercadonaStudi.Models;
//using Microsoft.AspNetCore.Mvc.ModelBinding;
//using Microsoft.AspNetCore.Mvc.ViewFeatures;
//using Microsoft.AspNetCore.Mvc;
//using NuGet.Protocol.Core.Types;
//using System.Reflection.Emit;
//using MercadonaStudi.Context;
//using Moq;
//using System;

//namespace MercadonaStudi.Test.Controllers
//{
//    public class CatgeoriesControllerTest
//    {
//        private readonly Mock<AppDbContext> _mockAppDbContext;

//        public CatgeoriesControllerTest()
//        {
//            _mockAppDbContext = new Mock<AppDbContext>();
//        }

//        private List<Category> categories = new List<Category>()
//        {
//            new Category{Id=1, Label="Premi�re cat�gorie de test"},
//            new Category{Id=2, Label="Premi�re cat�gorie de test"},
//            new Category{Id=3, Label="Premi�re cat�gorie de test"}
//        };

        


//        [Test]
//        public void GetCategories_ShouldReturnTrueOnSuccess()
//        {
//            // Arrange : initialisation des objets et des variables
//            var mockAppDbContext = new Mock<AppDbContext>();
//            var controller = new CategoriesController(mockAppDbContext.Object);

//            // Act : ex�cution de la m�thode � tester
//            //var result = (ViewResult)controller.Index();
//            //var model = (IList<Category>)result.ViewData.Model;
//            var result = controller.Index() as ViewResult;

//            // Assert : v�rification du r�sultat attendu
//            Assert.AreEqual("Cat�gories ", result.ViewName);
//        }

//        //private readonly Category _category;
//        //private readonly IEnumerable<Category> _categories;
//        //private readonly IEnumerable<Category> _categoryList = new List<Category>();
//        //public CatgeoriesControllerTest(Category category)
//        //{
//        //    _category = new Category()
//        //    {
//        //        Label = "Nouvelle cat�gorie de test"
//        //    };

//        //    _categories = new List<Category>() 
//        //    { 
//        //        _category 
//        //    };
//        //}

//        //[SetUp]
//        //public void Setup()
//        //{
//        //}

//        //[Test]
//        //public void CreateCategory_LabelParam_ReturnIndexWithNewCategory()
//        //{
//        //    // Arrange : initialisation des objets et des variables
//        //    var categoryCreator = new CategoriesController();
//        //    string label = "Nouvelle cat�gorie de test";

//        //    // Act : ex�cution de la m�thode � tester
//        //    var testResult = ;

//        //    // Assert : v�rification du r�sultat attendu
//        //    Assert.Pass();

//        //    // Arrange
//        //    var categories = new List<Category>
//        //    {
//        //        new Category { Id=1, Label="Nouvelle cat�gorie de test"}

//        //    };

//        //    var mockRepository = new Mock<CategoriesController>();
//        //    mockRepository.Setup(r => r.ListMovies()).Returns(movies);
//        //    var controller = new MoviesController(mockRepository.Object);

//        //    // this is a workaround for a bug
//        //    controller.ViewData = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary());

//        //    // Act
//        //    var result = (ViewResult)controller.Index();
//        //    var model = (IList<Movie>)result.ViewData.Model;

//        //    // Assert
//        //    Assert.Equal("Star Wars", model.First().Title);
//        //}
//    }
//}