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
   public class KeyWordConfigurations:IEntityTypeConfiguration<KeyWord>
    {
        public void Configure(EntityTypeBuilder<KeyWord> builder)
        {
            builder.HasKey(x => x.KeyWordID);
            builder.HasMany(x => x.ProductKeyWords)
                .WithOne(x => x.KeyWord)
                .HasForeignKey(x => x.KeywordID)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Property(x => x.KeyWordText).HasMaxLength(100);
                
        }
    }
}
