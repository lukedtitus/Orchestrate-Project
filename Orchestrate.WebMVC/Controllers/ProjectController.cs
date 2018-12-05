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
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            var service = CreateProjectService();
            var model = service.GetProjects();
            ViewBag.GenreData = service.GetGenreData();
            return View(model);

            //return View(service.GetProjectById(id));
        }

        //public ActionResult Index(int id)
        //{
        //    var service = CreateProjectService();

        //    ViewBag.GenreData = service.GetGenreDataById(id);
        //    return View(service.GetProjectById(id));
        //}

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProjectCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateProjectService();

            if (service.CreateProject(model))
            {
                TempData["SaveResult"] = "Project was added";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Project could not be added");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateProjectService();
            var model = svc.GetProjectById(id);

            return View(model);
        }

        public ActionResult GenreChart(int id)
        {
            var svc = CreateProjectService();
            var service = CreateProjectService();

            ViewBag.GenreData = service.GetGenreData();
            return View(service.GetProjectById(id));
        }

        public ActionResult Edit(int id)
        {
            var svc = CreateProjectService();
            var detail = svc.GetProjectById(id);
            var model =
                new ProjectEdit
                {
                    ProjectId = detail.ProjectId,
                    Name = detail.Name,
                    Artist = detail.Artist,
                    Genre = detail.Genre,
                    ReleaseYear = detail.ReleaseYear,
                    Cost = detail.Cost,
                    Sales = detail.Sales
                };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit (int id, ProjectEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ProjectId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateProjectService();

            if (service.UpdateProject(model))
            {
                TempData["SaveResult"] = "Project information was updated.";
                return RedirectToAction("Index");
            }
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateProjectService();
            var model = svc.GetProjectById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProject(int id)
        {
            var service = CreateProjectService();
            service.DeleteProject(id);
            TempData["SaveResult"] = "Project was removed.";
            return RedirectToAction("Index");
        }

        private ProjectService CreateProjectService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProjectService(userId);
            return service;
        }
    }
}