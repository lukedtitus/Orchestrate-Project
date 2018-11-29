using Orchestrate.Data;
using Orchestrate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchestrate.Services
{
    public class ArtistService
    {
        private readonly Guid _userId;

        public ArtistService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateArtist(ArtistCreate model)
        {
            var entity =
                new Artist()
                {
                    OwnerId = _userId,
                    ArtistName = model.ArtistName,
                    NumberOfMembers = model.NumberOfMembers,
                    Genre = model.Genre,
                    ProjectsReleased = model.ProjectsReleased
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Artists.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ArtistListItem> GetArtists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Artists
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ArtistListItem
                                {
                                    ArtistId = e.ArtistId,
                                    ArtistName = e.ArtistName
                                }
                        );
                return query.ToArray();
            }
        }

        public ArtistDetail GetArtistById(int artistId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Artists
                        .Single(e => e.ArtistId == artistId && e.OwnerId == _userId);
                return
                    new ArtistDetail
                    {
                        ArtistId = entity.ArtistId,
                        ArtistName = entity.ArtistName,
                        NumberOfMembers = entity.NumberOfMembers,
                        Genre = entity.Genre,
                        ProjectsReleased = entity.ProjectsReleased
                    };
            }
        }

        public bool UpdateArtist(ArtistEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Artists
                        .Single(e => e.ArtistId == model.ArtistId && e.OwnerId == _userId);

                entity.ArtistName = model.ArtistName;
                entity.NumberOfMembers = model.NumberOfMembers;
                entity.Genre = model.Genre;
                entity.ProjectsReleased = model.ProjectsReleased;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteArtist(int artistId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Artists
                        .Single(e => e.ArtistId == artistId && e.OwnerId == _userId);

                ctx.Artists.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
