using Newtonsoft.Json;
using Sigga.Avaliacao.Facade.Factory;
using Sigga.Avaliacao.Model.Condition;
using Sigga.Avaliacao.Model.Entity;
using Sigga.Avaliacao.Common;
using System.Net;
using System.Web.Mvc;

namespace Sigga.Avaliacao.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {            
            using (WebClient webclient = new WebClient())
            using (var facade = FacadeFactory.Item())
            {
                if (Global.IsDatabaseCreated && !Global.IsSeeked)
                {
                    var json = webclient.DownloadString("https://jsonplaceholder.typicode.com/todos");
                    Item[] itens = JsonConvert.DeserializeObject<Item[]>(json);

               
                    var response = facade.CreateCollection(itens);
                    if (response.Success)
                    {
                        var responsecollection = facade.RetrieveCollection(new ModelCondition<Item>());
                        return View(responsecollection);
                    }
                }
                
                var responsecollect = facade.RetrieveCollection(new ModelCondition<Item>());
                return View(responsecollect);
            }
        }

        [HttpPost]
        public ActionResult Consulta(int id)
        {
            using (var facade = FacadeFactory.Item())
            {
                var response = facade.Retrieve(id);                
                return PartialView("_Consulta", response);
            }
        }

        public ActionResult About()
        {

            using (var facade = FacadeFactory.Item())
            {
                var response = facade.RetrieveCollection(new ItemCondition { Completed = false, UserId = 1 });
                return View(response);
            }



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