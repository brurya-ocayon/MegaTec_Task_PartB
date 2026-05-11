using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MegaTec_Task.DTOs;

public class PersonCreateDto
{
    [Required(ErrorMessage = "Please enter a full name")]
    [Display(Name = "FULL NAME")] 
    [DefaultValue("Full Name")]
    [RegularExpression(@"^[a-zA-Zא-ת]+\s+[a-zA-Zא-ת\s]+$", ErrorMessage = "Please enter a full name (first name and last name)")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter a phone number")]
    [Display(Name = "PHONE NUMBER")]
    [DefaultValue("Phone Number")]
    [RegularExpression(@"^\d{9,10}$", ErrorMessage = "Phone number must contain 9 or 10 digits")]
    public string Phone { get; set; } = string.Empty;

   [Required(ErrorMessage = "Please enter an email address")]
   [Display(Name = "EMAIL ADDRESS")] 
[EmailAddress(ErrorMessage = "Email address is not valid")] 
[MaxLength(320)]
   public string Email { get; set; } = string.Empty;


    public IFormFile? ImageFile { get; set; }
}
