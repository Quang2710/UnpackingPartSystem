using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tmss.Master.DevaningContModule.Dto;

namespace tmss.Master.DevaningModule
{
    public interface IDevaningModuleAppService : IApplicationService
    {
        Task<PagedResultDto<DevaningContModuleDto>> GetAll(GetDevaningContModuleInput input);

        Task CreateOrEdit(CreateOrEditDevaningContModuleDto input);

        Task Delete(EntityDto<long> input);

        Task FinishDvnCont(int dvn_id);

       // Task<int?> GetDevaningPlan();
    }
}
