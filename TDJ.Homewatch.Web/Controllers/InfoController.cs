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
        public async Task<ActionResult> Index()
        {
            new LogEvent("entered InfoController Index").Raise();
            return View();
        }
    }
}
