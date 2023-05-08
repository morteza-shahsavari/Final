using Shopping.DomainModel.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.DomainModel.Configurations
{
    public class SectionConfigurations : IEntityTypeConfiguration<Section>
    {
        public void Configure(EntityTypeBuilder<Section> builder)
        {
            builder.HasKey(x => x.ID);
            builder.HasMany(x => x.AdvertisementInSections).WithOne(x => x.Section).HasForeignKey(x => x.SectionId);
        }
    }
}
