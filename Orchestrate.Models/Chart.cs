using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orchestrate.Models
{
    public class Chart
    {
        public string[] Labels { get; set; }
        public List<Datasets> datasets { get; set; }
    }
    public class Datasets
    {
        public int[] data { get; set; }
        public string label { get; set; }
        public string[] backgroundColor { get; set; }
        public string[] borderColor { get; set; }
        public string borderWidth { get; set; }
    }
}
