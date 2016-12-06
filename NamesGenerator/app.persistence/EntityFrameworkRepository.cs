using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.domain;
using Microsoft.EntityFrameworkCore;

namespace app.persistence
{
    public class EntityFrameworkRepository<T> : IRepository<T> where T : Entity
    {

            private readonly DbContext _context;

            public EntityFrameworkRepository(ApplicationDbContext dbContext)
            {
                _context = dbContext;
            }

            public IQueryable<T> GetAll()
            {
                return _context.Set<T>().AsQueryable();
            }

            public T GetById(int id)
            {
                return _context.Set<T>().FirstOrDefault(x => x.Id == id);
            }

            public void Delete(T entity)
            {
                _context.Set<T>().Remove(entity);
                _context.SaveChanges();
            }

            public void Add(T entity)
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();
            }

            public void Update(T entity)
            {
                _context.Set<T>().Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }

        
    }
}
