namespace E_Shop.Web.Core.Extensions
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;

    public static class ValidationResultExtension
    {
        public static void AddModelErrors(this ModelStateDictionary modelState, IEnumerable<ValidationResult> validationResults, string defaultErrorKey = null)
        {
            if (validationResults == null)
            {
                return;
            }

            foreach (var validationResult in validationResults)
            {
                var key = validationResult.MemberNames.FirstOrDefault() ?? defaultErrorKey ?? string.Empty;
                modelState.AddModelError(key, validationResult.ErrorMessage);
            }
        }
    }
}
