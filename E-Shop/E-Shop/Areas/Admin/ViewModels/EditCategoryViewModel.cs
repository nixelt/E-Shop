using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Shop.Areas.Admin.ViewModels
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class EditCategoryViewModel
    {
        public int CategoryId { get; set; }
        [DisplayName("Название")]
        [Required(ErrorMessage = "Обязательное поле")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Обязательное поле")]
        public byte[] Image { get; set; }
    }
}