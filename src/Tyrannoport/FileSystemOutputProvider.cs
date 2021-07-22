using System.IO;

namespace Tyrannoport
{
    /// <summary>An output provider that writes to the file system</summary>
    internal sealed class FileSystemOutputProvider : IOutputStreamProvider
    {
        /// <inheritdoc />
        public Stream OpenPath(string path)
        {
            EnsureDirectory(path);
            var fs = File.OpenWrite(path);
            fs.SetLength(0);
            return fs;
        }

        private static void EnsureDirectory(string path)
        {
            var directory = Path.GetDirectoryName(path);
            if (directory != null)
            {
                try
                {
                    Directory.CreateDirectory(directory);
                }
                catch
                {
                    // best efforts
                }
            }
        }
    }
}