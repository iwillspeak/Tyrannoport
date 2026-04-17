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
                ?? throw new DocoptInputErrorException("Failed to parse command line arguments. Please check the usage and try again.");
            var trxOption = options["<trx>"] ?? throw new DocoptInputErrorException("Missing required argument: <trx>. Please specify at least one TRX file path.");

            await new Tyrannoport(trxOption.AsList.Cast<object>().Select(c => c.ToString()!))
                .RenderAsync(new RenderOptions
                {
                    OutputBase = options["--output"]?.ToString(),
                    ExcludeSkippedFromTotalPassRate = options["--exclude-skipped-from-total-pass-rate"].IsTrue,
                });
        }
    }
}
