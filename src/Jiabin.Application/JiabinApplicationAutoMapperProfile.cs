using AutoMapper;
using Jiabin.Assets;
using Jiabin.Assets.Dtos;

namespace Jiabin
{
    public class JiabinApplicationAutoMapperProfile : Profile
    {
        public JiabinApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Asset, AssetDto>();
            CreateMap<CreateUpdateAssetDto, Asset>(MemberList.Source);
        }
    }
}
