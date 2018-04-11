using Fastshop.Report.Web.Infra;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Fastshop.Report.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly TransactionRepository repository;

        public HomeController(TransactionRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult Index()
        {
            return View(repository.GetAll());
        }

        public async Task<ActionResult> Details(Guid id)
        {
            var model = await repository.GetByTID(id);

            return View(model);
        }
    }
}