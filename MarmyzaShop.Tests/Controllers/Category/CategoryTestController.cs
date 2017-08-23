using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarmyzaShop.Interfaces;
using Moq;
using MarmyzaShop.Models.Product;
using System.Linq.Expressions;
using MarmyzaShop.Implementations;
using MarmyzaShop.Models;

namespace MarmyzaShop.Tests.Controllers.Category
{
    [TestClass]
    public class CategoryTestController
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
                    },
                    new ProductCategory()
                    {
                        Id = new Guid("fd9d8bf2-4148-4004-82f1-c06bc88c478b"),
                        Name = "Test2"
                    },
                    new ProductCategory()
                    {
                        Id = new Guid("fd9d8bf3-4148-4004-82f1-c06bc88c478b"),
                        Name = "Test3"
                    },
                    new ProductCategory()
                    {
                        Id = new Guid("fd9d8bf4-4148-4004-82f1-c06bc88c478b"),
                        Name = "Test4"
                    }
                };

            Mock<IRepository<Models.Product.ProductCategory>> mockProductRepository = new Mock<IRepository<Models.Product.ProductCategory>>();

            mockProductRepository.Setup(mr => mr.GetByID(
                It.IsAny<Guid>())).Returns((Guid i) => products.Where(
                x => x.Id == i).Single());

            mockProductRepository.Setup(g => g.Get(It.IsAny<Expression<Func<ProductCategory, bool>>>(),
                It.IsAny<Func<IQueryable<ProductCategory>, IOrderedQueryable<ProductCategory>>>(), It.IsAny<string>())).Returns(products);


            this.MockProductsRepository = mockProductRepository.Object;
        }

        [TestMethod]
        public void CanReturnProductById()
        {
            ProductCategory testProduct = this.MockProductsRepository.GetByID(new Guid("fd9d8bf1-4148-4004-82f1-c06bc88c478b"));

            Assert.IsNotNull(testProduct); 
            Assert.IsInstanceOfType(testProduct, typeof(ProductCategory)); 
            Assert.AreEqual("Test", testProduct.Name); 
        }

        [TestMethod]
        public void CanReturnProductsByName()
        {
            var unit = new UnitOfWork<ApplicationDbContext>();
            var rep = unit.GetRepository<ProductCategory>();
            IEnumerable<ProductCategory> productsByName2 = rep.Get(x => x.Name == "Test2");
            IEnumerable<ProductCategory> productsByName = this.MockProductsRepository.Get(x => x.Name == "Test2");

            Assert.IsNotNull(productsByName);
            Assert.IsInstanceOfType(productsByName, typeof(IEnumerable<ProductCategory>));
            Assert.AreEqual(new List<ProductCategory>()
            {
                new ProductCategory
                {
                    Id = new Guid("fd9d8bf2-4148-4004-82f1-c06bc88c478b"),
                    Name = "Test2"
                }
            }, productsByName);
        }
    }
}
