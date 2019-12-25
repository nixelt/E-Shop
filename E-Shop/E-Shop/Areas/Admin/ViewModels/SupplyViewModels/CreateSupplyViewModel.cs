namespace E_Shop.Areas.Admin.ViewModels.SupplyViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using App_LocalResources;

    public class CreateSupplyViewModel : SupplyViewModel
    {

        [Required(ErrorMessageResourceType = typeof(Errors), ErrorMessageResourceName = "Required")]
        public int SupplierId { get; set; }

        public List<SupplyProductViewModel> SupplyProducts { get; set; }

        public List<SelectListItem> Suppliers { get; set; }

        public List<SelectListItem> Products { get; set; }
    }
}