using ASAP_DTO.ClientDTO;
using ASAP_Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASAP_Application.Mapper
{
    public  class MappingProfiles :Profile
    {
        public MappingProfiles()
        {
          //  CreateMap<CreateClientDto, Client>();
           
            CreateMap<CreateClientDto, Client>()
                    .ForMember(dest => dest.ClientId, opt => opt.Ignore());

            CreateMap<Client, CreateClientDto>();

        }
    }
}
