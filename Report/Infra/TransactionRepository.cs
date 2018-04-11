using Fastshop.Report.Web.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fastshop.Report.Web.Infra
{
    public class TransactionRepository
    {
        private readonly MongoClient mongoClient;
        private readonly IMongoDatabase database;

        public static string ConnectionString { get; set; }
        public static string Database { get; set; }

        public TransactionRepository()
        {
            mongoClient = new MongoClient(ConnectionString);
            database = mongoClient.GetDatabase(Database);
        }

        public IEnumerable<Transaction> GetAll()
        {
            var list = database.GetCollection<Transaction>("Transactions").Find(new MongoDB.Bson.BsonDocument()).ToEnumerable();

            return list;
        }

        public async Task<Transaction> GetByTID(Guid tid)
        {
            var filter = Builders<Transaction>.Filter.Eq("TID", tid);

            var model = await database.GetCollection<Transaction>("Transactions").FindAsync(filter);

            return model.FirstOrDefault();
        }
    }
}