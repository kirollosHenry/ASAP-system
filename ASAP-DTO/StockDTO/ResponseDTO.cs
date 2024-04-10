using ASAP_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASAP_DTO.StockDTO
{
    public class ResponseDTO
    {
        public List<Stock> results { get; set; }

        public string status { get; set; }

        public string request_id { get; set; }

        public string next_url { get; set; }

    
    }
}
