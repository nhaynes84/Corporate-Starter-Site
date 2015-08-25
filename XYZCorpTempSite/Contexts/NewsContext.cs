using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using XYZCorpTempSite.Interfaces;
using XYZCorpTempSite.Models;

namespace XYZCorpTempSite.Contexts
{
    public class NewsContext : DbContext
    {
        public DbSet<NewsArticle> NewsArticles { get; set; }
        public DbSet<Logo> Logos { get; set; }
    }
}