using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp2_ex2.Models;

namespace tp2_ex2.DAL
{
    class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(OnlineShoppingContext context):base(context)
        {}

        //Include : Used to add the products to the result
        public override IEnumerable<Category> GetAll()
        {
            return dbSet.Include("Products").ToList();
        }

        public Category GetByName(string name )
        {
            return dbSet.FirstOrDefault(c => c.Name == name);
        }
    }
}
