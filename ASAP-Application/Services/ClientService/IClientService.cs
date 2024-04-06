using ASAP_DTO.ClientDTO;
using ASAP_DTO;
using ASAP_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASAP_Application.Services.CientService
{
    public interface IClientService
    {
        public List<Client> GetAllPagination(int PageNum, int num = 10);

        public Client GetById(int id);

        public Task<ReturnDTO<CreateClientDto>> CreateClient(CreateClientDto client);

        public Task<Client> GetByEmail(string email);

        public Client UpdateClient(int id);


        public Client DeleteClient(int id);


       
    }
}
