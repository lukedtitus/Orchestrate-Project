using Microsoft.AspNet.Identity;
using Orchestrate.Data;
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
    public class ArtistController : Controller
    {
        // GET: Artist
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ArtistService(userId);
            var model = service.GetArtists();
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArtistCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateArtistService();

            if (service.CreateArtist(model))
            {
                TempData["SaveResult"] = "Artist was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Artist could not be created");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateArtistService();
            var model = svc.GetArtistById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateArtistService();
            var detail = service.GetArtistById(id);
            var model =
                new ArtistEdit
                {
                    ArtistId = detail.ArtistId,
                    ArtistName = detail.ArtistName,
                    NumberOfMembers = detail.NumberOfMembers,
                    Genre = detail.Genre
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (int id, ArtistEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ArtistId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateArtistService();

            if (service.UpdateArtist(model))
            {
                TempData["SaveResult"] = "Your note was updated.";
                return RedirectToAction("Index");
            }
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateArtistService();
            var model = svc.GetArtistById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteArtist(int id)
        {
            var service = CreateArtistService();
            service.DeleteArtist(id);
            TempData["SaveResult"] = "Your note was deleted.";
            return RedirectToAction("Index");
        }

        private ArtistService CreateArtistService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ArtistService(userId);
            return service;
        }
    }
}