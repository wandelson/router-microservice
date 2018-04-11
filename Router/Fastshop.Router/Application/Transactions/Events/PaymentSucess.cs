using System;

namespace Fastshop.Router.Application.Transactions.Events
{
    public class PaymentSuccess : IEvent
    {
        public DateTime Data { get; private set; }
        public string Code { get; private set; }
        public string Message { get; private set; }

        public PaymentSuccess(string codigo)
        {
            Data = DateTime.Now;
            Code = codigo;
            Message = "AUTHORIZED";
        }
    }
}