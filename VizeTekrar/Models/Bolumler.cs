namespace VizeTekrar.Models
{
    public class Bolumler
    {
        public int BolumlerId { get; set; }
        public string BolumAdi { get; set; } = string.Empty;

        public virtual ICollection<Ogrenciler> Ogrenciler { get; set; } = new List<Ogrenciler>();
    }
}
