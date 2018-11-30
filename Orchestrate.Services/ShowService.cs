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
                    Artist = model.Artist,
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
                                Date = e.Date
                            }
                    );
                return query.ToArray();
            }
        }
    }
}
