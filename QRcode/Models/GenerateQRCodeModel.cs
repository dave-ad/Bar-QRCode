using System.ComponentModel.DataAnnotations;

namespace QRcode.Models
{
    public class GenerateQRCodeModel
    {
        [Required]
        [Display(Name = "Enter Text")]
        public string QRInput { get; set; }
    }
}
