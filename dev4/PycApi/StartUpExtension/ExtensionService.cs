using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PycApi.Mapper;
using PycApi.Service;
using StackExchange.Redis;
using System;

namespace PycApi.StartUpExtension
{
    public static class ExtensionService
    {
        public static void AddRedisDependencyInjection(this IServiceCollection services, IConfiguration Configuration)
        {
            //redis 
            var configurationOptions = new ConfigurationOptions();
            configurationOptions.EndPoints.Add(Configuration["Redis:Host"], Convert.ToInt32(Configuration["Redis:Port"]));
            int.TryParse(Configuration["Redis:DefaultDatabase"], out int defaultDatabase);
            configurationOptions.DefaultDatabase = defaultDatabase;
            services.AddStackExchangeRedisCache(options =>
            {
                options.ConfigurationOptions = configurationOptions;
                options.InstanceName = Configuration["Redis:InstanceName"];
            });
        }

        public static void AddServices(this IServiceCollection services)
        {
            // services 
            services.AddScoped<IAuthorService,AuthorService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ICardService, CardService>();
            services.AddScoped<IPersonService, PersonService>();


            // mapper
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            services.AddSingleton(mapperConfig.CreateMapper());
        }
    }
}
