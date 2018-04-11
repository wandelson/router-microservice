using Fastshop.Router.Application;
using Fastshop.Router.Transactions.Commands;

namespace Fastshop.Router
{
    public interface IConcreteGateway
    {
        IGateway Execute(CreateTransactionAuthorize Transaction);
    }
}