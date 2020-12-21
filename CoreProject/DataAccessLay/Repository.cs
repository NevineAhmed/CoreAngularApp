using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccessLay
{
    public class Repository<T> : Irepository<T> where T : class
    {
        internal DbContext _context;
        internal DbSet<T> _dbSet;
        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();

        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            if (_context.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> filter = null,
    Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
    string includeProperties = "")
        {
            IQueryable<T> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach(var prop in (includeProperties.Split(new char[] { ','},StringSplitOptions.RemoveEmptyEntries)))
                {
                   query= query.Include(prop);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query).AsNoTracking();
            }

            else
            {
                return query.AsNoTracking();
            }
                
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet.AsNoTracking();
        }

        public void Update(T entity)
        {
            
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }



    }
}
