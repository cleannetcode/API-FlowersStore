using AutoMapper;

namespace API_FlowersStore.DataAccess.MSSQL
{
    public class DataAccessMappingProfile : Profile
    {
        public DataAccessMappingProfile()
        {
            CreateMap<Entities.Product, Core.CoreModels.Product>().ReverseMap();
        }
    }
}
