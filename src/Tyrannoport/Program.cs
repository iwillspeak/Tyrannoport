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
        -o OUT, --output=<OUT>                      Write the output to the given <OUT> location.
        --exclude-skipped-from-total-pass-rate      Exclude skipped tests from the pass rate calculation.
        --version                                   Print the version and exit.
        --help                                      Show this help text.
";

        static async Task Main(string[] args)
        {
            var options = new Docopt()
                .Apply(Usage, args, exit: true, version: Version.VersionString)
                ?? throw new DocoptInputErrorException("Unable to parse command line arguments");
            var trxOption = options["<trx>"] ?? throw new DocoptInputErrorException("<trx> is required");

            await new Tyrannoport(trxOption.AsList.Cast<object>().Select(c => c.ToString()!))
                .RenderAsync(new RenderOptions
                {
                    OutputBase = options["--output"]?.ToString(),
                    ExcludeSkippedFromTotalPassRate = options["--exclude-skipped-from-total-pass-rate"].IsTrue,
                });
        }
    }
}
