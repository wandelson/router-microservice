using System.Collections.Generic;

namespace Fastshop.ExternalServices.Stone.Input
{
    public class CreditCard
    {
        public string CreditCardBrand { get; set; }
        public string CreditCardNumber { get; set; }
        public int ExpMonth { get; set; }
        public int ExpYear { get; set; }
        public string HolderName { get; set; }
        public string SecurityCode { get; set; }
    }

    public class CreditCardTransactionCollection
    {
        public int AmountInCents { get; set; }
        public CreditCard CreditCard { get; set; }
        public int InstallmentCount { get; set; }
    }

    public class Order
    {
        public string OrderReference { get; set; }
    }

    public class CreateTransactionInput
    {
        public List<CreditCardTransactionCollection> CreditCardTransactionCollection { get; set; }
        public Order Order { get; set; }
    }
}