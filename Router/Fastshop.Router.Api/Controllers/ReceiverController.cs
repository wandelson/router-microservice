using Fastshop.Roteador.Domain;
using Fastshop.Router.Api.Controllers;
using Fastshop.Router.Transactions.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Fastshop.Checkout.Api.Controllers
{
    [Route("api/[controller]")]
    public class ReceiverController : BaseController
    {
        private readonly TransactionService service;

        public ReceiverController(TransactionService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateTransactionAuthorize command)
        {
            var response = await service.Execute(command);
            return await Response(response);
        }
    }
}