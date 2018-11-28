using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchestrate.Data
{
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string ArtistName { get; set; }

        [Required]
        public int NumberOfMembers { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public int ProjectsReleased { get; set; }
    }
}
