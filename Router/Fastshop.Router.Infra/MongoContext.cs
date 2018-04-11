using Fastshop.Router.Domain;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Fastshop.Router.Infra
{
    public class MongoContext
    {
        private readonly MongoClient mongoClient;
        private readonly IMongoDatabase database;

        public MongoContext(IOptions<Settings> settings)
        {
            mongoClient = new MongoClient(settings.Value.ConnectionString);
            if (mongoClient != null)
                database = mongoClient.GetDatabase(settings.Value.Database);

            Map();
        }

        public void DatabaseReset(string databaseName)
        {
            mongoClient.DropDatabase(databaseName);
        }

        public IMongoCollection<Transaction> Transaction
        {
            get
            {
                return database.GetCollection<Transaction>("Transactions");
            }
        }

        private void Map()
        {
            BsonClassMap.RegisterClassMap<Transaction>(cm =>
            {
                cm.AutoMap();
                cm.MapIdProperty(c => c.Id);
            });
        }
    }
}