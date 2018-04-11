using System;
using System.ComponentModel;

namespace Fastshop.Report.Web.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }

        [DisplayName("Data Criação")]
        public DateTime CreatedAt { get; set; }

        [DisplayName("TID")]
        public String TID { get; set; }

        [DisplayName("STATUS")]
        public String Message { get; set; }

        public Gateway Gateway { get; set; }
        public Verification Verification { get; set; }
    }
}