using System;
using Tyranoport.Trx;
using Tyranoport.Trx.Models;
using DotLiquid;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Tyranoport
{
    class Program
    {
        static async Task Main(string[] args)
        {
            foreach (var path in args)
            {
                var loaded = TrxReader.LoadPath(path);
                await RenderAsync(loaded, Path.ChangeExtension(path, "html"));
            }
        }

        private static async Task RenderAsync(TestRun report, string outputPath)
        {
            using var templateStream = new StreamReader(typeof(Program).Assembly.GetManifestResourceStream("Tyranoport.templates.index.liquid")!);
            var template = Template.Parse(await templateStream.ReadToEndAsync());
            using var output = File.OpenWrite(outputPath);

            template.Render(output, new RenderParameters(CultureInfo.InvariantCulture)
            {
                LocalVariables = Hash.FromAnonymousObject(report),
            });
        }
    }
}
