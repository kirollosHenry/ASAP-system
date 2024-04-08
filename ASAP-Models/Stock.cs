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
        public int split_from { get; set; }
        public int split_to { get; set; }
        public string ticker { get; set; }
    }
}
