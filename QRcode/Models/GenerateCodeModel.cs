using System.ComponentModel.DataAnnotations;

namespace CodeGen.Models
{
    public class GenerateCodeModel
    {
        [Required]
        [Display(Name = "Enter Text")]
        public string Input { get; set; }
    }
}
