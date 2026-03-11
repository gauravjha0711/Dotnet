using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace StudentManagementSystem.Repositories.Implementations
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly StudentDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(StudentDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public void Delete(int id)
        {
            var entity = _dbSet.Find(id);

            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }
    }
}