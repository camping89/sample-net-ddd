using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleDDD.Application.Contracts
{
    public interface ICrudAppService<TEntityDto, in TGetInputDto, in TCreateOrUpdateDto> where TEntityDto : BaseEntityDto
    {
        Task<TEntityDto> AddAsync(TCreateOrUpdateDto entityDto);

        Task<TEntityDto> UpdateAsync(Guid id,TCreateOrUpdateDto entityDto);

        Task DeleteAsync(Guid id);

        Task<TEntityDto> GetAsync(Guid id);

        Task<List<TEntityDto>> GetListAsync(TGetInputDto inputDto);
    }
}