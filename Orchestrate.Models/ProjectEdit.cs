using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchestrate.Models
{
    public class ProjectEdit
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public GenreEnum Genre { get; set; }
        public int ReleaseYear { get; set; }
        public double Cost { get; set; }
        public double Sales { get; set; }
    }
}
