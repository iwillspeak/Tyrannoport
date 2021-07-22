using System.IO;

namespace Tyrannoport
{
    /// <summary>An output provider that is scoped to a specific base path</summary>
    public sealed class ScopedOutputProvider : IOutputStreamProvider
    {
        private readonly IOutputStreamProvider _inner;
        private readonly string _basePath;

        /// <summary>Initialise a new scoped output provider with the given base</summary>
        /// <param name="inner">The inner output provider to forward to</param>
        /// <param name="basePath">The base path to use for this provider</param>
        public ScopedOutputProvider(IOutputStreamProvider inner, string basePath)
        {
            _inner = inner;
            _basePath = basePath;
        }

        /// <inheritdoc />
        public Stream OpenPath(string path)
        {
            return _inner.OpenPath(Path.Combine(_basePath, path));
        }
    }
}