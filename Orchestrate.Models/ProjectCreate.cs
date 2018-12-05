using Orchestrate.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchestrate.Models
{
    public class ProjectCreate
    {
        [Required]
        public string Name { get; set; }
        [Display (Name = "Select Artist")]
        public int ArtistId { get; set; }
        public GenreEnum Genre { get; set; }
        [Display (Name = "Year of Release")]
        public int ReleaseYear { get; set; }
        public double Cost { get; set; }
        public double Sales { get; set; }
        public Artist Artist { get; set; }

        public override string ToString() => Name;
    }
}
