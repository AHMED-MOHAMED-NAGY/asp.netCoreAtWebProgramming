using System.ComponentModel.DataAnnotations;

namespace H5B1.Models
{
    public class Ogrenci
    {
        [Display(Name = "Ogrenci Adi")]
        [Required(ErrorMessage = "Adi alani bos gecilemez")]
        [MinLength(2,ErrorMessage ="ad min 2 olabilir")]
        public string OgrAd { get; set; }


        [Display (Name = "Ogrenci Soyadi")]
        [MaxLength(50,ErrorMessage ="max 50 olmasi lazim")]
        public string OgrSoyad { get; set; }


        [Required(ErrorMessage = "Ogrenci No bos gecilemez")]
        [Display (Name ="Ogrenci No")]
        public string OgrNo { get; set; }


        [Display (Name ="Ogrenci Yas")]
        [Range(18,25,ErrorMessage ="18 25 arasi olmasi lazim")]
        public int OgrYas { get; set; }
    }
}
