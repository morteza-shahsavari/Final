using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shopping.DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shopping.DomainModel.Configurations
{
   public class OrderConfigurations:IEntityTypeConfiguration<Orders>
    {
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.HasKey(x => x.OrderID);
            builder.HasMany(x => x.OrderDetails)
                .WithOne(x => x.Orders)
                .HasForeignKey(x => x.OrderID)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Property(x => x.OrderDescription).HasMaxLength(400);
            builder.Property(x => x.Mobile).HasMaxLength(30);
            builder.Property(x => x.Address).HasMaxLength(500);
            //builder.HasOne(x => x.User)
            //    .WithMany(x => x.Orders)
            //    .HasForeignKey(x => x.UserID).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
