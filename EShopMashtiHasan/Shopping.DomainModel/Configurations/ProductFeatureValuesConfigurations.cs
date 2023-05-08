
using Shopping.DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shopping.DomainModel.Configurations
{
   public class ProductFeatureValuesConfigurations:IEntityTypeConfiguration<DomainModel.Models.ProductFeatureValue>
    {
        public void Configure(EntityTypeBuilder<ProductFeatureValue> builder)
        {
            builder.HasKey(x => x.ProductFeatureValueID);
            builder.Property(x => x.FeatureValue).HasMaxLength(200);
        }
    }
}
