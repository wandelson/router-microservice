using Fastshop.Router.Domain;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace Fastshop.Router.Infra.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly MongoContext mongoContext;

        public TransactionRepository(MongoContext mongoContext)
        {
            this.mongoContext = mongoContext;
        }

        public async Task<Transaction> GetByTID(Guid tid)
        {
            var filter = Builders<Transaction>.Filter.Eq("TID", tid);

            var model = await mongoContext.Transaction.FindAsync(filter);

            return await model.FirstOrDefaultAsync();
        }

        public void Save(Transaction order)
        {
            mongoContext.Transaction.InsertOne(order);
        }
    }
}