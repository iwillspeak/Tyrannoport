using System.IO;

namespace Tyrannoport
{
    /// <summary>An output provider that writes to the file system</summary>
    internal sealed class FileSystemOutputProvider : IOutputStreamProvider
    {
        /// <inheritdoc />
        public Stream OpenPath(string path)
        {
            var fs = File.OpenWrite(path);
            fs.SetLength(0);
            return fs;
        }
    }
}