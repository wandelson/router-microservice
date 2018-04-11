namespace Fastshop.Router.Domain
{
    public class Payment
    {
        public string Acquirer { get; set; }
        public string Amount { get; set; }
        public string CardExpirationDate { get; set; }
        public string CardHolder { get; set; }
        public string CardNumber { get; set; }
        public string CardSecurityCode { get; set; }
        public string NumberOfPayments { get; set; }
    }
}