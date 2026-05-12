using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace MegaTec_Task.Models;

public class Person
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Please enter a first name")]
    [Display(Name = "FIRST NAME")]
    [DefaultValue("First Name")]
    [MaxLength(200)]
    [RegularExpression(@"^[a-zA-Zא-ת]+$", ErrorMessage = "First name may only contain letters (English or Hebrew)")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter a last name")]
    [Display(Name = "LAST NAME")]
    [DefaultValue("Last Name")]
    [MaxLength(200)]
    [RegularExpression(@"^[a-zA-Zא-ת]+(?:\s+[a-zA-Zא-ת]+)*$", ErrorMessage = "Please enter a valid last name (letters, optional spaces between words)")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter a phone number")]
    [Display(Name = "PHONE NUMBER")] 
    [RegularExpression(@"^\d{9,10}$", ErrorMessage = "Phone number must contain 9 or 10 digits")]
    [DefaultValue("Phone Number")]
    public string Phone { get; set; } = string.Empty;

   

   [Required(ErrorMessage = "Please enter an email address")]
   [Display(Name = "EMAIL ADDRESS")] 
[EmailAddress(ErrorMessage = "Email address is not valid")] 
[MaxLength(320)]
   public string Email { get; set; } = string.Empty;

    [DefaultValue(true)]
    public bool IsActive { get; set; } = true;

    [MaxLength(1024)]
    public string? ImagePath { get; set; }
}
