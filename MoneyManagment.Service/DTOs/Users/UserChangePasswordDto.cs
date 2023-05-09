
using System.ComponentModel.DataAnnotations;

namespace MoneyManagment.Service.DTOs.Users;

public class UserChangePasswordDto
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string OldPassword { get; set; }

    [Required]
    public string NewPassword { get; set; }

    [Required]
    public string ConfirmPassword { get; set;}

}
