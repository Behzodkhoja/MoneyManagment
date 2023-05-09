using System.ComponentModel.DataAnnotations;

namespace MoneyManagment.Service.DTOs.Users;

public class UserUpdateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [EmailAddress]
    public string Email { get; set; }
    public string Password { get; set; }
    [Phone]
    public string Phone { get; set; }
}
