using ASAP_Application.Contract;
using ASAP_Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASAP_Infrastracture
{
    public class Repository<T, TID> : IRepo<T, TID> where T : class
    {
        ASAPDBcontext? hostelDbContext { get; set; }
        public Repository(ASAPDBcontext _hostelDbContext)
        {
            hostelDbContext = _hostelDbContext;

        }

        public List<T> GetAllEntity()
        {
            var QueryAllEntity = hostelDbContext!.Set<T>();
            return QueryAllEntity.ToList();
        }

    

        public T CreateEntity(T Entity)
        {
            var QueryCreateEntity = hostelDbContext!.Set<T>().Add(Entity).Entity;
            return QueryCreateEntity;
        }

        public T UpdateEntity(T Entity)
        {
            return hostelDbContext!.Set<T>().Update(Entity).Entity;
        }

        public T DeleteEntity(TID id)
        {
            var EntityToDelete = hostelDbContext!.Set<T>().Find(id);
            if (EntityToDelete != null)
            {
                hostelDbContext.Set<T>().Remove(EntityToDelete);
                hostelDbContext.SaveChanges();
            }
            return EntityToDelete!;
        }

        public int Save()
        {
            return hostelDbContext!.SaveChanges();
        }
    }
}
