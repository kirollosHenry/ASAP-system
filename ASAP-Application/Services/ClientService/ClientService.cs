using ASAP_Application.Contract;
using ASAP_DTO;
using ASAP_DTO.ClientDTO;
using ASAP_Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASAP_Application.Services.CientService
{
    public class ClientService : IClientService
    {
        private readonly IClientRepo _clientRepo;
        private readonly IMapper _mapper;

        public ClientService(IClientRepo clientRepo , IMapper mapper)
        {
            _clientRepo = clientRepo;
            _mapper = mapper;
        }


        public async Task<ReturnDTO<CreateClientDto>> CreateClient(CreateClientDto client)
        {
            if (client != null)
            {
                try
                {
                    var result = await _clientRepo.SearchByEmail(client.Email);
                    if (result ==null)
                    {
                        var mappclient = _mapper.Map<CreateClientDto, Client>(client);
                        var back=  await _clientRepo.CreateEntity(mappclient);
                        var result1= await _clientRepo.Save();
                        var ret= _mapper.Map<Client, CreateClientDto>(back);
                        if (result1 > 0)
                        {
                            return new ReturnDTO<CreateClientDto>()
                            {
                                message = "the create client update sucess",
                                entityDto = ret,
                                status = true
                            };
                        }else 
                        return new ReturnDTO<CreateClientDto>()
                        {
                            message = "the error happen to create in database ",
                            entityDto = client,
                            status = false

                        };
                    }
                    else
                    {
                        return new ReturnDTO<CreateClientDto>()
                        {
                            message = "email  find in database  ",
                            entityDto = client,
                            status = false

                        };
                    }
                    
                }
                catch (Exception ex)
                {
                    return new ReturnDTO<CreateClientDto> { message = ex.Message, entityDto = null, status = false };
                }
            }


            else
            {
                return new ReturnDTO<CreateClientDto>()
                {
                    message = "the object equal null ",
                    entityDto = null,
                    status = false
                };
            }
        }

        public Task<Client> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Client DeleteClient(int id)
        {
            throw new NotImplementedException();
        }

        public List<Client> GetAllPagination(int PageNum, int num = 10)
        {
            throw new NotImplementedException();
        }

        public Client GetById(int id)
        {
            throw new NotImplementedException();
        }

       

        public Client UpdateClient(int id)
        {
            throw new NotImplementedException();
        }
    }
}
