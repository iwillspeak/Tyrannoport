using Cake.Core.Tooling;

namespace Cake.Tyrannoport
{
    /// <summary>Cake Settings for the Tyrannoport tool</summary>
    public class TyrannoportSettings : ToolSettings
    {
        /// <summary>Gets or sets the output directory to render to.</summary>
        public string? OutputBase { get; set; }
    }
}