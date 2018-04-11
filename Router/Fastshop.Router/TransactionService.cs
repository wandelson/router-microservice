using Fastshop.Router;
using Fastshop.Router.Application.Transactions.Events;
using Fastshop.Router.Application.Transactions.Result;
using Fastshop.Router.Domain;
using Fastshop.Router.Transactions.Commands;
using System;
using System.Threading.Tasks;

namespace Fastshop.Roteador.Domain
{
    public class TransactionService
    {
        private readonly ITransactionRepository transactionRepository;

        private readonly IConcreteGateway gatewayFactory;

        public TransactionService(ITransactionRepository transactionRepository, IConcreteGateway gatewayFactory)
        {
            this.transactionRepository = transactionRepository;
            this.gatewayFactory = gatewayFactory;
        }

        public async Task<TransactionResult> Execute(CreateTransactionAuthorize command)
        {
            var result = new TransactionResult();

            var selectedGateway = gatewayFactory.Execute(command);

            var response = await selectedGateway.Execute(command);

            var transaction = new Transaction();

            transaction.Gateway = command.TransactionAuthorize.Gateway;
            transaction.Verification = command.TransactionAuthorize.Verification;

            if (response is PaymentSuccess)
            {
                var success = response as PaymentSuccess;
                transaction.Message = success.Message;
                transaction.TID = success.Code;
            }
            else
            {
                var denied = response as PaymentDenied;
                transaction.Message = denied.Message;
            }

            result.TransactionResponse = new TransactionResponse();
            result.TransactionResponse.Order = new Order();
            result.TransactionResponse.Message = transaction.Message;
            result.TransactionResponse.Order.TID = transaction.TID;
            result.TransactionResponse.Order.DateTime = transaction.CreatedAt;
            result.TransactionResponse.Order.TotalAmount = transaction.Gateway.Payment.Amount;

            transactionRepository.Save(transaction);

            return result;
        }

        public async Task<TransactionResult> GetByTID(Guid tid)
        {
            var order = await transactionRepository.GetByTID(tid);

            var orderResult = new TransactionResult();
            orderResult.TransactionResponse = new TransactionResponse();
            orderResult.TransactionResponse.Order = new Order();
            orderResult.TransactionResponse.Order.TID = order.TID;
            orderResult.TransactionResponse.Order.TotalAmount = order.Gateway.Payment.Amount;
            orderResult.TransactionResponse.Message = order.Message;
            orderResult.TransactionResponse.Order.DateTime = order.CreatedAt;

            return orderResult;
        }
    }
}