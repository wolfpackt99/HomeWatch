using EasyNetQ;
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
    public class InfoController : AsyncController
    {
        //
        // GET: /Info/
        [Inject]
        public INetQ Que { get; set; }

        public async Task<ActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task Index(QRequest item) 
        {
            if (ModelState.IsValid)
            {
                await Que.Publish(item);
            }
        }

    }
}
