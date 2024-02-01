using CQRSDemo.Data.Entitie;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Data.Configuration
{
    public class CustomerModelConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("customer");
            builder.HasKey(x => x.CustomerID);

            builder
                .Property(x => x.CustomerID)
                .HasColumnName("customer_id")
                .HasColumnType("Bigint")
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder
               .Property(x => x.Name)
               .HasColumnName("name")
               .HasColumnType("varchar(50)")
               .IsRequired();

            builder
               .Property(x => x.Email)
               .HasColumnName("email")
               .HasColumnType("varchar(30)")
               .IsRequired();

            builder
               .Property(x => x.Phone)
               .HasColumnName("phone")
               .HasColumnType("varchar(15)")
               .IsRequired();




        }
    }
}
