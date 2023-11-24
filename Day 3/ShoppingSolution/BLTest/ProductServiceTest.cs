using ShoppingModelLibrary;
using ShoppingBLLibrary;

namespace BLTest
{
    public class ProductServiceTest
    {
        IProductService _Service;

        [SetUp]
        public void Setup()
        {
            _Service = new ProductService();
        }

        [Test]
        public void AddProductTest()
        {
            var res = _Service.AddProduct(new Product { Name = "pencil" });
            Assert.IsNotNull(res);
        }
        [Test]
        public void GetAllProductsTest()
        {
            //Arrange
            var prod = _Service.AddProduct(new Product { Name = "pencil" });
            //Action
            var res = _Service.GetProducts();
            //Assert
            Assert.AreEqual(1, res.Count);
        }
        [TestCase(1, "Pencil")]
        public void GetProductTest(int id, string name)
        {
            var prod = _Service.AddProduct(new Product { Name = "pencil" });
            var res = _Service.GetProduct(1);
            Assert.That(res.Id, Is.EqualTo(id));
        }

    }

}