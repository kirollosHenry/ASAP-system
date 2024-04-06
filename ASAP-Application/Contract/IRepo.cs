using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASAP_Application.Contract
{
    public interface IRepo<T, TID>
    {
        Task<IQueryable<T>> GetAllEntity();

       

      

        Task<T> CreateEntity(T Entity);

        Task<T> UpdateEntity(T Entity);

        Task<T> DeleteEntity(TID id);

        Task<int> Save();

    }
}
