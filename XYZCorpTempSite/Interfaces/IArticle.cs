namespace XYZCorpTempSite.Interfaces
{
    public interface IArticle
    {
        string Header { get; set; }
        string Content { get; set; }
        bool IsFeatured { get; set; }
    }
}