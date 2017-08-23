using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarmyzaShop.Interfaces;
using Moq;
using MarmyzaShop.Models.Product;

namespace MarmyzaShop.Tests.Controllers.Category
{
    [TestClass]
    class CategoryTestController
    {

        public readonly IRepository<Models.Product.ProductCategory> MockProductsRepository;

        public CategoryTestController()
        {
            IList<Models.Product.ProductCategory> products = new List<Models.Product.ProductCategory>
                {
                new ProductCategory()
                {
                    Id = new Guid("fd9d8bf1-4148-4004-82f1-c06bc88c478b"),
                    Name = "Test"
                }
                };

            // Mock the Products Repository using Moq
            Mock<IRepository<Models.Product.ProductCategory>> mockProductRepository = new Mock<IRepository<Models.Product.ProductCategory>>();

            mockProductRepository.Setup(mr => mr.GetByID(
                It.IsAny<int>())).Returns((Guid i) => products.Where(
                x => x.Id == i).Single());


            this.MockProductsRepository = mockProductRepository.Object;
        }

        [TestMethod]
        public void CanReturnProductById()
        {
            ProductCategory testProduct = this.MockProductsRepository.GetByID(new Guid("fd9d8bf1-4148-4004-82f1-c06bc88c478b"));

            Assert.IsNotNull(testProduct); 
            Assert.IsInstanceOfType(testProduct, typeof(Product)); 
            Assert.AreEqual("Test", testProduct.Name); 
        }
    }
}
