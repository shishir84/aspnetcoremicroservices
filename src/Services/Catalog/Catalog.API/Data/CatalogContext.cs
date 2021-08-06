using Catalog.API.Data;
using Catalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {            
            // var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
            // var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
            // Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));

            var client = new MongoClient("mongodb://10.0.2.15:27017/?readPreference=primary&appname=mongodb-vscode%200.6.10&ssl=false");
            var database = client.GetDatabase("ProductDb");
            Products = database.GetCollection<Product>("Products");

            CatalogContextSeed.SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; }
    }
}