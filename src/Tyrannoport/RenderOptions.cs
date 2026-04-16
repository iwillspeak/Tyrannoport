namespace Tyrannoport
{
    /// <summary>
    /// Global configuration for a given render.
    /// </summary>
    public sealed class RenderOptions
    {
        /// <summary>
        ///  Initialise a new instance of the render options using the default
        ///  output file provider.
        /// </summary>
        public RenderOptions()
            : this(new FileSystemOutputProvider())
        {
        }

        /// <summary>
        ///  Initialise a new instance of the render options using the given
        ///  output file provider.
        /// </summary>
        public RenderOptions(IOutputStreamProvider streamProvider) =>
            StreamProvider = streamProvider;

        /// <summary>Gets the output provider for this render.</summary>
        public IOutputStreamProvider StreamProvider { get; }

        /// <summary>Gets or sets the base path for this render.</summary>
        public string? OutputBase { get; set; }

        /// <summary>
        ///  Gets or sets a value indicating whether skipped tests should be
        ///  excluded from the total pass rate calculation.
        /// </summary>
        public bool ExcludeSkippedFromTotalPassRate { get; set; }
    }
}