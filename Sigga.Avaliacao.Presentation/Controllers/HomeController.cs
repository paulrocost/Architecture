using Sigga.Avaliacao.Facade.Factory;
using System.Web.Mvc;

namespace Sigga.Avaliacao.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var facade = FacadeFactory.Item())
            {
                
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}