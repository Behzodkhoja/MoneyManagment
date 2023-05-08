using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagment.Service.DTOs.Exposes
{
    public class ExposeCreationDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [Required]
        public string Amount { get; set; }
    }
}
