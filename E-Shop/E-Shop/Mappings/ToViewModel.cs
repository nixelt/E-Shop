namespace E_Shop.Mappings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using ViewModels;
    using ViewModels.CategoryViewModels;
    using ViewModels.ReviewViewModels;
    using ViewModels.SettingsViewModels;

    using Model;

    using ViewModels.OrderViewModels;
    using ViewModels.ProductViewModels;

    public class ToViewModel : Profile
    {
        public ToViewModel()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Category, IndexCategoryViewModel>();
            CreateMap<Order, OrderViewModel>().ForMember(
                m => m.OrderStatus,
                opt => opt.MapFrom(src => src.OrderStatus.Name));
            CreateMap<Order, DetailsOrderViewModel>().ForMember(
                m => m.OrderStatus,
                opt => opt.MapFrom(src => src.OrderStatus.Name)).ForMember(
                m => m.OrderDetails,
                opt => opt.MapFrom(
                    src => src.OrderDetails.Select(Mapper.Map<OrderDetails, OrderDetailsViewModel>)));
            CreateMap<OrderDetails, OrderDetailsViewModel>().ForMember(
                m => m.Name, opt => opt.MapFrom(src => src.Product.Name)).ForMember(
                m => m.QuantityInCart, opt => opt.MapFrom(src => src.Quantity));
            CreateMap<Product, ProductViewModel>().ForMember(
                 m => m.Image,
                 opt => opt.MapFrom(src => src.Images.FirstOrDefault().Image)).ForMember(
                 m => m.InStock, opt => opt.MapFrom(src => src.Quantity > 0));
            CreateMap<Product, DetailsProductViewModel>().ForMember(
                 m => m.CategoryName,
                 opt => opt.MapFrom(src => src.Category.Name)).ForMember(
                 m => m.Images,
                 opt => opt.MapFrom(src => src.Images.Select(x => x.Image))).ForMember(
                 m => m.Characteristics,
                 opt => opt.MapFrom(src => src.AttributeValues
                     .Select(x => new KeyValuePair<string, string>(x.Attribute.Name, x.Value)))).ForMember(
                    m => m.Rating,
                    opt => opt.MapFrom(src => Math.Round(src.Reviews.Count != 0 ? src.Reviews.Average(x => x.Rating) : 0)))
                .ForMember(m => m.ReviewCount, opt => opt.MapFrom(src => src.Reviews.Count)).ForMember(
                    m => m.NewReview,
                    opt => opt.MapFrom(x => new ReviewViewModel { ProductId = x.ProductId }));
            CreateMap<Product, IndexCartItemViewModel>().ForMember(
                  m => m.QuantityInStock,
                  opt => opt.MapFrom(src => src.Quantity)).ForMember(
                  m => m.Image, opt => opt.MapFrom(src => src.Images.FirstOrDefault().Image));
            CreateMap<Review, ReviewViewModel>().ForMember(
                m => m.FirstName,
                opt => opt.MapFrom(src => src.User.FirstName));
            CreateMap<User, CreateOrderViewModel>().ForMember(
                m => m.Phone, opt => opt.MapFrom(src => src.PhoneNumber));
            CreateMap<User, ContactInfoViewModel>().ForMember(
                m => m.Phone, opt => opt.MapFrom(src => src.PhoneNumber));
            CreateMap<User, SettingsViewModel>().ForMember(
                m => m.UserInfo,
                opt => opt.MapFrom(src => Mapper.Map<User, ContactInfoViewModel>(src)));
        }
    }
}