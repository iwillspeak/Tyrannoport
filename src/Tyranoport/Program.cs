using System;
using Tyranoport.Trx;

namespace Tryanoport
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var path in args)
            {
                var loaded = TrxReader.LoadPath(path);
            }
        }
    }
}
