using AutoMapper;
using Order.ApplicationCore.Entities;
using Order.ApplicationCore.Model.RequestModel;
using Order.ApplicationCore.Model.ResponseModel;

namespace Order.ApplicationCore.Helper.Mapping;

public class ApplicationMapper:Profile
{
    public ApplicationMapper()
    {
        CreateMap<Orders, OrderRequestModel>().ReverseMap();
        CreateMap<Orders, OrderResponseModel>().ReverseMap();
        CreateMap<OrderDetails, OrderDetailsResponseModel>().ReverseMap();
        CreateMap<OrderDetails, OrderDetailsRequestModel>().ReverseMap();
        // CreateMap<Orders, OrderResponseModel>()
        //     .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails));
        //
        // CreateMap<OrderDetails, OrderDetailsResponseModel>();
        //
        // CreateMap<OrderRequestModel, Orders>()
        //     .ForMember(dest => dest.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails));
        //
        // CreateMap<OrderDetailsRequestModel, OrderDetails>();
        
    }
    
}