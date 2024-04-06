using ASAP_Application.Contract;
using ASAP_Context;
using ASAP_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASAP_Infrastracture.ClientRepository
{
    public class ClientRepository : Repository<Client, int> , IClientRepo
    {
        ASAPDBcontext dbcontext;
        public ClientRepository(ASAPDBcontext _DbContext) : base(_DbContext)
        {
            dbcontext = _DbContext  ?? throw new ArgumentNullException(nameof(_DbContext));
        }

        public async Task<Client> SearchByEmail(string Email)
        {
            try
            {
                var client = await dbcontext.clients.FirstOrDefaultAsync(x => x.Email == Email);
                if (client == null)
                {
                    return null!;
                }
                return client;
            }
            catch (Exception ex)
            {
                
                return null;
            }
           

        }

        public Task<IQueryable<Client>> SearchByName(string Name)
        {
            throw new NotImplementedException();
        }

        public Task<Client> SearchByphone(string phone)
        {
            throw new NotImplementedException();
        }
    }
}
