using Cake.Core.Tooling;

namespace Cake.Tyrannoport
{
    /// <summary>Cake Settings for the Tyrannoport tool</summary>
    public class TyrannoportSettings : ToolSettings
    {
        /// <summary>Gets or sets the output directory to render to.</summary>
        public string? OutputBase { get; set; }

        /// <summary>
        ///  Gets or sets a value indicating whether skipped tests should be
        ///  excluded from the total pass rate calculation.
        /// </summary>
        public bool ExcludeSkippedFromTotalPassRate { get; set; }
    }
}