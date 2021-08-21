using System.Linq;
using System.Threading.Tasks;
using DocoptNet;

namespace Tyrannoport
{
    class Program
    {
        private const string Usage = @"Tyrannoport

    Usage:
        tyrannoport [options] <trx>...
        tyrannoport --version
        tyrannoport --help


    Options:
        --version   Print the version and exit.
        --help      Show this help text.
";

        static async Task Main(string[] args)
        {
            var options = new Docopt()
                .Apply(Usage, args, exit: true, version: Version.VersionString);

            await new Tyrannoport(options["<trx>"].AsList.Cast<object>().Select(c => c.ToString()!))
                .RenderAsync();
        }
    }
}
