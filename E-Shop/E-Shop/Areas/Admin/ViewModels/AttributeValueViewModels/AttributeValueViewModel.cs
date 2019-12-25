namespace E_Shop.Areas.Admin.ViewModels.AttributeValueViewModels
{
    using System.ComponentModel.DataAnnotations;

    using App_LocalResources;

    public class AttributeValueViewModel
    {
        public int AttributeValueId { get; set; }

        public int AttributeId { get; set; }

        [Display(Name = nameof(ViewModel.Name), ResourceType = typeof(ViewModel))]
        public string AttributeName { get; set; }

        public int ProductId { get; set; }

        [MaxLength(40, ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "MaxLength")]
        [Display(Name = nameof(ViewModel.Value), ResourceType = typeof(ViewModel))]
        public string Value { get; set; }
    }
}