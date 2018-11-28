﻿using Orchestrate.Data;
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
    }
}