using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchestrate.Models
{
    public class ProjectListItem
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }

        public override string ToString() => Name;
    }
}
