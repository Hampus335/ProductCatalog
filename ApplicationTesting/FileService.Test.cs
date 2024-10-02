using Moq;
using ProductCatalog.Enums;
using ProductCatalog.Products;
using ProductCatalog.Services;

namespace ProductCatalog.Test
{
    public class FileServiceTest
    {
        private readonly Mock<IFileService> _fileService = new();
        [Fact]
        public void Test1()
        {
            // Arrange

            List<Product> products = new List<Product>
            {
                new Product(Guid.NewGuid(), "Laptop", Categories.Category.Clothing, 1200.99m, "High-performance laptop for work and gaming"),
                new Product(Guid.NewGuid(), "T-shirt", Categories.Category.Toys, 19.99m, "Comfortable cotton t-shirt"),
                new Product(Guid.NewGuid(), "Pizza", Categories.Category.Electronics, 8.99m, "Delicious cheese pizza with extra toppings")
            };
            ApplicationState applicationState = new(products, _fileService.Object);

            var listLengthBeforeProductAdd = products.Count;

            // Act
            applicationState.AddProduct(new Product(Guid.NewGuid(), "Audi R8", Categories.Category.Cars, 8.99m, "Nice car"));

            // Assert

            Assert.Equal(listLengthBeforeProductAdd + 1, products.Count);
        }
    }
}
