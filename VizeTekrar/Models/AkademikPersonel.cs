using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace VizeTekrar.Models
{
    public class AkademikPersonel
    {
        [Key]
        [DisplayName("Personel Sicil NO:")]
        public string SicilId { get; set; }= string.Empty;
        [DisplayName("Personel Adı:")]
        [Required(ErrorMessage = "Personel Adı Boş Bırakılamaz")]
        [StringLength(10, ErrorMessage = "Max 10 karakter")]
        [DataType(DataType.Text)] 
        [RegularExpression("^[a-zA-ZğüşöçıİĞÜŞÖÇ ]+$", ErrorMessage = "Sadece harf girebilirsiniz.")] 
        public string Ad { get; set; }
        [Required(ErrorMessage = "Personel Soyadı Boş Bırakılamaz"), MinLength(1), MaxLength(50)]
        [Display(Name = " Personel Soyadı:")]
        [DataType(DataType.Text)]
        public string Soyad { get; set; }
        [Required(ErrorMessage = "Resim Seçiniz")]
        [DisplayName("Resim")]
        [DataType(DataType.ImageUrl)]
        public string ResimURL { get; set; }
        [StringLength(200, MinimumLength = 10, ErrorMessage = "{0} 10 karakterden az ve 200 karakterde fazla olamaz.")] //{0} otomatik olarak alanın adını alır.
        [EmailAddress(ErrorMessage = "Geçersiz E-mail Adresi")]
        public string mailadres { get; set; }
        [MinLength(10, ErrorMessage = "{0} 10 karakterden az olamaz."), MaxLength(50, ErrorMessage =
        "{0} 50 karakterden fazla olamaz.")]
        [Display(Name = "Özgeçmiş Bilgileri")]
        public string cv { get; set; }
        [Range(50000, 150000, ErrorMessage = "50.000 TL ile 150.000 TL arasında bir değer giriniz")]
        [Column(TypeName = "decimal(18,2)")]
        [DataType(DataType.Currency)]
        [RegularExpression("^[0-9]+$")]
        public Nullable<decimal> maas { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifreyi Giriniz")]
        [StringLength(10, ErrorMessage = "Max 10 karakter")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Şifre (Tekrar)")]
        [Required(ErrorMessage = "Şifreyi Giriniz")]
        [StringLength(10, ErrorMessage = "Max 10 karakter")]
        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Şifreler eşleşmiyor")]
        public string RePassword { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        [Display(Name = "Telefon")]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }
        [Display(Name = "Doğum Tarihi")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DTarihi { get; set; }
        [Display(Name = "Bölüm")]
        public int BolumId { get; set; }

    }
}
