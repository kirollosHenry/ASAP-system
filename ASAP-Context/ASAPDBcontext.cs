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

        private readonly IHttpContextAccessor _httpContextAccessor;
        public ASAPDBcontext(DbContextOptions options, IHttpContextAccessor httpContextAccessor):base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ASAPDBcontext).Assembly);
        }
    }
}
