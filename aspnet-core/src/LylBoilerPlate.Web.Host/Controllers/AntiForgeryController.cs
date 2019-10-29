using Microsoft.AspNetCore.Antiforgery;
using LylBoilerPlate.Controllers;

namespace LylBoilerPlate.Web.Host.Controllers
{
    public class AntiForgeryController : LylBoilerPlateControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
