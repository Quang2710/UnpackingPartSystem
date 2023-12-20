using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using tmss.Dto;
using tmss.Master.DevaningContModule.Dto;

namespace tmss.Master.Pc
{
    public interface IPcHomeAppService : IApplicationService
    {
        Task<List<PcHomeDto>> GetAll(PcHomeInputDto input);

        Task<FileDto> GetPcHomeToExcel(PcHomeInputDto input);
    }
}
