using Fastshop.Router.Application.Transactions.Events;
using Fastshop.Router.Transactions.Commands;
using System.Threading.Tasks;

namespace Fastshop.Router.Application
{
    public interface IGateway
    {
        Task<IEvent> Execute(CreateTransactionAuthorize Transaction);
    }
}