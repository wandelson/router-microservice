using System;

namespace Fastshop.Router.Application.Transactions.Result
{
    public class Order
    {
        public string TID { get; set; }
        public DateTime DateTime { get; set; }
        public string TotalAmount { get; set; }
    }

    public class TransactionResponse
    {
        public string Message { get; set; }
        public Order Order { get; set; }
    }

    public class TransactionResult
    {
        public TransactionResponse TransactionResponse { get; set; }
    }
}