using Microsoft.AspNet.Identity;
using Orchestrate.Models;
using Orchestrate.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Orchestrate.API.Controllers
{
    [Authorize]
    public class ProjectController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            ProjectService projectService = CreateProjectService();
            var projects = projectService.GetProjects();
            return Ok(projects);
        }

        public IHttpActionResult Get(int id)
        {
            ProjectService projectService = CreateProjectService();
            var project = projectService.GetProjectById(id);
            return Ok(project);
        }

        public IHttpActionResult Post(ProjectCreate project)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateProjectService();

            if (!service.CreateProject(project))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Put(ProjectEdit project)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateProjectService();

            if (!service.UpdateProject(project))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateProjectService();
            if (!service.DeleteProject(id))
                return InternalServerError();
            return Ok();
        }

        private ProjectService CreateProjectService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var projectService = new ProjectService(userId);
            return projectService;
        }
    }
}
