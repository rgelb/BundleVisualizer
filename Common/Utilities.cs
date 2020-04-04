using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundleVisualizer.Common {
    public class Utilities {
        public static double PercentOfTotal(long fraction, long totalSize) {
            return ((double)fraction / totalSize) * 100;
        }

    }
}
