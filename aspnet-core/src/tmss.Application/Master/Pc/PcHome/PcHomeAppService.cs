using Abp.Application.Services.Dto;
using Abp.Dapper.Repositories;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tmss.Dto;
using tmss.Master.Pc;
using tmss.Master.Unpacking.Dto;
using tmss.Master.Unpacking.Exporting;

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
