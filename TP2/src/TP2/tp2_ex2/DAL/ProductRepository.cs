using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp2_ex2.Models;

namespace tp2_ex2.DAL
{
    class ProductRepository:GenericRepository<Product>
    {
        public ProductRepository(OnlineShoppingContext context) : base(context)
        {}

        public Product GetByTitle(string title)
        {
            return dbSet.FirstOrDefault(p => p.Title == title);
        }

    }
}
