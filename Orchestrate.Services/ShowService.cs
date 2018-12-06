using Orchestrate.Data;
using Orchestrate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchestrate.Services
{
    public class ShowService
    {
        private readonly Guid _userId;

        public ShowService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateShow(ShowCreate model)
        {
            var entity =
                new Show()
                {
                    OwnerId = _userId,
                    ArtistId = model.ArtistId,
                    Title = model.Title,
                    CityOfVenue = model.CityOfVenue,
                    Date = model.Date,
                    Cost = model.Cost,
                    Sales = model.Sales
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Shows.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ShowListItem> GetShows()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                ctx
                    .Shows
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                            new ShowListItem
                            {
                                ShowId = e.ShowId,
                                Artist = e.Artist,
                                Title = e.Title,
                                Date = e.Date
                            }
                    );
                return query.ToArray();
            }
        }

        public ShowDetail GetShowById(int showId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Shows
                        .Single(e => e.ShowId == showId && e.OwnerId == _userId);
                return
                    new ShowDetail
                    {
                        ShowId = entity.ShowId,
                        Artist = entity.Artist,
                        Title = entity.Title,
                        CityOfVenue = entity.CityOfVenue,
                        Date = entity.Date,
                        Cost = entity.Cost,
                        Sales = entity.Sales
                    };
            }
        }

        public bool UpdateShow(ShowEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Shows
                        .Single(e => e.ShowId == model.ShowId && e.OwnerId == _userId);

                entity.ArtistId = model.ArtistId;
                entity.Title = model.Title;
                entity.CityOfVenue = model.CityOfVenue;
                entity.Date = model.Date;
                entity.Cost = model.Cost;
                entity.Sales = model.Sales;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteShow(int showId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Shows
                        .Single(e => e.ShowId == showId && e.OwnerId == _userId);

                ctx.Shows.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public List<Artist> Artists()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Artists.ToList();
            }
        }
    }
}
