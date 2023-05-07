using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tmss.Master.Unpacking.Dto;

namespace tmss.Master.Unpacking
{
    public interface IUnpackingAppService: IApplicationService
    {
        Task<PagedResultDto<UnpackingDto>> GetAll(GetUnpackingInput input);

        Task CreateOrEdit(CreateOrEditUnpackingDto input);

        Task Delete(EntityDto<long> input);
    }
}
