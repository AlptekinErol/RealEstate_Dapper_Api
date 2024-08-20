namespace RealEstate_Dapper_UI.Models.CategoryStatisticsViewModel
{
    public class CategoryStatisticViewModel
    {
        public int ActiveCategoryCount { get; set; }
        public int CategoryCount { get; set; }
        public string? CategoryNameByMaxProductCount { get; set; }
        public int DeactiveCategoryCount { get; set; }
    }
}
