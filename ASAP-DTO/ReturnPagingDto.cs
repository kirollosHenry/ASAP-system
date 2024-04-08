using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASAP_DTO
{
    public class ReturnPagingDto<T>
    {
        public List<T>? Entities { get; set; }

        public int Count { get; set; }

        public string? Message { get; set; }

        public ReturnPagingDto()
        {
            Entities = new List<T>();
        }
    }
}
