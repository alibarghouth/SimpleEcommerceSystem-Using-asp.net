using AutoMapper;
using DataBaseManegmentSystem.Dto;
using DataBaseManegmentSystem.Models;

namespace Add_Database_Model.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerDto,Customer>();
            CreateMap<CustomerDtoUpdate,Customer>();
            CreateMap<ProductDto, Product>()
                .ForMember(x => x.ProductImage,option => option.Ignore());
            CreateMap<OrderDto, Order>();
        }
    }
}
