using ASAP_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASAP_Application.Contract
{
    public interface IStockRepo : IRepo<Stock, int>
    {
        Task<bool> AddRangeAsync(IEnumerable<Stock> stocks);
    }
}
