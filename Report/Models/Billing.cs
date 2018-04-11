using System.ComponentModel;

namespace Fastshop.Report.Web.Models
{
    public class Billing
    {
        [DisplayName("Endereco")]
        public string Address { get; set; }

        [DisplayName("Complemento")]
        public string Address2 { get; set; }

        [DisplayName("Cidade")]
        public string City { get; set; }

        [DisplayName("Pais")]
        public string Country { get; set; }

        [DisplayName("Identificador")]
        public string CustomerIdentity { get; set; }

        [DisplayName("E-mail")]
        public string Email { get; set; }

        [DisplayName("Cliente")]
        public string Name { get; set; }

        [DisplayName("Telefone")]
        public string Phone { get; set; }

        [DisplayName("cep")]
        public string PostalCode { get; set; }

        [DisplayName("UF")]
        public string State { get; set; }
    }
}