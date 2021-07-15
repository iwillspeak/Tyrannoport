using System;
using System.IO;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Xml2CSharp;

namespace Tryanoport
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                var serialiser = new XmlSerializer(typeof(TestRun));
                using var file = File.OpenRead(arg);
                var loaded = serialiser.Deserialize(file);
            }
        }
    }
}
