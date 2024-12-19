using System;
using System.ComponentModel.DataAnnotations;

namespace TodoApp.Models.ViewModels;

public class RegisterViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
    
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Passwords is not similar")]
    public string ConfirmPassword { get; set; }

}
