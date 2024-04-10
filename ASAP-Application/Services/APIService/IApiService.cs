using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASAP_Application.Services.APIService
{
    public  interface IApiService
    {
         Task<string> GetDataAsync();

    }
}
