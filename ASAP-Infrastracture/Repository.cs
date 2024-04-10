using ASAP_Application.Contract;
using ASAP_Context;
using ASAP_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASAP_Infrastracture
{
    public class Repository<T, TID> : IRepo<T, TID> where T : class
    {
        ASAPDBcontext? asapDbContext { get; set; }
        DbSet<T> DbSetEntity;
        public Repository(ASAPDBcontext _ASAPDbContext)
        {
            asapDbContext = _ASAPDbContext;
            DbSetEntity = _ASAPDbContext.Set<T>();
        }


        public async Task<T> CreateEntity(T Entity)
        {
            var add = (await DbSetEntity.AddAsync(Entity)).Entity;
            return add;
        }


        public async Task<T> GetEntitybyId(TID id)
        {
           var entity =  await DbSetEntity.FindAsync(id);
            if(entity != null)
            {
                return entity;
            }
            return null!;
        }

        public async Task<T> DeleteEntity(TID id)
        {
            var client = await DbSetEntity.FindAsync(id);
            if (client != null)
            {
                DbSetEntity.Remove(client);
            }
            return client;
        }


        

        public async Task<int> Save()
        {
            var number =await asapDbContext!.SaveChangesAsync();
            if(number>0)
            {
                return 1;
            }
            return 0;
        }

        public async Task<T> UpdateEntity(T Entity)
        {
            var client = (DbSetEntity.Update(Entity)).Entity;
            if(client != null)
            {
                return client;
            }
            return null!;


        }

        public async Task<IQueryable<T>> GetAllEntity()
        {
            return   DbSetEntity.Select(s => s);
        }
    }
}
