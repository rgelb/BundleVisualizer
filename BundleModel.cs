using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BundleVisualizer
{
    public class Bundle
    {
        // properties that read from the file
        [JsonProperty("outputFileName")]
        public string OutputFileName { get; set; }
        [JsonProperty("inputFiles")]
        public string[] InputFiles { get; set; }
        [JsonProperty("minify")]
        public Minify Minify { get; set; }
        [JsonProperty("sourceMap")]
        public bool SourceMap { get; set; }

        // properties that are calculated after reading the file
        public List<BundleInput> BundleInputs { get; set; }
        public long TotalBundleSize
        {
            get
            {
                long totalSize = 0;

                foreach (var bundleInput in this.BundleInputs)
                {
                    totalSize += bundleInput.FileSize;
                }

                return totalSize;
            }
        }
    }

    public class Minify
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
        [JsonProperty("commentMode")]
        public string CommentMode { get; set; }
        [JsonProperty("preserveImportantComments")]
        public bool PreserveImportantComments { get; set; }
    }

}
