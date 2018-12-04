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
                                Artist = e.Artist,
                            }
                    );
                return query.ToArray();
            }
        }

        public ProjectDetail GetProjectById(int ProjectId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Projects
                        .Single(e => e.ProjectId == ProjectId && e.OwnerId == _userId);
                return
                    new ProjectDetail
                    {
                        ProjectId = entity.ProjectId,
                        Name = entity.Name,
                        Artist = entity.Artist,
                        Genre = entity.Genre,
                        ReleaseYear = entity.ReleaseYear,
                        Cost = entity.Cost,
                        Sales = entity.Sales
                    };
            }
        }

        public bool UpdateProject(ProjectEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Projects
                        .Single(e => e.ProjectId == model.ProjectId && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.Artist = model.Artist;
                entity.Genre = model.Genre;
                entity.ReleaseYear = model.ReleaseYear;
                entity.Cost = model.Cost;
                entity.Sales = model.Sales;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteProject(int projectId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Projects
                        .Single(e => e.ProjectId == projectId && e.OwnerId == _userId);

                ctx.Projects.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
