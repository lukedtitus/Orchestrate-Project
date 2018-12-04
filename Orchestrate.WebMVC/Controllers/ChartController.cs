using Orchestrate.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Orchestrate.WebMVC.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        private ApplicationDbContext db = new ApplicationDbContext();
        
        public ActionResult Index()
        {
            return View();
        }

        //public JsonResult DoughnutChartData()
        //{

        //}
    }
}