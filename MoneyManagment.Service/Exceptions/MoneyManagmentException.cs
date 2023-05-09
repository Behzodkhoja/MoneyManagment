namespace MoneyManagment.Service.Exceptions;


public class MoneyManagmentException : Exception
{
    public int Code { get; set; }
    public MoneyManagmentException(int code = 500, string massage = "Something is wrong")
        : base(massage)
    {
        this.Code = code;
    }
}
