using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchestrate.Models
{
    public class ProjectListItem
    {
        [Display (Name = "ID Number")]
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }

        public override string ToString() => Name;
    }
}
