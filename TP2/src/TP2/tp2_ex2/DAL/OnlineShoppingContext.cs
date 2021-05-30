using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp2_ex2.Models;

namespace tp2_ex2.DAL
{
    class OnlineShoppingContext:DbContext
    {
        public OnlineShoppingContext():base("name=OnlineShoppingDB")
        {}
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
