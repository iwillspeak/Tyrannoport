using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Tyrannoport.Trx.Models;

namespace Tyrannoport.Trx
{
    /// <summary>Trx Reader utilities</summary>
    public static class TrxReader
    {
        /// <summary>Load test results from a file path</summary>
        /// <param name="path">The path to the TRX file to load</param>
        /// <returns>The parsed <see cref="TestRun" /> object.</returns>
        public static TestRun LoadPath(string path)
        {
            using var file = File.OpenRead(path);
            return LoadStream(file);
        }

        /// <summary>Load test results from a stream</summary>
        /// <param name="stream">The stream containing the TRX data to load</param>
        /// <returns>The parsed <see cref="TestRun" /> object.</returns>
        public static TestRun LoadStream(Stream stream)
        {
            var serialiser = new XmlSerializer(typeof(TestRun));
            return (TestRun)serialiser.Deserialize(stream)!;
        }
    }
}