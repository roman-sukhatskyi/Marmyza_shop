using MarmyzaShop.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MarmyzaShop.Models.OrderProduct
{
    public class OrderProduct : Entity
    {
        public Product.Product Product { get; set; }

        [ForeignKey("Product")]
        public Guid? ProductId { get; set; }

        public Order.Order Order { get; set; }

        [ForeignKey("Order")]
        public Guid? OrderId { get; set; }

        public int? Quantity { get; set; }

        public decimal? Amount { get; set; }

        //public RegisterBindingModel RegisterBindingModel { get; set; }

        //[ForeignKey("RegisterBindingModel")]
        //public Guid? UserId { get; set; }
    }
}