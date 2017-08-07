using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MarmyzaShop.Models
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() : base("name=DefaultConnection")
        {

        }
    }
}