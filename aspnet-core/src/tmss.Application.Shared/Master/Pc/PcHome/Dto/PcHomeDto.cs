using Abp.Application.Services.Dto;
using Abp.Domain.Entities;

namespace tmss.Master.Pc
{ 
    public class PcHomeDto : Entity<long>
    {
        public string PartNo { get; set; }

        public string PartName { get; set; }
     
    }
    public class PcHomeInputDto 
    {
    
        public string PartNo { get; set; }

        public string PartName { get; set; }

    }
}
