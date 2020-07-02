using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;

namespace Jiabin.Assets
{
    public class Asset : AuditedAggregateRoot<Guid>
    {
        public virtual string Name { get; set; }

        public virtual string Description { get; set; }

        [NotMapped]
        public string FileBytes { get; set; }

        public bool FileBytesHandled { get; set; } = false;
    }
}
