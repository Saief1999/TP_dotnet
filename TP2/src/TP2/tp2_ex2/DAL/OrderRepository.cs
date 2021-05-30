using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp2_ex2.Models;

namespace tp2_ex2.DAL
{
    class OrderRepository : GenericRepository<Order>
    {

        public OrderRepository(OnlineShoppingContext context) : base(context)
        { }

        public override IEnumerable<Order> GetAll()
        {
            return base.dbSet.Include("Products").ToList();
        }
    }
}
