using System;
using System.Threading.Tasks;
using Fastshop.ExternalServices.Stone;
using Fastshop.Router.Application;
using Fastshop.ExternalServices.Cielo;
using Fastshop.Router.Transactions.Commands;

namespace Fastshop.Router.Infra
{
    public class ConcreteGatewayFactory : IConcreteGateway
    {

        public IGateway Execute(CreateTransactionAuthorize order)
        {
            switch (order.TransactionAuthorize.Gateway.Payment.Acquirer.ToLower())
            {
                case "cielo":
                     return new CieloService();
                case "stone":
                    return new StoneService();
                default:
                    throw new ApplicationException(string.Format("Gateway '{0}' não pode ser criado", order.TransactionAuthorize.Gateway.Payment.Acquirer));
            }
        }




    }
}
