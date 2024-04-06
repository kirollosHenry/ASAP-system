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
    public class ClientRepository : Repository<Client, int> 
    {
        public ClientRepository(ASAPDBcontext _DbContext) : base(_DbContext)
        {
        }

    }
}
