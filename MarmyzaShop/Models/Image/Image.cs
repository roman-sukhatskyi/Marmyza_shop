using MarmyzaShop.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarmyzaShop.Models.Image
{
    public class Image : Entity
    {
        public string Data { get; set; }
        public string Key { get; set; }
    }
}