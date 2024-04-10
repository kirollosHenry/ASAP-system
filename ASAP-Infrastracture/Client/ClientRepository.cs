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

        public async Task<List<string>> GetAllEMail()
        {

           var email = await dbcontext.clients.Select(c => c.Email).ToListAsync();
            if (email is null)
                return null!;
            else 
            return email!;
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
                
                return null!;
            }
           
        }

        public async Task<List<Client>> SearchByName(string Name)
        {
            
            var nameParts = Name.Split(' ');

           
            var entities = await dbcontext.clients
                .Where(e => nameParts.Any(p => e.FirstName.Contains(p)) || nameParts.Any(p => e.LastName.Contains(p)))
                .ToListAsync();
            if (entities != null)
            {
                return entities;
            }
            return null!;
        }

        public async Task<List<Client>> SearchByphone(string phone)
        {
            var entities = await dbcontext.clients.Where(e => e.PhoneNumber!.Contains(phone)).ToListAsync();
            if (entities.Count() > 0)
            {
                return entities;
            }
            return null!;
        }
    }
}
