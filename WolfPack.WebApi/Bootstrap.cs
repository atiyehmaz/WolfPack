using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using WolfPack.Application.Packs;
using WolfPack.Application.Wolves;
using WolfPack.Domian.Model.Packs;
using WolfPack.Domian.Model.Wolves;
using WolfPack.Infrastructure.MongoDbRepository.Packs;
using WolfPack.Infrastructure.MongoDbRepository.Wolves;

namespace WolfPack.WebApi
{
    public class Bootstrap
    {
        private readonly IServiceCollection _services;

        private readonly string _mongoDbConnectionString;

        public Bootstrap(IServiceCollection services, IConfiguration configuration)
        {
            _services = services;
            _mongoDbConnectionString = configuration.GetValue<string>("MongoDbConnectionString");
        }

        public void Run()
        {
            _services.AddSingleton<IMongoClient, MongoClient>(s => new MongoClient(_mongoDbConnectionString));

            AddWolf();
            AddPack();
        }

        private void AddWolf()
        {
            _services.AddScoped<IWolfFactory, WolfFactory>();

            _services.AddScoped<IWolfRepository, WolfRepository>(s =>
                new WolfRepository(s.GetRequiredService<IMongoClient>(), BuildWolfFactory(s)));

            _services.AddScoped<IWolfApplicationService, WolfApplicationService>();
            
            
        }
        private IWolfFactory BuildWolfFactory(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            return scope.ServiceProvider.GetRequiredService<IWolfFactory>();
        }
        
        private void AddPack()
        {
            _services.AddScoped<IPackFactory, PackFactory>();

            _services.AddScoped<IPackRepository, PackRepository>(s =>
                new PackRepository(s.GetRequiredService<IMongoClient>(), BuildPackFactory(s)));

            _services.AddScoped<IPackApplicationService, PackApplicationService>();
        }
        private IPackFactory BuildPackFactory(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            return scope.ServiceProvider.GetRequiredService<IPackFactory>();
        }

        
    }
}