using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASAP_Application.Contract
{
    // I use Generaic interface  to help me when add new model and User the Crud Operation   
    public interface IRepo<T, TID>
    {
        
        Task<T> CreateEntity(T Entity);

        Task<T> GetEntitybyId(TID id);

        Task<T> DeleteEntity(TID id);

        Task<T> UpdateEntity(T Entity);

        Task<IQueryable<T>> GetAllEntity();

        Task<int> Save();

    }
}
