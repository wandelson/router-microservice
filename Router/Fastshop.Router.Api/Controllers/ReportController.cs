using Fastshop.Roteador.Domain;
using Fastshop.Router.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Fastshop.Checkout.Api.Controllers
{
    [Route("api/[controller]")]
    public class ReportController : BaseController
    {
        private readonly TransactionService service;

        public ReportController(TransactionService service)
        {
            this.service = service;
        }

        [HttpGet("{tid}")]
        public async Task<IActionResult> GetByTID(Guid tid)
        {
            var model = await service.GetByTID(tid);

            return await Response(model);
        }
    }
}