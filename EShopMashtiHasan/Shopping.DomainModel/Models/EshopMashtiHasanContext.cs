
using Shopping.DomainModel.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Shopping.DomainModel.Models
{
   public class EshopMashtiHasanContext:DbContext
    {
        public EshopMashtiHasanContext(DbContextOptions<EshopMashtiHasanContext> options):base(options)
        {
            
        }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryFeature> CategoryFeatures { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<KeyWord> KeyWords { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductFeatureValue> ProductFeatureValues { get; set; }
        public DbSet<ProductKeyWord> ProductKeyWords { get; set; }
        public DbSet<RelatedProduct> RelatedProducts { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
      
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<AdvertisementInSection> AdvertisementInSections { get; set; }
        public DbSet<Section> Sections { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Category>(new CategoryConfigurations());
            modelBuilder.ApplyConfiguration<Feature>(new FeatureConfigurations());
            modelBuilder.ApplyConfiguration<KeyWord>(new KeyWordConfigurations());
            modelBuilder.ApplyConfiguration<Orders>(new OrderConfigurations());
            modelBuilder.ApplyConfiguration<Product>(new ProductConfigurations());
            modelBuilder.ApplyConfiguration<Advertisement>(new AdvertisementConfiguration());
            modelBuilder.ApplyConfiguration<AdvertisementInSection>(new AdvertisementInSectionConfigurations());
            modelBuilder.ApplyConfiguration<Section>(new SectionConfigurations());
            modelBuilder.ApplyConfiguration<ProductFeatureValue>(new ProductFeatureValuesConfigurations());
            modelBuilder.ApplyConfiguration<Supplier>(new SupplierConfigurations());
           // modelBuilder.Entity<Role>().HasMany(x => x.Users).WithOne(x => x.Role).HasForeignKey(x => x.RoleID);
            base.OnModelCreating(modelBuilder);
        }
    }
}
