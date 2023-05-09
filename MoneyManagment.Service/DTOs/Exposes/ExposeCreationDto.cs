using System.ComponentModel.DataAnnotations;

namespace MoneyManagment.Service.DTOs.Exposes;

public class ExposeCreationDto
{
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }

    [Required]
    public string Amount { get; set; }
}
