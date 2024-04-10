using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASAP_Models
{
    public  class Stock
    {
        public int Id { get; set; }   


        public DateTime Date { get; set; }

        public string? Exchange { get; set; }

        public string? Name { get; set; }

        public string? Status { get; set; }
    }
}
