using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchestrate.Data
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Name { get; set; }       
        public int ArtistId { get; set; }

        [Required]
        public GenreEnum Genre { get; set; }

        [Required]
        public int ReleaseYear { get; set; }

        [Required]
        public double Cost { get; set; }

        [Required]
        public double Sales { get; set; }

        public virtual Artist Artist { get; set; }
    }
}
