using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Shop.Areas.Admin.ViewModels
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class CreateCategoryViewModel
    {
        [DisplayName("Название")]
        [Required(ErrorMessage = "Обязательное поле")]
        public string Name { get; set; }
        [DisplayName("Изображение")]
        [Required(ErrorMessage = "Обязательное поле")]
        public HttpPostedFileBase Image { get; set; }
    }
}