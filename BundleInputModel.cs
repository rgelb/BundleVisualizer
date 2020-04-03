using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundleVisualizer
{
    public class BundleInput
    {
        public string FullFilePath { get; set; }
        public long FileSize { get; set; }
        public double PercentOfTotal { get; set; }
    }
}
