using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASAP_Application.Services.Hangifure
{
    public class JobService : IJobService
    {
        public void ContinuationJob()
        {
            Console.WriteLine("Hello ContinuationJob");
        }

        public void DelayedJob()
        {
            Console.WriteLine("Hello from Good from the here everything well be ok  and Forget job!");
        }

        public void FireAndForgetJob()
        {
            Console.WriteLine("Hello  fired from a Fire and Forget job!");
        }

        public void ReccuringJob()
        {
            Console.WriteLine("Hello  ReccuringJob from a Fire and Forget job!");
        }
    }
}
