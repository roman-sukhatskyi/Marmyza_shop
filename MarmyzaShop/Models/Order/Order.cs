using MarmyzaShop.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MarmyzaShop.Models.Order
{
    public class Order : Entity
    {
        public virtual ICollection<OrderProduct.OrderProduct> OrderProducts { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }
    }
}