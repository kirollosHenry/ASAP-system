using ASAP_Application.Contract;
using ASAP_Context;
using ASAP_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASAP_Infrastracture.stock
{
    public class StockRepository : Repository<Stock, int> , IStockRepo
    {
        ASAPDBcontext context;
        public StockRepository(ASAPDBcontext _context) : base(_context)
        {
            context = _context;
        }



        public async Task<bool> AddRangeAsync(IEnumerable<ASAP_Models.Stock> stocks)
        {
            await context.stocks.AddRangeAsync(stocks);
            await context.SaveChangesAsync();
            if (await context.SaveChangesAsync()>0)
                return true;
            return false;
        }
    }
}
