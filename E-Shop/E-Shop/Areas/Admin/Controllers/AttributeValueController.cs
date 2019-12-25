namespace E_Shop.Areas.Admin.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using ViewModels.AttributeValueViewModels;
    using Model;
    using Service;

    public class AttributeValueController : Controller
    {
        private readonly IAttributeValueService _attributeValueService;

        private readonly ICategoryService _categoryService;

        private readonly IProductService _productService;

        public AttributeValueController(IAttributeValueService attributeValueService, ICategoryService categoryService, IProductService productService)
        {
            _attributeValueService = attributeValueService;
            _categoryService = categoryService;
            _productService = productService;
        }

        // GET: Admin/AttributeValue
        public ActionResult GetDistinctValues(int attributeId, string term)
        {
            var values = _attributeValueService.GetDistinctValues(attributeId, term);
            return Json(values, JsonRequestBehavior.AllowGet);
        }

        // GET: Admin/AttributeValue/Edit
        [HttpGet]
        public ActionResult Edit(int productId)
        {
            var category = _productService.GetProduct(productId);
            if (category == null)
            {
                return RedirectToAction("NotFound", "Error", new { Area = string.Empty });
            }

            var attributes = _categoryService.GetCategory(category.CategoryId).Attributes;
            var attributeValues = _attributeValueService.GetAttributeValues(productId);
            var test = attributes.GroupJoin(
                attributeValues,
                atr => atr.AttributeId,
                av => av.AttributeId,
                (atr, av) => new AttributeValue
                {
                    AttributeValueId = av.Select(x => x.AttributeValueId).FirstOrDefault(),
                    AttributeId = atr.AttributeId,
                    Attribute = atr,
                    ProductId = productId,
                    Value = av.SingleOrDefault()?.Value
                });
            var model = test.Select(Mapper.Map<AttributeValue, AttributeValueViewModel>).ToList();
            return View(model);
        }

        // POST: Admin/AttributeValue/Edit
        [HttpPost]
        public ActionResult Edit(List<AttributeValueViewModel> model)
        {
            if (model == null)
            {
                ModelState.AddModelError(string.Empty, @"Введите значения!");
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var attributeValues = model.Select(Mapper.Map<AttributeValueViewModel, AttributeValue>).ToList();
            _attributeValueService.EditAttributeValues(attributeValues);
            Logger.Log.Info($"{User.Identity.Name} изменил характеристики товара №{model.First().ProductId}");
            var productId = attributeValues[0].ProductId;
            return RedirectToAction("Index", "Product", new { Area = string.Empty, id = productId });
        }
    }
}