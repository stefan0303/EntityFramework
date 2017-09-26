using JSONProcessing.Common;
using JSONProcessing.Services;
using JSONProcessing.Services.CarDealer;
using Ninject;
using System.Collections.Generic;

namespace JSONProcessing.Core.Queries
{
    public class QueryTotalSalesByCustomer : Query
    {
        public override IEnumerable<object> ExportData { get; set; }

        private readonly ICustomerService _customerService;

        public QueryTotalSalesByCustomer()
        {
            _customerService = NinjectCommon.Kernel.Get<CustomerService>();
        }

        public override string Execute()
        {
            var totalSalesByCustomer = _customerService.TotalSalesByCustomer();
            ExportData = totalSalesByCustomer;

            return string.Join("\n---------------------\n", totalSalesByCustomer);
        }

        public override void Export()
        {
            Exporter.Export(this);
        }
    }
}
