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
            var service = CreateShowService();
            var model = service.GetShows();
            return View(model);
        }

        public ActionResult Create()
        {
            var svc = CreateShowService();
            var userId = Guid.Parse(User.Identity.GetUserId());
            var artistList = new SelectList(svc.Artists(), "ArtistId", "ArtistName");
            ViewBag.ArtistId = artistList;
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
            ViewBag.ArtistId = new SelectList(service.Artists(), "ArtistId", "ArtistName", model.ArtistId);

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateShowService();
            var model = svc.GetShowById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateShowService();
            var detail = service.GetShowById(id);
            var model =
                new ShowEdit
                {
                    ShowId = detail.ShowId,
                    Artist = detail.Artist,
                    CityOfVenue = detail.CityOfVenue,
                    Date = detail.Date,
                    Cost = detail.Cost,
                    Sales = detail.Sales
                };

            var artistList = new SelectList(service.Artists(), "ArtistId", "ArtistName", detail.ArtistId);
            ViewBag.ArtistId = artistList;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (int id, ShowEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ShowId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateShowService();

            if (service.UpdateShow(model))
            {
                TempData["SaveResult"] = "The show was updated";
                return RedirectToAction("Index");
            }
            var artistList = new SelectList(service.Artists(), "ArtistId", "ArtistName", model.Artist.ArtistId);
            ViewBag.ArtistId = artistList;
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateShowService();
            var model = svc.GetShowById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteShow(int id)
        {
            var service = CreateShowService();
            service.DeleteShow(id);
            TempData["SaveResult"] = "Show was deleted";
            return RedirectToAction("Index");
        }

        private ShowService CreateShowService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ShowService(userId);
            return service;
        }
    }
}