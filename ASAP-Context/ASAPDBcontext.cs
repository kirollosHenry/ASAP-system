using ASAP_Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASAP_Context
{
    public class ASAPDBcontext :DbContext
    {
        public DbSet<Client> clients { get; set; }

        public DbSet<Stock> stocks { get; set; }

           
        public ASAPDBcontext(DbContextOptions options) : base(options)
        {
           
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ASAPDBcontext).Assembly);
            //Here to read  all the Configration which find in folder configration to make each model has own congfigration 
        }
    }
}
