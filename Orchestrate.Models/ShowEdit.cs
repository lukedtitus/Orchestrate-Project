using Orchestrate.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchestrate.Models
{
    public class ShowEdit
    {
        [Display (Name = "ID Number")]
        public int ShowId { get; set; }
        public int ArtistId { get; set; }
        [Display(Name = "Title / Tour Name")]
        public string Title { get; set; }
        [Display (Name = "City of Venue")]
        public string CityOfVenue { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public string Cost { get; set; }       
        public string Sales { get; set; }

        public Artist Artist { get; set; }
    }
}
