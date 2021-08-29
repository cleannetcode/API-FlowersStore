using API_FlowersStore.API.Contracts;
using AutoMapper;

namespace API_FlowersStore.API
{
    public class APIMappingProfile : Profile
    {
        public APIMappingProfile()
        {
            CreateMap<Contracts.NewProduct, Core.CoreModels.Product>();
            CreateMap<Contracts.NewOrder, Core.CoreModels.Order>();

            CreateMap<Contracts.User, Core.CoreModels.User>().ReverseMap();
        }
    }
}