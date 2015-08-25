using System.Collections.Generic;
using XYZCorpTempSite.Interfaces;

namespace XYZCorpTempSite.Models
{
    public class HomePage : IHomePage
    {
        public IArticle FeaturedArticle { get; set; }
        public IEnumerable<IArticle> Articles { get; set; }
        public ILogo XyzCorpLogo { get; set; }
    }
}