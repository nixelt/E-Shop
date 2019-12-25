using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Shop.ViewModels
{
    using E_Shop.Model.Models;
    
    public class DetailsCategoryViewModel
    {
        public IndexCategoryViewModel Category { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public List<Attribute> Attributes { get; set; }
        public List<IndexProductViewModel> Products { get; set; }
    }
}