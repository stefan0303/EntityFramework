using JSONProcessing.Common;
using JSONProcessing.Services;
using JSONProcessing.Services.ProductsShop;
using Ninject;
using System.Collections.Generic;

namespace JSONProcessing.Core.Queries
{
    class QueryCategoriesByProductsCount : Query
    {
        private readonly ICategoryService _categoryService;
        public override IEnumerable<object> ExportData { get; set; }

        public QueryCategoriesByProductsCount()
        {
            _categoryService = NinjectCommon.Kernel.Get<CategoryService>();
        }

        public override string Execute()
        {
            var categories = _categoryService.CategoriesByProductsCount();
            ExportData = categories;
            return string.Join("\n---------------------\n", categories);
        }

        public override void Export()
        {
            Exporter.Export(this);
        }
    }
}
