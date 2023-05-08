using Shopping.DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shopping.DomainModel.Configurations
{
    public  class ProductConfigurations:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x=>x.ProductID);
            builder.Property(x=>x.ProductName).HasMaxLength(100).IsRequired();
            builder.Property(x => x.UnitPrice).IsRequired();
            builder.HasMany(x => x.ProductFeatureValues).WithOne(x => x.Product).HasForeignKey(x => x.ProductID)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.OrderDetails).WithOne(x => x.Product).HasForeignKey(x => x.ProductID)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(x => x.ProductKeyWords)
               .WithOne(x => x.Product)
               .HasForeignKey(x => x.ProductID).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.ProductFeatureValues)
                .WithOne(x => x.Product).HasForeignKey(x => x.ProductID).OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.RelatedProducts)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductID).OnDelete(DeleteBehavior.Cascade);

            //builder.HasMany(x => x.RelatedProducts)
            //    .WithOne(x => x.RelatedTo)
            //    .HasForeignKey(x => x.RelatedToID).OnDelete(DeleteBehavior.NoAction);



        }
    }
}
