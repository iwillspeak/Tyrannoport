using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;

namespace Tyrannoport.Tests
{
    internal sealed class TestOutputProvider : IOutputStreamProvider
    {
        private readonly IDictionary<string, MemoryStream> _outputs =
            new Dictionary<string, MemoryStream>();

        public IReadOnlyDictionary<string, string> Outputs =>
            _outputs.ToDictionary(
                x => x.Key,
                x => Encoding.UTF8.GetString(x.Value.ToArray()));
        
        public Stream OpenPath(string path)
        {
            var ms = new MemoryStream();
            _outputs.Add(path, ms);
            return ms;
        }
    }
}