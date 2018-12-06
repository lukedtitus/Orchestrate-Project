using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Orchestrate.Data;

namespace Orchestrate.Models
{
    public class ArtistEdit
    {
        [Display (Name = "ID Number")]
        public int ArtistId { get; set; }
        [Display (Name = "Name")]
        public string ArtistName { get; set; }
        [Display (Name = "Number of Members")]
        public int NumberOfMembers { get; set; }
        public GenreEnum Genre { get; set; }
    }
}
