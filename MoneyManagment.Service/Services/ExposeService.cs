using MoneyManagment.Domain.Configurations;
using MoneyManagment.Service.DTOs.Exposes;
using MoneyManagment.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagment.Service.Services
{
    public class ExposeService : IExposeService
    {
        public Task<ExposeResultDto> AddAsync(ExposeCreationDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ExposeResultDto> ModifyAsync(ExposeCreationDto dto)
        {
            throw new NotImplementedException();
        }

        public Task<ExposeResultDto> RetrieveAllAsync(PaginationParams @params, string search = null)
        {
            throw new NotImplementedException();
        }

        public Task<ExposeResultDto> RetrieveAllByUserIdAsync(PaginationParams @params, string search = null)
        {
            throw new NotImplementedException();
        }

        public Task<ExposeResultDto> RetrieveByIdAsync(long id)
        {
            throw new NotImplementedException();
        }
    }
}
