namespace Fastshop.ExternalServices.Cielo.Input
{
    public class Customer
    {
        public string Name { get; set; }
    }

    public class CreditCard
    {
        public string CardNumber { get; set; }
        public string Holder { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        public string Brand { get; set; }
    }

    public class Payment
    {
        public Payment()
        {
            CreditCard = new CreditCard();
        }

        public string Type { get; set; }
        public int Amount { get; set; }
        public int Installments { get; set; }
        public string SoftDescriptor { get; set; }
        public CreditCard CreditCard { get; set; }
    }

    public class CreateTransactionInput
    {
        public CreateTransactionInput()
        {
            Customer = new Customer();
            Payment = new Payment();
        }

        public string MerchantOrderId { get; set; }
        public Customer Customer { get; set; }
        public Payment Payment { get; set; }
    }
}