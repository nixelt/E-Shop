namespace E_Shop.Areas.Admin.ViewModels.ProductImageViewModels
{
    using System.Collections.Generic;
    using System.Web;

    public class AddImageViewModel
    {
        public int ProductId { get; set; }

        public List<HttpPostedFileBase> PostedFiles { get; set; }
    }
}