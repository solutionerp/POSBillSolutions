using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using POSBill.Domain.Models;
using POSBill.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSBill.EntityFramework.Services
{
    public class GenericDataService<T> : IDataServices<T> where T : DomainObject
    {
        private readonly RestaurantRetailPOSBillDBContextFactory _contextFactory;

        public GenericDataService(RestaurantRetailPOSBillDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using(RestaurantRetailPOSBillDBContext context = _contextFactory.CreateDbContext())
            {
               EntityEntry<T> createdResult= await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
                return createdResult.Entity;
            }

        }

        public async Task<bool> Delete(int id)
        {
            using (RestaurantRetailPOSBillDBContext context = _contextFactory.CreateDbContext())
            {
                T entity= await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public Task<T> ExecuteQuery(string strQuery)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Get(int id)
        {
            using (RestaurantRetailPOSBillDBContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (RestaurantRetailPOSBillDBContext context = _contextFactory.CreateDbContext())
            {
              IEnumerable<T>  entities = await context.Set<T>().ToListAsync();
                return entities;
            }
        }

        public Task<IEnumerable<T>> GetByQuery(string strQuery)
        {
            throw new NotImplementedException();
        }

        public async Task<T> Update(int id, T enitity)
        {
            using (RestaurantRetailPOSBillDBContext context = _contextFactory.CreateDbContext())
            {
                enitity.Id = id;
                context.Set<T>().Update(enitity);
                await context.SaveChangesAsync();

                return enitity;
            }
        }
    }
}
