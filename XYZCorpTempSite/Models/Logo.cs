using XYZCorpTempSite.Interfaces;

namespace XYZCorpTempSite.Models
{
    public class Logo : ILogo
    {
        public int LogoId { get; set; }
        public string Src { get; set; }
        public string Alt { get; set; }
        public string Class { get; set; }
        public bool IsCurrent { get; set; }
    }
}