using DotLiquid;

namespace Tyrannoport
{
    internal class Navs : Drop
    {
        public Navs(string title)
        {
            Title = title;
        }

        public string OverviewSlug { get; set; } = "";
        public string OutputSlug { get; set; } = "";
        public string Title { get; }
    }
}