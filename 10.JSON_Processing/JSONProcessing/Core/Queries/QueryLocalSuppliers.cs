using JSONProcessing.Common;
using JSONProcessing.Services;
using JSONProcessing.Services.CarDealer;
using Ninject;
using System.Collections.Generic;

namespace JSONProcessing.Core.Queries
{
    class QueryLocalSuppliers : Query
    {
        public override IEnumerable<object> ExportData { get; set; }

        private readonly ISupplierService _supplierService;

        public QueryLocalSuppliers()
        {
            _supplierService = NinjectCommon.Kernel.Get<SupplierService>();
        }

        public override string Execute()
        {
            var localSuppliers = _supplierService.LocalSuppliers();
            ExportData = localSuppliers;

            return string.Join("\n---------------------\n", localSuppliers);
        }

        public override void Export()
        {
            Exporter.Export(this);
        }
    }
}
