using Sigga.Avaliacao.Facade.Factory;
using Sigga.Avaliacao.Model.Entity;
using System.Web.Mvc;

namespace Sigga.Avaliacao.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var facade = FacadeFactory.Item())
            {
                var response = facade.Create(new Item { Id = 1, UserId = 1, Title = "Teste", Completed = true });
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