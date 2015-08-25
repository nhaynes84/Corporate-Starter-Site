using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XYZCorpTempSite.Models;

namespace XYZCorpTempSite.Interfaces
{
    public interface IHomePage
    {
        IArticle FeaturedArticle { get; set; }
        IEnumerable<IArticle> Articles { get; set; }
        ILogo XyzCorpLogo { get; set; }
    }
}