using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp2_ex2.DAL
{


    class GenericRepository<TEntity> where TEntity:class
    {
        internal DbSet<TEntity> dbSet;
        internal OnlineShoppingContext context; 


        public GenericRepository(OnlineShoppingContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();  
        }

        public virtual IEnumerable<TEntity>  GetAll()
        {
            return dbSet.ToList(); 
        }

        public virtual TEntity GetByID( int Id)
        {
            return dbSet.Find(Id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity); 
        }

        public virtual void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State= EntityState.Modified; 
        }

        public virtual void Delete(int Id)
        {
            TEntity entity = dbSet.Find(Id);
            dbSet.Remove(entity); 
        }

        public virtual void Delete(TEntity entity)
        {
            /*This is used for concurrency purposes*/

            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity); 
        }
    }
}
