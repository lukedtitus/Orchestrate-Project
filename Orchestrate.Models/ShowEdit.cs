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
        public string Artist { get; set; }
        [Display (Name = "City of Venue")]
        public string CityOfVenue { get; set; }
        public DateTime Date { get; set; }
        public double Cost { get; set; }
        public double Sales { get; set; }
    }
}
