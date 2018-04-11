namespace Fastshop.Router.Domain
{
    public class Gateway
    {
        public Gateway()
        {
            Billing = new Billing();
            Payment = new Payment();
        }

        public Billing Billing { get; set; }
        public Payment Payment { get; set; }
    }
}