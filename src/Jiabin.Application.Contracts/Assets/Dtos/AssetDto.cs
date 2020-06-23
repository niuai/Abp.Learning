using System;
using Volo.Abp.Application.Dtos;

namespace Jiabin.Assets.Dtos
{
    public class AssetDto : AuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string FileBytes { get; set; }
    }
}
