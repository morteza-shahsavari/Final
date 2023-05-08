using Shopping.DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shopping.DomainModel.Configurations
{
    public class AdvertisementInSectionConfigurations : IEntityTypeConfiguration<AdvertisementInSection>
    {
        public void Configure(EntityTypeBuilder<AdvertisementInSection> builder)
        {
            builder.HasKey(x => x.ID);
        }
    }
}
