using Fastshop.Router.Application;
using Fastshop.Router.Transactions.Commands;

namespace Fastshop.Router
{
    public abstract class GatewayFactory
    {
        public abstract IGateway Execute(CreateTransactionAuthorize Transaction);
    }
}