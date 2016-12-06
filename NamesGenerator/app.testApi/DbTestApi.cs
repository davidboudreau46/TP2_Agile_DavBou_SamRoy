using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app.domain;
using Microsoft.EntityFrameworkCore.Infrastructure;
using app.persistence;

namespace app.testApi
{
    public class DbTestApi
    {
        private static ApplicationDbContext _dbContext;

        static DbTestApi()
        {
            var factoryContext = new ApplicationDbContextFactory();
            _dbContext = factoryContext.Create(new DbContextFactoryOptions());
        }

        public static void ClearAllTables()
        {
            _dbContext.DogNames.RemoveRange(_dbContext.DogNames);
            _dbContext.SaveChanges();
        }
        public static void CreateDogName(DogName dogName)
        {
            var dognameRepo = new EntityFrameworkRepository<DogName>(_dbContext);
            dognameRepo.Add(dogName);
        }
    }
}
