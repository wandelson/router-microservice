using System;

namespace Fastshop.Router.Domain
{
    public class Transaction : IEntity
    {
        public Guid Id { get; protected set; }

        public DateTime CreatedAt { get; set; }

        public String TID { get; set; }

        public String Message { get; set; }

        public Transaction()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
        }

        public Gateway Gateway { get; set; }
        public Verification Verification { get; set; }
    }
}