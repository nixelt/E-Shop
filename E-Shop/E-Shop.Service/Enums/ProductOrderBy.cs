namespace E_Shop.Service.Enums
{
    using System.ComponentModel.DataAnnotations;

    public enum ProductOrderBy
    {

        [Display(Name = "По новизне")]
        NewDesc,

        [Display(Name = "По поулярности")]
        PopularityDesc,

        [Display(Name = "По рейтингу")]
        RatingDesc,

        [Display(Name = "От А до Я")]
        NameAsc,

        [Display(Name = "От Я до А")]
        NameDesc,

        [Display(Name = "От дешевых к дорогоим")]
        PriceAsc,

        [Display(Name = "От дорогих к дешевым")]
        PriceDesc
    }
}
