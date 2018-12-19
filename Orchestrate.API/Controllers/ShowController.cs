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
    public class ShowController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            ShowService showService = CreateShowService();
            var shows = showService.GetShows();
            return Ok(shows);
        }

        public IHttpActionResult Get(int id)
        {
            ShowService showService = CreateShowService();
            var show = showService.GetShowById(id);
            return Ok(show);
        }

        public IHttpActionResult Post(ShowCreate show)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateShowService();

            if (!service.CreateShow(show))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Put(ShowEdit show)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateShowService();

            if (!service.UpdateShow(show))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateShowService();

            if (!service.DeleteShow(id))
                return InternalServerError();
            return Ok();
        }

        private ShowService CreateShowService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var showService = new ShowService(userId);
            return showService;
        }
    }
}
