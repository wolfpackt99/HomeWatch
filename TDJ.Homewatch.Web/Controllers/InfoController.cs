using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TDJ.HomeWatch.Business;

namespace TDJ.Homewatch.Web.Controllers
{
    public class InfoController : Controller
    {
        //
        // GET: /Info/
        [Inject]
        public INetQ Que { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task Index(QRequest item) {

            if (ModelState.IsValid)
            {
                await Que.Publish(item);
            }
        }

    }
}
