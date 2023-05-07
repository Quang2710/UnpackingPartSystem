using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tmss.Master.Module.Dto;

namespace tmss.Master.Module
{
    public interface IModuleAppService: IApplicationService
    {
        Task<PagedResultDto<ModuleDto>> GetAll(GetModuleInput input);

        Task CreateOrEdit(CreateOrEditModuleDto input);

        Task Delete(EntityDto<long> input);
    }
}
