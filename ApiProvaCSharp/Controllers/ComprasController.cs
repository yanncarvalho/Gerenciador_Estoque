using Microsoft.AspNetCore.Mvc;

namespace ApiProvaCSharp.Controllers
{
    [Route("api/compras")]
    [ApiController]
    public class ComprasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
