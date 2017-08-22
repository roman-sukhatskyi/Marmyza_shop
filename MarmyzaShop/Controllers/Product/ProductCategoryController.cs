using MarmyzaShop.Implementations;
using MarmyzaShop.Interfaces;
using MarmyzaShop.Models;
using MarmyzaShop.Models.Product;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
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

        [Route("api/categories")]
        [HttpGet]
        public IEnumerable<ProductCategory> Get()
        {
            var categories = unitOfWork.GetRepository<ProductCategory>();
            return categories.Get();
        }

        [Route("api/category/create")]
        [HttpPost]
        public HttpResponseMessage CreateCategory([FromBody]ProductCategory request)
        {
            try
            {
                var categories = unitOfWork.GetRepository<ProductCategory>();
                var category = categories.Get(x => x.Code == request.Code).FirstOrDefault();
                if (category == null)
                {
                    category = new ProductCategory()
                    {
                        Name = request.Name,
                        Code = request.Code,
                        Image = request.Image
                    };
                    categories.Insert(category);
                }
                unitOfWork.Save();
                return Request.CreateResponse(HttpStatusCode.Created, category);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }          
        }
        [Route("api/category/update")]
        [HttpPut]
        public HttpResponseMessage UpdateCategory([FromBody]ProductCategory request)
        {
            var categories = unitOfWork.GetRepository<ProductCategory>();
            var category = categories.Get(x => x.Code == request.Code).FirstOrDefault();
            if (category == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                category.Name = request.Name;
                category.Image = request.Image;
                categories.Update(category);
                unitOfWork.Save();
                return Request.CreateResponse(HttpStatusCode.OK, category);
            }  
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [Route("api/category/delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteCategory(Guid Id)
        {
            var categories = unitOfWork.GetRepository<ProductCategory>();
            var category = categories.Get(x => x.Id == Id).FirstOrDefault();
            if (category == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            try
            {
                categories.Delete(category);
                unitOfWork.Save();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
