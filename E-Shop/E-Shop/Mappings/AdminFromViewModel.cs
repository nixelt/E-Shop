namespace E_Shop.Mappings
{
    using System.Linq;

    using AutoMapper;

    using E_Shop.Areas.Admin.ViewModels.AttributeValueViewModels;
    using E_Shop.Areas.Admin.ViewModels.AttributeViewModels;
    using E_Shop.Areas.Admin.ViewModels.CategoryViewModels;
    using E_Shop.Areas.Admin.ViewModels.ProductViewModels;
    using E_Shop.Areas.Admin.ViewModels.SupplierViewModels;
    using E_Shop.Areas.Admin.ViewModels.SupplyViewModels;
    using Model;
    using Web.Core.Extensions;

    public class AdminFromViewModel : Profile
    {
        public AdminFromViewModel()
        {
            CreateMap<AttributeViewModel, Attribute>();
            CreateMap<AttributeValueViewModel, AttributeValue>();

            CreateMap<CreateCategoryViewModel, Category>().ForMember(
                m => m.Image,
                opt => opt.MapFrom(src => src.Image.ToByteArray()));
            CreateMap<EditCategoryViewModel, Category>();

            CreateMap<CreateProductViewModel, Product>().ForMember(
                m => m.Images,
                opt => opt.MapFrom(src => src.Images
                    .Select(x => new ProductImage { Image = x.ToByteArray(), ProductId = src.ProductId })));
            CreateMap<EditProductViewModel, Product>();
            CreateMap<SupplierViewModel, Supplier>();
            CreateMap<SupplyProductViewModel, SupplyProduct>();
            CreateMap<CreateSupplyViewModel, Supply>();
        }
    }
}