using Fastshop.ExternalServices.Stone.Input;
using Fastshop.Router.Application;
using Fastshop.Router.Application.Transactions.Events;
using Fastshop.Router.Transactions.Commands;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Fastshop.ExternalServices.Stone
{
    public class StoneService : IGateway
    {
        public async Task<IEvent> Execute(CreateTransactionAuthorize order)
        {
            using (var client = new HttpClient())
            {
                //TODO: MOCK CIELO
                var input = new CreateTransactionInput();

                if (order.TransactionAuthorize.Gateway.Payment.Amount.Equals("99"))
                    return new PaymentDenied("99");

                string json = JsonConvert.SerializeObject(input);

                var requestData = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(String.Format("http://gateway.stone.com.br"), requestData);

                // CreateTransactionResult result = null;
                // if (response.IsSuccessStatusCode)
                // result = await response.Content.ReadAsAsync<CreateTransactionResult>();

                if (order.TransactionAuthorize.Gateway.Payment.Amount.Equals("99"))
                    return new PaymentDenied("1");

                return new PaymentSuccess(Guid.NewGuid().ToString());
            }
        }
    }
}