using AutoMapper;
using online_retail.Models.ViewModels;
using online_retail.Repositories.Entities;

namespace online_retail.Services
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<Order, OrderModel>().ReverseMap();
        }
    }
}
