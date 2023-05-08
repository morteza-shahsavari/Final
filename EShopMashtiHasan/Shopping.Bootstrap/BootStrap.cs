using DataAccessServiceContract.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using shopping.Buessiness.Impelements;
using Shopping.BusinessServiceContract.Services;
using Shopping.DataAccess.Repositories;
using Shopping.DomainModel.Models;
using Shopping.DomainModel.Repositories;

namespace Shopping.Bootstrap
{
    public static class BootStrap
    {
        public static void WireUP(IServiceCollection services,string ConnectionString)
        {
            services.AddDbContext<EshopMashtiHasanContext>(optionsAction =>
            {
                optionsAction.UseSqlServer(ConnectionString);
            }, ServiceLifetime.Scoped);
            services.AddScoped<ISupplierRepository,SupplierRepository>();
            services.AddScoped<ISupplierBuss,SupplierBus>();
            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<ICatBuss,CategoryBuss>();
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<IProductBuss,ProductBuss>();
            services.AddScoped<IAdvertiseInSectionRepository, AdvertisementInSectionRepository>();
            services.AddScoped<IAdvertisementInSectionBuss, AdvertisementInSectionBuss>();
            services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
            services.AddScoped<IAdvertisementBuss, AdvertisementBuss>();
            services.AddScoped<ISectionBuss, SectionBuss>();
            services.AddScoped<ISectionRepository, SectionRepository>();
            services.AddScoped<IFeatureRepository, FeatureRepository>();
            services.AddScoped<IFeatureBuss, FeatureBuss>();
            services.AddScoped<IKeyWordsRepository, KeyWordRepository>();
            services.AddScoped<IKeyWordBuss, KeyWordBuss>();
            services.AddScoped<IOrderRepository,OrderRepository>();
            services.AddScoped<IOrderBuss,OrderBuss>();

 
        }
       
    }
}



