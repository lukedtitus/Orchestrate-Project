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
        public string Artist { get; set; }
        public string Genre { get; set; }
        public int ReleaseYear { get; set; }
        public double Cost { get; set; }
        public double Sales { get; set; }

        public override string ToString() => Name;
    }
}
