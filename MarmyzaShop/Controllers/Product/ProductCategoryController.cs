using MarmyzaShop.Implementations;
using MarmyzaShop.Interfaces;
using MarmyzaShop.Models;
using MarmyzaShop.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace MarmyzaShop.Controllers.Product
{
    public class ProductCategoryController : ApiController
    {
        IUnitOfWork unitOfWork;
        public ProductCategoryController()
        {
            this.unitOfWork = new UnitOfWork<ApplicationDbContext>();
        }
        [Route("api/category/get")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var productCategory = unitOfWork.GetRepository<ProductCategory>();
            var category = productCategory.Get(x => x.Name.Equals("Термокружки")).FirstOrDefault();
            var result = new
            {
                Name = category.Name
            };
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        
        //[HttpPost]
        //[HttpPut]
        //[HttpDelete]
    }
}
