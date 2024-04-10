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
        Task<List<Client>> SearchByName(string Name);

        Task<List<Client>> SearchByphone(string phone);

        Task<Client> SearchByEmail(string Email);

        Task<List<string>> GetAllEMail();


    }
}
