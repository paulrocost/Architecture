using Sigga.Avaliacao.Facade.Factory;
using Sigga.Avaliacao.Model.Entity;
using System.Net;
using System.Web.Mvc;

namespace Sigga.Avaliacao.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (WebClient webclient = new WebClient())
            {
                var json = webclient.DownloadString("https://jsonplaceholder.typicode.com/todos");
            }

            //Deserializar e fazer o parse para a entidade Item.

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