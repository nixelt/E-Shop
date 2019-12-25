namespace E_Shop.Areas.Admin.ViewModels.AttributeViewModels
{
    using System.ComponentModel.DataAnnotations;

    using App_LocalResources;

    public class AttributeViewModel
    {
        public int CategoryId { get; set; }
        public int AttributeId { get; set; }
        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Required")]
        [MaxLength(30, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MaxLength")]
        [Display(Name = nameof(ViewModel.Name), ResourceType = typeof(ViewModel))]
        public string Name { get; set; }

        [Display(Name = nameof(ViewModel.AllowedFiltering), ResourceType = typeof(ViewModel))]
        public bool AllowFiltering { get; set; }
    }
}