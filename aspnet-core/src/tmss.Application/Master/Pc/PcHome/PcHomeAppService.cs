using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


namespace tmss.Master.Pc
{
    public class PcHomeAppService : tmssAppServiceBase , IPcHomeAppService
    {
        private readonly IRepository<PcHome, long> _pchome;


        public PcHomeAppService(IRepository<PcHome, long> pchome

            )

        {
            _pchome = pchome;
        }




        public async Task<PagedResultDto<PcHomeDto>> GetAll(PcHomeInputDto input)
        {
            var querry = from PcStore in _pchome.GetAll().AsNoTracking()                       
                         select new PcHomeDto
                         {
                             Id = PcStore.Id,
                             PartNo = PcStore.PartNo,
                             PartName = PcStore.PartName,                         
                         };

            var totalCount = await querry.CountAsync();
            var paged = querry.PageBy(input);


            return new PagedResultDto<PcHomeDto>(
                totalCount,
                await paged.ToListAsync()
                );
        }

    }


}
