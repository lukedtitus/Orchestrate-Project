using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchestrate.Models
{
    public class ShowDetail
    {
        public int ShowId { get; set; }
        public string Artist { get; set; }
        public string CityOfVenue { get; set; }
        public DateTime Date { get; set; }
        public double Cost { get; set; }
        public double Sales { get; set; }
        public override string ToString() => $"[{ShowId}] {Artist}";
    }
}
