using MoneyManagment.Domain.Commons;
using MoneyManagment.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagment.Domain.Entities
{
    public class User:Auditable
    {
        [MaxLength(50)]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        public string Email { get; set; }
        [MaxLength(8)]
        public string Password { get; set; }
        public string Phone { get; set; }
        public UserRole Role { get; set; }
    }
}
