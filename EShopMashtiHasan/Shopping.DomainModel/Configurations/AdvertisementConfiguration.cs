using Shopping.DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shopping.DomainModel.Configurations
{
    public class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisement>
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            builder.HasKey(x => x.ID);
            builder.HasMany(x => x.AdvertisementInSections).WithOne(x => x.Advertisement).HasForeignKey(x => x.AdvertisementId);
        }
    }
}
