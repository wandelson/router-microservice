using System;
using System.Threading.Tasks;

namespace Fastshop.Router.Domain
{
    public interface ITransactionRepository
    {
        void Save(Transaction transaction);

        Task<Transaction> GetByTID(Guid tid);
    }
}