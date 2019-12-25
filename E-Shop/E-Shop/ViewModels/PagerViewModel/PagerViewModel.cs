namespace E_Shop.ViewModels.PagerViewModel
{
    using System.Collections.Generic;

    using Models;

    public class PagerViewModel<T> where T : class
    {
        public List<T> Entities { get; set; }

        public Pager Pager { get; set; }
    }
}