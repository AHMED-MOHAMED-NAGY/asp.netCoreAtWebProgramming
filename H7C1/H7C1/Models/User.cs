using System.ComponentModel.DataAnnotations;

namespace H7C1.Models
{
    public class User
    {
        [Required(ErrorMessage = "Kulanici adi zorunlu")]
        [MaxLength (30 ,ErrorMessage = "name Max 30")]
        [Display(Name = "Kulanici adi")]
        [MinLength(3 ,ErrorMessage =" name min 3")]
        public string usrName { get; set; }
        [Required(ErrorMessage = "Sifre zoronlu")]
        //[Compare("Password")]   /////// iki kere dogrulama 
        [Display(Name = "Sifre")]
        [MinLength(3, ErrorMessage = " sifre min 3")]
        public string usrPassword { get; set; }
        public string usrColor { get; set; }
    }
}
