using MarmyzaShop.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarmyzaShop.Models.Product
{
    public class ProductCategory : Entity
    {
        public ProductCategory()
        {
            Products = new List<Product>();
        }
        public string Image { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}