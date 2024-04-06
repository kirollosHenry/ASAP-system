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
    public class ClientConfigration : IEntityTypeConfiguration<Client>
    {
    
          public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(C => C.ClientId);
            builder.Property(C => C.FirstName).HasColumnType("nvarchar(20)").IsRequired();
            builder.Property(P => P.LastName).HasColumnType("nvarchar(20)");
            builder.Property(P => P.PhoneNumber).HasColumnType("nvarchar(20)").IsRequired();
            builder.Property(P => P.Email).HasColumnType("nvarchar(30)").IsRequired();
        }
    }
}
