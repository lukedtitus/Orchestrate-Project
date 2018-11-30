using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchestrate.Data
{
    public class Show
    {
        [Key]
        public int ShowId { get; set; }

        [Required]
        public Guid OwnerId { get; set; }

        [Required]
        public string Artist { get; set; }

        [Required]
        public string CityOfVenue { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public double Cost { get; set; }

        [Required]
        public double Sales { get; set; }
    }
}
