using MoneyManagment.Domain.Configurations;
using MoneyManagment.Service.DTOs.Exposes;

namespace MoneyManagment.Service.Interfaces;

public interface IExposeService
{
    Task<ExposeResultDto> AddAsync(ExposeCreationDto dto);
    Task<ExposeResultDto> ModifyAsync(ExposeCreationDto dto);
    Task<bool> DeleteAsync(long id);
    Task<ExposeResultDto> RetrieveByIdAsync(long id);
    Task<ExposeResultDto> RetrieveAllAsync(PaginationParams @params, string search = null);
    Task<ExposeResultDto> RetrieveAllByUserIdAsync(PaginationParams @params ,string search = null);
}
