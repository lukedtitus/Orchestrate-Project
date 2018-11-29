using Orchestrate.Data;
using Orchestrate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchestrate.Services
{
    public class ProjectService
    {
        private readonly Guid _userId;

        public ProjectService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateProject(ProjectCreate model)
        {
            var entity =
                new Project()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    Artist = model.Artist,
                    Genre = model.Genre,
                    ReleaseYear = model.ReleaseYear,
                    Cost = model.Cost,
                    Sales = model.Sales
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Projects.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ProjectListItem> GetProjects()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Projects
                    .Where(e => e.OwnerId == _userId)
                    .Select(
                        e =>
                            new ProjectListItem
                            {
                                ProjectId = e.ProjectId,
                                Name = e.Name,
                                Artist = e.Artist
                            }
                    );
                return query.ToArray();
            }
        }
    }
}
