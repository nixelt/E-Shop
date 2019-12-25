namespace E_Shop.Mappings
{
    using System;
    using System.Linq;

    using AutoMapper;

    using E_Shop.Areas.Admin.ViewModels.AttributeValueViewModels;
    using E_Shop.Areas.Admin.ViewModels.AttributeViewModels;
    using E_Shop.Areas.Admin.ViewModels.CategoryViewModels;
    using E_Shop.Areas.Admin.ViewModels.LogViewModels;
    using E_Shop.Areas.Admin.ViewModels.OrderViewModels;
    using E_Shop.Areas.Admin.ViewModels.ProductImageViewModels;
    using E_Shop.Areas.Admin.ViewModels.ProductViewModels;
    using E_Shop.Areas.Admin.ViewModels.SupplierViewModels;
    using E_Shop.Areas.Admin.ViewModels.SupplyViewModels;
    using E_Shop.Areas.Admin.ViewModels.UserViewModels;
    using ViewModels.PagerViewModel;

    using Model;

    using Attribute = Model.Attribute;
    using CategoryViewModel = Areas.Admin.ViewModels.CategoryViewModels.CategoryViewModel;
    using DetailsCategoryViewModel = Areas.Admin.ViewModels.CategoryViewModels.DetailsCategoryViewModel;
    using DetailsOrderViewModel = Areas.Admin.ViewModels.OrderViewModels.DetailsOrderViewModel;

    public class AdminToViewModel : Profile
    {
        public AdminToViewModel()
        {
            CreateMap<Attribute, AttributeViewModel>();
            CreateMap<AttributeValue, AttributeValueViewModel>().ForMember(
                m => m.AttributeName,
                opt => opt.MapFrom(src => src.Attribute.Name));
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Category, DetailsCategoryViewModel>().ForMember(
                m => m.Attributes,
                opt => opt.MapFrom(src => src.Attributes.Select(Mapper.Map<Attribute, AttributeViewModel>)));
            CreateMap<Category, EditCategoryViewModel>();
            CreateMap<Log, LogViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<Product, EditProductViewModel>();
            CreateMap<ProductImage, ProductImageViewModel>();
            CreateMap<Order, OrderViewModel>().ForMember(
                m => m.FullName,
                opt => opt.MapFrom(src => $"{src.LastName} {src.FirstName[0]}.{src.MiddleName[0]}."));
            CreateMap<Order, DetailsOrderViewModel>()
                .ForMember(
                    m => m.FullName,
                    opt => opt.MapFrom(src => $"{src.LastName} {src.FirstName} {src.MiddleName}")).ForMember(
                    m => m.Manager,
                    opt => opt.MapFrom(
                        src => $"{src.Manager.LastName} {src.Manager.FirstName[0]}.{src.Manager.MiddleName[0]}."))
                .ForMember(
                    m => m.OrderedProducts,
                    opt => opt.MapFrom(
                        src => src.OrderDetails.Select(Mapper.Map<OrderDetails, OrderedProductViewModel>).ToList()));
            CreateMap<OrderDetails, OrderedProductViewModel>().ForMember(
                m => m.QuantityInCart,
                opt => opt.MapFrom(src => src.Quantity)).ForMember(
                m => m.QuantityInStock,
                opt => opt.MapFrom(src => src.Product.Quantity)).ForMember(
                m => m.Name,
                opt => opt.MapFrom(src => src.Product.Name));
            CreateMap<Supplier, SupplierViewModel>();
            CreateMap<Supply, SupplyViewModel>();
            CreateMap<Supply, DetailsSupplyViewModel>().ForMember(
                m => m.SupplyProductViewModels,
                opt => opt.MapFrom(
                    src => src.SupplyProducts.Select(Mapper.Map<SupplyProduct, SupplyProductViewModel>).ToList()));
            CreateMap<SupplyProduct, SupplyProductViewModel>().ForMember(
                m => m.Name,
                opt => opt.MapFrom(src => src.Product.Name));
            CreateMap<User, UserViewModel>().ForMember(
                    m => m.FullName,
                    opt => opt.MapFrom(src => $"{src.LastName} {src.FirstName} {src.MiddleName}")).ForMember(
                m => m.IsBlocked, opt => opt.MapFrom(src => src.LockoutEndDateUtc > DateTime.Now));
            CreateMap<User, DetailsUserViewModel>().ForMember(
                m => m.FullName,
                opt => opt.MapFrom(
                    src => $"{src.LastName} {src.FirstName} {src.MiddleName}")).ForMember(
                m => m.Orders,
                opt => opt.MapFrom(
                    src => new PagerViewModel<OrderViewModel>
                    {
                        Entities = src.Orders.Select(Mapper.Map<Order, OrderViewModel>).ToList()
                    }));
        }
    }
}