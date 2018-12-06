using Orchestrate.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchestrate.Models
{
    public class ShowCreate
    {
        [Required]
        public int ArtistId { get; set; }
        [Display(Name = "Title / Tour Name")]
        public string Title { get; set; }
        [Display (Name = "City of Venue")]
        public string CityOfVenue { get; set; }
        public DateTime Date { get; set; }
        public double Cost { get; set; }
        public double Sales { get; set; }
        public Artist Artist { get; set; }

        public override string ToString() => Title;
    }
}
