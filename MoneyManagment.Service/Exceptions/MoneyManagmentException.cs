using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagment.Service.Exceptions
{
    public class MoneyManagmentException : Exception
    {
        public int Code { get; set; }
        public MoneyManagmentException(int code = 500, string massage = "Something is wrong")
            : base(massage)
        {
            this.Code = code;
        }
    }
}
