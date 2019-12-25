namespace E_Shop.ViewModels.CategoryViewModels
{
    using System.ComponentModel.DataAnnotations;

    using App_LocalResources;

    public class CategoryViewModel
    {
        public int CategoryId { get; set; }

        [Display(Name = nameof(ViewModel.Name), ResourceType = typeof(ViewModel))]
        public string Name { get; set; }
    }
}