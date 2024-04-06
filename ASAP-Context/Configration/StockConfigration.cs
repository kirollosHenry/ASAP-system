using ASAP_Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASAP_Context.Configration
{
    public class StockConfigration : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
          
                builder.HasKey(C => C.StockID);
                builder.Property(C => C.Name).HasColumnType("nvarchar").IsRequired();
    
           
        }
    }
}
