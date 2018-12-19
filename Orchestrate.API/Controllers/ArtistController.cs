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
    public class ArtistController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            ArtistService artistService = CreateArtistService();
            var artists = artistService.GetArtists();
            return Ok(artists);
        }

        public IHttpActionResult Get(int id)
        {
            ArtistService artistService = CreateArtistService();
            var artist = artistService.GetArtistById(id);
            return Ok(artist);
        }

        public IHttpActionResult Post(ArtistCreate artist)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateArtistService();

            if (!service.CreateArtist(artist))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Put(ArtistEdit artist)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateArtistService();

            if (!service.UpdateArtist(artist))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateArtistService();

            if (!service.DeleteArtist(id))
                return InternalServerError();
            return Ok();
        }

        private ArtistService CreateArtistService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var artistService = new ArtistService(userId);
            return artistService;
        }
    }
}
