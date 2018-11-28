using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchestrate.Models
{
    public class ArtistCreate
    {
        [Required]
        public string ArtistName { get; set; }
        public int NumberOfMembers { get; set; }
        public string Genre { get; set; }
        public int ProjectsReleased { get; set; }

        public override string ToString() => ArtistName;
    }
}
