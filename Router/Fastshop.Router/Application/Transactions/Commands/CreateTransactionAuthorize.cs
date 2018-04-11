using Fastshop.Router.Domain;
using FluentValidation;

namespace Fastshop.Router.Transactions.Commands
{
    public class TransactionAuthorize
    {
        public Gateway Gateway { get; set; }
        public Verification Verification { get; set; }
    }

    public class CreateTransactionAuthorize
    {
        public TransactionAuthorize TransactionAuthorize { get; set; }
    }

    public class CreateTransactionAuthorizeValidator : AbstractValidator<CreateTransactionAuthorize>
    {
        public CreateTransactionAuthorizeValidator()
        {
            RuleFor(x => x.TransactionAuthorize.Gateway.Billing.Name).NotEmpty();
            RuleFor(x => x.TransactionAuthorize.Gateway.Billing.Email).EmailAddress();
            RuleFor(x => x.TransactionAuthorize.Gateway.Billing.Address).NotEmpty();
            RuleFor(x => x.TransactionAuthorize.Gateway.Payment.Acquirer).NotEmpty();
            RuleFor(x => x.TransactionAuthorize.Gateway.Payment.CardNumber).NotEmpty();
            RuleFor(x => x.TransactionAuthorize.Gateway.Payment.CardSecurityCode).NotEmpty();
            RuleFor(x => x.TransactionAuthorize.Gateway.Payment.CardExpirationDate).NotEmpty();
            RuleFor(x => x.TransactionAuthorize.Gateway.Payment.NumberOfPayments).NotEmpty();
            RuleFor(x => x.TransactionAuthorize.Gateway.Payment.Amount).NotEmpty();
        }
    }
}