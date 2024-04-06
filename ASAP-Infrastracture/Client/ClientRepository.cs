using ASAP_Application.Contract;
using ASAP_Context;
using ASAP_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASAP_Infrastracture.ClientRepository
{
    public class ClientRepository : Repository<Client, int> , IClientRepo
    {
        public ClientRepository(ASAPDBcontext _DbContext) : base(_DbContext)
        {
        }

        public Task<IQueryable<Client>> SearchByEmail(string Name)
        {
            throw new NotImplementedException();
        }

        public Task<Client> SearchByName(string Name)
        {
            throw new NotImplementedException();
        }

        public Task<Client> SearchByphone(string Name)
        {
            throw new NotImplementedException();
        }

     
    }
}
