using System.Threading.Tasks;

namespace Tyrannoport
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // TODO: parse the arguments properly here
            var trxFiles = args;

            await new Tyrannoport(trxFiles)
                .RenderAsync();
        }
    }
}
