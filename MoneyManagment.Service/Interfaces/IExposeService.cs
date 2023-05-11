using MoneyManagment.Domain.Configurations;
using MoneyManagment.Service.DTOs.Exposes;

namespace MoneyManagment.Service.Interfaces;

public interface IExposeService
{
    Task<ExposeResultDto> AddAsync(ExposeCreationDto dto);
    Task<ExposeResultDto> ModifyAsync(int id,ExposeCreationDto dto);
    Task<bool> DeleteAsync(int id);
    Task<ExposeResultDto> RetrieveByIdAsync(int id);
    Task<IEnumerable<ExposeResultDto>> RetrieveAllAsync(PaginationParams @params, string search = null);
    Task<IEnumerable<ExposeResultDto>> RetrieveAllByUserIdAsync(PaginationParams @params ,string search = null);
}
