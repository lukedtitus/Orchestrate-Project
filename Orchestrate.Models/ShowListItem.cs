using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchestrate.Models
{
    public class ShowListItem
    {
        [Display (Name = "ID Number")]
        public int ShowId { get; set; }
        public string Artist { get; set; }
        public DateTime Date { get; set; }

        public override string ToString() => Artist;
    }
}
