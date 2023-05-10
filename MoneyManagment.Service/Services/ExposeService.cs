using AutoMapper;
using MoneyManagment.DAL.IRepository;
using MoneyManagment.Domain.Configurations;
using MoneyManagment.Domain.Entities;
using MoneyManagment.Service.DTOs.Exposes;
using MoneyManagment.Service.Exceptions;
using MoneyManagment.Service.Extensions;
using MoneyManagment.Service.Interfaces;
using MoneyManagment.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManagment.Service.Services
{
    public class ExposeService : IExposeService
    {
        private readonly IRepository<Expose> exposeRepository;
        private readonly IMapper mapper;

        public ExposeService(IRepository<Expose> exposeRepository, IMapper mapper)
        {
            this.exposeRepository = exposeRepository;
            this.mapper = mapper;
        }

        public async Task<ExposeResultDto> AddAsync(ExposeCreationDto dto)
        {
            var mappedExpose = this.mapper.Map<Expose>(dto);
            mappedExpose.UserId = HttpContextHelper.UserId;
            mappedExpose.CreatedAt = DateTime.UtcNow;
            var addedExpose = await this.exposeRepository.InsertAsync(mappedExpose);

            await this.exposeRepository.SaveAsync();

            return this.mapper.Map<ExposeResultDto>(addedExpose);
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var expose = await this.exposeRepository.SelectAsync(e => e.Id == id);
            if (expose == null)
                throw new MoneyManagmentException(404, "Not found!");

            expose.DeletedBy = HttpContextHelper.UserId;

            await this.exposeRepository.SaveAsync();

            return true;
        }

        public async Task<ExposeResultDto> ModifyAsync(long id, ExposeCreationDto dto)
        {
            var expose = await this.exposeRepository.SelectAsync(e => e.Id == id);
            if (expose == null)
                throw new MoneyManagmentException(404, "Not found!");

            var modifiedExpose = this.mapper.Map(dto, expose);
            modifiedExpose.UpdatedAt = DateTime.UtcNow;

            await this.exposeRepository.SaveAsync();

            return this.mapper.Map<ExposeResultDto>(modifiedExpose);
        }


        public async Task<ExposeResultDto> RetrieveByIdAsync(long id)
        {
            var expose = await this.exposeRepository.SelectAsync(e => e.Id == id);
            if (expose == null)
                throw new MoneyManagmentException(404, "Not found!");

            return this.mapper.Map<ExposeResultDto>(expose);
        }

        public async Task<IEnumerable<ExposeResultDto>> RetrieveAllAsync(PaginationParams @params, string search)
        {
            var exposes = this.exposeRepository.SelectAll(u => !u.IsDeleted);

            var result = this.mapper.Map<IEnumerable<ExposeResultDto>>(exposes);

            if (!string.IsNullOrEmpty(search))
                return result.Where(
                    e => e.Name.ToLower().Contains(search.ToLower()) ||
                    e.Description.ToLower().Contains(search.ToLower()))
                    .ToPagedList(@params);

            return result.ToPagedList(@params);
        }

        public async  Task<IEnumerable<ExposeResultDto>> RetrieveAllByUserIdAsync(PaginationParams @params, string search)
        {
            var exposes = this.exposeRepository.SelectAll(u => !u.IsDeleted &&
            u.UserId == HttpContextHelper.UserId);

            var result = this.mapper.Map<IEnumerable<ExposeResultDto>>(exposes);

            if (!string.IsNullOrEmpty(search))
                return result.Where(
                    e => e.Name.ToLower().Contains(search.ToLower()) ||
                    e.Description.ToLower().Contains(search.ToLower()))
                    .ToPagedList(@params);

            return result.ToPagedList(@params);
        }
    }
}
