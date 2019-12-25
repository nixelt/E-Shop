 using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Shop.Areas.Admin.ViewModels
{
    using E_Shop.Model.Models;

    public class IndexAttributeViewModel
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public List<Attribute> Attributes { get; set; }
    }
}