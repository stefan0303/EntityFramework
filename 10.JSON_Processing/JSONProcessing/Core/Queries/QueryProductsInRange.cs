using JSONProcessing.Common;
using JSONProcessing.Services;
using JSONProcessing.Services.ProductsShop;
using Ninject;
using System.Collections.Generic;

namespace JSONProcessing.Core.Queries
{
    class QueryProductsInRange : Query
    {
        private static IProductService _productService;
        private readonly int _bottom;
        private readonly int _top;
        private readonly bool _inclusive;

        public override IEnumerable<object> ExportData { get; set; }

        public QueryProductsInRange(int bottom = 500, int top = 1000, bool inclusive = true)
        {
            _productService = NinjectCommon.Kernel.Get<ProductService>();

            _bottom = bottom;
            _top = top;
            _inclusive = inclusive;
        }

        public override string Execute()
        {
            var products = _productService.ProductsInRange(_bottom, _top, _inclusive);
            ExportData = products; // for export

            return string.Join("\n---------------------\n", products);
        }

        public override void Export()
        {
            Exporter.Export(this);
        }

    }
}
