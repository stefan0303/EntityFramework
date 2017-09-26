using JSONProcessing.Services;
using JSONProcessing.Services.CarDealer;
using Ninject;
using System.Collections.Generic;
using JSONProcessing.Common;

namespace JSONProcessing.Core.Queries
{
    class QueryOrderedCustomers : Query
    {
        private readonly ICustomerService _customerService;

        public override IEnumerable<object> ExportData { get; set; }

        public QueryOrderedCustomers()
        {
            _customerService = NinjectCommon.Kernel.Get<CustomerService>();
        }

        public override string Execute()
        {
            var orderedCustomers = _customerService.OrderedCustomers();
            ExportData = orderedCustomers;

            return string.Join("\n---------------------\n", orderedCustomers);
        }

        public override void Export()
        {
            Exporter.Export(this);
        }
    }
}
