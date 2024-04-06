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


        public async Task<ReturnDTO<CreateClientDto>> GetById(int id)
        {
            var result = await _clientRepo.GetEntitybyId(id);
            if (result == null)
            {
                return new ReturnDTO<CreateClientDto>
                {
                    message = "No client found with the specified ID",
                    status = false
                };
            }
            else
            {
               
                var clientDto = _mapper.Map<Client,CreateClientDto>(result);
                return new ReturnDTO<CreateClientDto>
                {
                    message = "Client found",
                    entityDto = clientDto,
                    status = true
                };
            }

        }



        public async Task<ReturnDTO<CreateClientDto>> DeleteClient(int id)
        {
            var existingClient = await _clientRepo.GetEntitybyId(id);
            if (existingClient == null)
            {
                return new ReturnDTO<CreateClientDto>
                {
                    message = "Client not found",
                    status = false
                };
            }

             var result =await _clientRepo.DeleteEntity(id);
            await _clientRepo.Save();
            var clientDto = _mapper.Map<Client, CreateClientDto>(result);
            return new ReturnDTO<CreateClientDto>
            {
                message = "Client deleted successfully",
                entityDto= clientDto,
                status = true
            };
        }



        public async  Task<ReturnDTO<CreateClientDto>> UpdateClient(CreateClientDto client)
        {
            var existingClient = await _clientRepo.GetEntitybyId(client.ClientId);

            if (existingClient != null)
            {
                if (await _clientRepo.SearchByEmail(client.Email) == null || client.Email == existingClient.Email )
                {
                    existingClient.PhoneNumber = client.PhoneNumber;
                    existingClient.LastName = client.LastName;
                    existingClient.FirstName = client.FirstName;
                    existingClient.Email = client.Email;
                    var result = await _clientRepo.UpdateEntity(existingClient);
                    await _clientRepo.Save();
                    var clientDto = _mapper.Map<Client, CreateClientDto>(result);
                    return new ReturnDTO<CreateClientDto>
                    {
                        message = "Client update successfully",
                        entityDto = clientDto,
                        status = true
                    };
                }
                
                return new ReturnDTO<CreateClientDto>
                {
                    message = "email found",
                    entityDto = client,
                    status = false
                };
                
            }
            else
            {
                return new ReturnDTO<CreateClientDto>
                {
                    message = "Client not found",
                    status = false
                };
            }


        }




        public async Task<ReturnPagingDto<AllClientDTO>> GetAllPagination(int num ,int PageNum)
        {
            var allclient=await _clientRepo.GetAllEntity();
            var client = allclient.Skip(num * (PageNum - 1)).Take(num)
                .Select(c => new AllClientDTO
                {
                    ClientId = c.ClientId,
                    PhoneNumber = c.PhoneNumber,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                }).ToList();
            return new ReturnPagingDto<AllClientDTO>
            {
                Entities = client,
                Count = allclient.Count(),
                Message="product retreive"
            };
        }




        public Task<Client> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }




    }
}
