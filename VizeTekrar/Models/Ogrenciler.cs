using System.ComponentModel.DataAnnotations;
namespace VizeTekrar.Models
{
    public class Ogrenciler
    {
        public int? Id { get; set; }
        public string Ad { get; set; } = string.Empty;
        public string? Soyad { get; set; }
        public long OgrenciNo { get; set; } = 0;
        public string Cinsiyet { get; set; } = string.Empty;
        public DateTime DogumTarihi { get; set; }
        [Required(ErrorMessage = "Eposta alanı zorunludur.")]//data annatoinlardır required boş geçilemez ... 
        public string Eposta { get; set; } = string.Empty;
        public string Telefon { get; set; } = string.Empty;


        public string? FotografYolu { get; set; } = string.Empty;
        public int? BolumlerId { get; set; }

        public virtual Bolumler Bolum { get; set; } = null!;    
        }

}
