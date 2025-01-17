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
    }
    
}