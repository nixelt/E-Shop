namespace E_Shop.Areas.Admin.ViewModels.LogViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using App_LocalResources;

    public class LogViewModel
    {
        public int Id { get; set; }

        [Display(Name = nameof(ViewModel.Date), ResourceType = typeof(ViewModel))]
        public DateTime Date { get; set; }

        [Display(Name = nameof(ViewModel.Thread), ResourceType = typeof(ViewModel))]
        public string Thread { get; set; }

        [Display(Name = nameof(ViewModel.Level), ResourceType = typeof(ViewModel))]
        public string Level { get; set; }

        [Display(Name = nameof(ViewModel.Logger), ResourceType = typeof(ViewModel))]
        public string Logger { get; set; }

        [Display(Name = nameof(ViewModel.Message), ResourceType = typeof(ViewModel))]
        public string Message { get; set; }

        [Display(Name = nameof(ViewModel.Exception), ResourceType = typeof(ViewModel))]
        public string Exception { get; set; }
    }
}