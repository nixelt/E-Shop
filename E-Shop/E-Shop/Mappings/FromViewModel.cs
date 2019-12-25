namespace E_Shop.Mappings
{
    using AutoMapper;

    using ViewModels.CategoryViewModels;
    using ViewModels.ReviewViewModels;

    using Model;

    using ViewModels.OrderViewModels;
    using ViewModels.ProductViewModels;

    public class FromViewModel : Profile
    {
        public FromViewModel()
        {
            CreateMap<AttributeValueViewModel, AttributeValue>();
            CreateMap<CategoryViewModel, Category>();
            CreateMap<CreateOrderViewModel, Order>();
            CreateMap<ReviewViewModel, Review>();
        }
    }
}