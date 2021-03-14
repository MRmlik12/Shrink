using Microsoft.AspNetCore.Components.Forms;
using MongoDB.Driver;
using Shrink.Interfaces;
using Shrink.Models;

namespace Shrink.Services
{
    public class MongoService : IMongoService
    {
        private IMongoCollection<Short> MongoCollection { get; set; }

        public MongoService(IShrinkConfiguration configuration)
        {
            var client = new MongoClient(configuration.ConnectionString);
            var database = client.GetDatabase(configuration.DatabaseName);

            MongoCollection = database.GetCollection<Short>(configuration.CollectionName);
        }

        public async void Create(Short shortUrl)
        {
            await MongoCollection.InsertOneAsync(shortUrl);
        }

        public Short GetByUrl(string url) => 
            MongoCollection.Find(shortUrl => shortUrl.Url == url).FirstOrDefault();

        public Short GetByCode(string code) => 
            MongoCollection.Find(shortUrl => shortUrl.Code == code).FirstOrDefault();
    }
}