using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;
using tmss.Dto;

namespace tmss.Master.Pc
{
    public interface IPcStoreAppService : IApplicationService
    {
        Task<List<PcStoreDto>> GetAll(PcStoreInputDto input);
        Task<FileDto> GetPcStoreToExcel(PcStoreInputDto input);

    }
}
