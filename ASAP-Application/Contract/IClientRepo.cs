using ASAP_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASAP_Application.Contract
{
    public  interface IClientRepo :IRepo<Client,int>
    {
        Task<IQueryable<Client>> SearchByName(string Name);

        Task<Client> SearchByphone(string Name);

        Task<Client> SearchByEmail(string Name);


    }
}
