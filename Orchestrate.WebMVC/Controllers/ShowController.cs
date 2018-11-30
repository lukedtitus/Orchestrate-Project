using Microsoft.AspNet.Identity;
using Orchestrate.Models;
using Orchestrate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Orchestrate.WebMVC.Controllers
{
    [Authorize]
    public class ShowController : Controller
    {
        // GET: Show
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ShowService(userId);
            var model = service.GetShows();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShowCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateShowService();

            if (service.CreateShow(model))
            {
                TempData["SaveResult"] = "Show was added.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Show could not be added.");

            return View(model);
        }

        private ShowService CreateShowService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ShowService(userId);
            return service;
        }
    }
}