using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchestrate.Models
{
    public class ArtistListItem
    {
        [Display (Name = "ID Number")]
        public int ArtistId { get; set; }
        [Display (Name = "Name")]
        public string ArtistName { get; set; }
        [Display (Name = "Projects")]
        public string Projects { get; set; }

        public override string ToString() => ArtistName;
    }
}
