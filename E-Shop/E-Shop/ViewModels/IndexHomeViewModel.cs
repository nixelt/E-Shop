using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Shop.ViewModels
{

    public class IndexHomeViewModel
    {
        public List<IndexCategoryViewModel> Categories { get; set; }
        public List<IndexProductViewModel> Newest { get; set; }
    }
}