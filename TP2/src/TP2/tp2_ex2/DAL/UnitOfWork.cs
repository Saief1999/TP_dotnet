using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tp2_ex2.Models;

namespace tp2_ex2.DAL
{
    class UnitOfWork : IDisposable
    {

        private readonly OnlineShoppingContext _context;
        private CategoryRepository categoryRepository;
        private ProductRepository productRepository;
        private OrderRepository orderRepository;


        public UnitOfWork(OnlineShoppingContext context)
        {
            this._context = context;
        }

        public CategoryRepository CategoryRepository
        {
            get
            {
                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new CategoryRepository(_context);
                }
                return this.categoryRepository;
            }
        }

        public ProductRepository ProductRepository
        {
            get
            {

                if (this.productRepository == null)
                {
                    this.productRepository = new ProductRepository(_context);
                }
                return this.productRepository;
            }
        }

        public OrderRepository OrderRepository
        {
            get
            {
                if (this.orderRepository == null)
                {
                    this.orderRepository = new OrderRepository(_context);
                }
                return this.orderRepository;
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
