using BundleVisualizer.Common;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace BundleVisualizer.Models {
    public class Bundle {

        #region Read Properties

        // properties that are read from the file
        [JsonProperty("outputFileName")]
        public string OutputFileName { get; set; }
        [JsonProperty("inputFiles")]
        public string[] InputFiles { get; set; }
        [JsonProperty("minify")]
        public Minify Minify { get; set; }
        [JsonProperty("sourceMap")]
        public bool SourceMap { get; set; }

        #endregion

        #region Calculated Properties

        // properties that are calculated after reading the file
        public List<BundleInput> BundleInputs { get; set; }

        public string BundleOutputPath { get; set; }

        public string MinifiedBundlePath {
            get {
                var fi = new FileInfo(this.BundleOutputPath);
                return fi.FullName.Replace(fi.Extension, $".min{fi.Extension}");
            }
        }

        public long TotalBundleSize {
            get {
                long totalSize = 0;

                foreach (var bundleInput in this.BundleInputs) {
                    totalSize += bundleInput.FileSize;
                }

                return totalSize;
            }
        }

        public long TotalMinifiedSize {
            get {
                var fi = new FileInfo(this.MinifiedBundlePath);
                if (!fi.Exists) return -1;

                return fi.Length;
            }
        }

        public double MinifiedSavings {
            get {
                long minifiedSize = this.TotalMinifiedSize;
                if (minifiedSize == -1) return -1;

                return Utilities.PercentOfTotal(minifiedSize, this.TotalBundleSize);
            }
        }

        #endregion

    }

    public class Minify {

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
        [JsonProperty("commentMode")]
        public string CommentMode { get; set; }
        [JsonProperty("preserveImportantComments")]
        public bool PreserveImportantComments { get; set; }

    }

    public class BundleInput {

        public string FullFilePath { get; set; }
        public long FileSize { get; set; }
        public double PercentOfTotal { get; set; }

    }
}
