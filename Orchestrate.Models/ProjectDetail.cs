using Orchestrate.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchestrate.Models
{
    public class ProjectDetail
    {
        [Display (Name="ID Number")]
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public int ArtistId { get; set; }
        public GenreEnum Genre { get; set; }

        [Display (Name="Year of Release")]
        public int ReleaseYear { get; set; }
        public string Cost { get; set; }
        public string Sales { get; set; }
        public override string ToString() => $"[{ProjectId}] {Name}";

        public Artist Artist { get; set; }
    }
}
