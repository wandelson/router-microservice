using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Fastshop.Router.Api.Controllers
{
    public class BaseController : Controller
    {
        public async Task<IActionResult> Response(object result)
        {
            try
            {
                return Ok(result);
            }
            catch
            {
                return BadRequest(new
                {
                    message = new[] { "Ocorreu uma falha interna no servidor." }
                });
            }
        }
    }
}