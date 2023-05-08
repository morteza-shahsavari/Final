
using DataAccessServiceContract.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Security.Buessiness.Impelements;
using Security.BuessinessServiceContract.Services;
using Security.DataAcceServiesContract.Repositories;
using Security.DataAccess.Repositories;

namespace Security.Bootstrap
{
    public class SecurityBootstrap
    {
        public static void WireUp(IServiceCollection services,string SecurityConnectionString)
        {
            services.AddDbContext<Security.Domain.Models.SecurityContext>(optionsAction =>
            {
                optionsAction.UseSqlServer(SecurityConnectionString);
            }, ServiceLifetime.Scoped);
            services.AddScoped<Security.BuessinessServiceContract.Services.IUserBuss, Security.Buessiness.Impelements.UserBuss>();
            services.AddScoped<IRoleBuss, RoleBuss>();
            services.AddScoped<IRoleActionBuss, RoleActionBuss>();
            services.AddScoped<IProjectActionBuss, ProjectActionBuss>();
            services.AddScoped<IProjectControllerBuss, ProjectControllerBuss>();
            services.AddScoped<IProjectAreaBuss, ProjectAreaBuss>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleActionRepository, RoleActionRepository>();
            services.AddScoped<IProjectAreaRepository, ProjectAreaRepository>();
            services.AddScoped<IProjectControllerRepository, ProjectControllerRepository>();
            services.AddScoped<IProjectActionRepository, ProjectActionRepository>();
            services.AddScoped<IAcountRepository, AccountRepository>();
            services.AddScoped<IAccountApplication, AccountApplication>();
            services.AddScoped<IAuthHelper, AuthHelper>();
            services.AddScoped<Framework.Services.IPasswordHasher, Framework.PasswordHasher>();
        }
    }
}