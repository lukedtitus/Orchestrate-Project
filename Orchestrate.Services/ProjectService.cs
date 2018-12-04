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
        private ApplicationDbContext db = new ApplicationDbContext();
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

        public string GetGenreDataById(int id)
        {
            int
                alternative = 0,
                blues = 0,
                comedy = 0,
                childMusic = 0,
                classical = 0,
                country = 0,
                electronic = 0,
                holiday = 0,
                opera = 0,
                singsong = 0,
                jazz = 0,
                latino = 0,
                newAge = 0,
                pop = 0,
                rnbSoul = 0,
                soundtrack = 0,
                dance = 0,
                hipHopRap = 0,
                world = 0,
                rock = 0,
                chrgos = 0,
                vocal = 0,
                reggae = 0,
                ealist = 0,
                jPop = 0,
                enka = 0,
                kayokyoku = 0,
                fitwork = 0,
                kPop = 0,
                karaoke = 0,
                instr = 0,
                braz = 0,
                spokword = 0;

            var projectList = GetProjectsById(id);

            foreach (Project project in projectList)
            {
                switch (project.Genre)
                {
                    case GenreEnum.Alternative:
                        alternative++;
                        break;
                    case GenreEnum.Blues:
                        blues++;
                        break;
                    case GenreEnum.Comedy:
                        comedy++;
                        break;
                    case GenreEnum.ChildrensMusic:
                        childMusic++;
                        break;
                    case GenreEnum.Classical:
                        classical++;
                        break;
                    case GenreEnum.Country:
                        country++;
                        break;
                    case GenreEnum.Electronic:
                        electronic++;
                        break;
                    case GenreEnum.Holiday:
                        holiday++;
                        break;
                    case GenreEnum.Opera:
                        opera++;
                        break;
                    case GenreEnum.SingerSongwriter:
                        singsong++;
                        break;
                    case GenreEnum.Jazz:
                        jazz++;
                        break;
                    case GenreEnum.Latino:
                        latino++;
                        break;
                    case GenreEnum.NewAge:
                        newAge++;
                        break;
                    case GenreEnum.Pop:
                        pop++;
                        break;
                    case GenreEnum.RnbSoul:
                        rnbSoul++;
                        break;
                    case GenreEnum.Soundtrack:
                        soundtrack++;
                        break;
                    case GenreEnum.Dance:
                        dance++;
                        break;
                    case GenreEnum.HipHopRap:
                        hipHopRap++;
                        break;
                    case GenreEnum.World:
                        world++;
                        break;
                    case GenreEnum.Rock:
                        rock++;
                        break;
                    case GenreEnum.ChristianGospel:
                        chrgos++;
                        break;
                    case GenreEnum.Vocal:
                        vocal++;
                        break;
                    case GenreEnum.Reggae:
                        reggae++;
                        break;
                    case GenreEnum.EasyListening:
                        ealist++;
                        break;
                    case GenreEnum.JPop:
                        jPop++;
                        break;
                    case GenreEnum.Enka:
                        enka++;
                        break;
                    case GenreEnum.Kayokyoku:
                        kayokyoku++;
                        break;
                    case GenreEnum.FitnessWorkout:
                        fitwork++;
                        break;
                    case GenreEnum.Kpop:
                        kPop++;
                        break;
                    case GenreEnum.Karaoke:
                        karaoke++;
                        break;
                    case GenreEnum.Instrumental:
                        instr++;
                        break;
                    case GenreEnum.Brazilian:
                        braz++;
                        break;
                    case GenreEnum.SpokenWord:
                        spokword++;
                        break;
                }
            }

            return ($"{alternative},{blues},{comedy},{childMusic}, {classical}, {country}, {electronic}, {holiday}, {opera}, {singsong}, {jazz}, {latino}, {newAge}, {pop}, {rnbSoul}, {soundtrack}, {dance}, {hipHopRap}, {world}, {rock}, {chrgos}, {vocal}, {reggae}, {ealist}, {jPop}, {enka}, {kayokyoku}, {fitwork}, {kPop}, {karaoke}, {instr}, {braz}, {spokword}, 0");
        }

        private List<Project> GetProjectsById(int id)
        {
            var projectList = db.Projects.Where(g => g.ProjectId == id).ToList();
            return projectList;
        }
    }
}
