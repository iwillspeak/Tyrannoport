using System.IO;

namespace Tyrannoport
{
    /// <summary>
    ///   Ouput Provider
    ///   <para>
    ///     Seam to abstract away the file system from the rendering process.
    ///   </para>
    /// </summary>    
    public interface IOutputStreamProvider
    {
        /// <summary>Open a path for writing</summary>
        /// <param name="path">The path to open</param>
        Stream OpenPath(string path);
    }
}