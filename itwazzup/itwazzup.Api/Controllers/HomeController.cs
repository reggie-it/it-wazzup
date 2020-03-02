using Microsoft.AspNetCore.Mvc;

namespace itwazzup.Api.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class HomeController : Controller
    {
        public RedirectResult Index()
        {
            return this.Redirect("/swagger");
        }
    }
}