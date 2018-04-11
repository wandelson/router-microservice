using System;

namespace Fastshop.Router.Application.Transactions.Events
{
    public class PaymentDenied : IEvent
    {
        public DateTime Date { get; private set; }
        public string Code { get; set; }
        public string Message { get; private set; }

        public PaymentDenied(string code)
        {
            Date = DateTime.Now;
            Code = code;
            Message = "NOT-AUTHORIZED";
        }
    }
}