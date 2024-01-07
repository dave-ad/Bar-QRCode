using System.ComponentModel.DataAnnotations;

namespace Bar_QR_Code_API.Models;

public class CodeModel
{
    [Required]
    [Display(Name = "Enter Text")]
    public string Input { get; set; }
}
