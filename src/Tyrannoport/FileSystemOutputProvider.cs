using System.IO;

namespace Tyrannoport
{
    /// <summary>An output provider that writes to the file system</summary>
    internal sealed class FileSystemOutputProvider : IOutputStreamProvider
    {
        /// <inheritdoc />
        public Stream OpenPath(string path) =>
            File.Open(path, FileMode.OpenOrCreate | FileMode.Truncate);
    }
}