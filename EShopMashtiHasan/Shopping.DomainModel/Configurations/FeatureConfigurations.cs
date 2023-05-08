
using Shopping.DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shopping.DomainModel.Configurations
{
   public class FeatureConfigurations:IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.HasKey(x => x.FeatureID);
            builder.HasMany(x => x.ProductFeatureValues)
                .WithOne(x => x.Feature)
                .HasForeignKey(x => x.FeatureID)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Property(x => x.FeatureName).HasMaxLength(100);

        }
    }
}
