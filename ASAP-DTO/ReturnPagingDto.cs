using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASAP_DTO
{
    public class ReturnPagingDto<T>
    {
        public List<T>? data { get; set; }
        public int total { get; set; }
       // public string? Message { get; set; }

        public ReturnPagingDto()
        {
            data = new List<T>();
        }
    }
}
