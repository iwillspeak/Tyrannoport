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
            // TODO: parse the arguments properly here
            var trxFiles = args;

            await new Tyranoport(trxFiles)
                .RenderAsync();
        }
    }
}
