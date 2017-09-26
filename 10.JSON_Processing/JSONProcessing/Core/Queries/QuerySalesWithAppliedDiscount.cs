using JSONProcessing.Common;
using JSONProcessing.Services;
using JSONProcessing.Services.CarDealer;
using Ninject;
using System.Collections.Generic;

namespace JSONProcessing.Core.Queries
{
    class QuerySalesWithAppliedDiscount : Query
    {
        public override IEnumerable<object> ExportData { get; set; }

        private readonly ISaleService _saleService;

        public QuerySalesWithAppliedDiscount()
        {
            _saleService = NinjectCommon.Kernel.Get<SaleService>();
        }

        public override string Execute()
        {
            var salesWithAppliedDiscount = _saleService.SalesWithAppliedDiscount();
            ExportData = salesWithAppliedDiscount;

            return string.Join("\n---------------------\n", salesWithAppliedDiscount);
        }

        public override void Export()
        {
            Exporter.Export(this);
        }
    }
}
