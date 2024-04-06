using ASAP_DTO.ClientDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASAP_DTO
{
    public  class ReturnDTO<T>
    {
        public string message { get; set; }

        public T? entityDto { get; set; }

        public bool status { get; set; }

    }
}
