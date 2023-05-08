using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagment.Service.DTOs.Users
{
    public class UserCreationDto
    {
        [Required(ErrorMessage = "Required")]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Required")]
        [Phone]
        public string Phone { get; set; }
    }
}
