using System.ComponentModel;

namespace Fastshop.Report.Web.Models
{
    public class Payment
    {
        [DisplayName("Adquirente")]
        public string Acquirer { get; set; }

        [DisplayName("Valor")]
        public string Amount { get; set; }

        [DisplayName("Data expiração")]
        public string CardExpirationDate { get; set; }

        [DisplayName("Nome impresso do cartão")]
        public string CardHolder { get; set; }

        [DisplayName("Número do cartão")]
        public string CardNumber { get; set; }

        public string CardSecurityCode { get; set; }

        [DisplayName("Parcelas")]
        public string NumberOfPayments { get; set; }
    }
}