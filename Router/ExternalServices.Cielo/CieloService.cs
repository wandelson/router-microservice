using Fastshop.ExternalServices.Cielo.Input;
using Fastshop.Router.Application;
using Fastshop.Router.Application.Transactions.Events;
using Fastshop.Router.Transactions.Commands;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Fastshop.ExternalServices.Cielo
{
    public class CieloService : IGateway
    {
        public async Task<IEvent> Execute(CreateTransactionAuthorize order)
        {
            using (var client = new HttpClient())
            {
                //TODO: MOCK CIELO
                var input = new CreateTransactionInput();
                input.Customer.Name = order.TransactionAuthorize.Gateway.Billing.Name;
                input.MerchantOrderId = order.TransactionAuthorize.Verification.MerchantId;
                input.Payment.Amount = Convert.ToInt32(order.TransactionAuthorize.Gateway.Payment.Amount);
                input.Payment.CreditCard.CardNumber = order.TransactionAuthorize.Gateway.Payment.CardNumber;

                if (order.TransactionAuthorize.Gateway.Payment.Amount.Equals("99"))
                    return new PaymentDenied("99");

                string json = JsonConvert.SerializeObject(input);

                var requestData = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(String.Format("https://developercielo.github.io/manual/cielo-ecommerce#requisi%C3%A7%C3%A3o"), requestData);

                // CreateTransactionResult result = null;
                // if (response.IsSuccessStatusCode)
                // result = await response.Content.ReadAsAsync<CreateTransactionResult>();

                return new PaymentSuccess(Guid.NewGuid().ToString());
            }
        }
    }
}