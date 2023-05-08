using MoneyManagment.Domain.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagment.Domain.Entities
{
    public class Expose:Auditable
    {
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Description { get; set; }
        public string Amout { get; set; }
        public long? UserId { get; set; }
        public User User { get; set; }
    }
}
