using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Lycoris.Assets
{
    public class Asset : FullAuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        private string _attachUrl;

        public string AttachUrl
        {
            get => _attachUrl;
            set
            {
                _attachUrl = value;
            }
        }
    }
}
