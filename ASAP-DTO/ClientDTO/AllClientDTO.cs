﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASAP_DTO.ClientDTO
{
    public  class AllClientDTO
    {
        public int ClientId { get; set; }

      
        public string? FirstName { get; set; }

   
        public string? LastName { get; set; }

       
        public string? PhoneNumber { get; set; }
     
     
        public string? Email { get; set; }
    }
}
