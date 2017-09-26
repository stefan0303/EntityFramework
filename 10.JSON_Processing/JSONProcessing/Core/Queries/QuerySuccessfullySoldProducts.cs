using JSONProcessing.Common;
using JSONProcessing.Services;
using JSONProcessing.Services.ProductsShop;
using Ninject;
using System.Collections.Generic;

namespace JSONProcessing.Core.Queries
{
    class QuerySuccessfullySoldProducts : Query
    {
        private readonly IUserService _userService;
        public override IEnumerable<object> ExportData { get; set; }

        public QuerySuccessfullySoldProducts()
        {
            _userService = NinjectCommon.Kernel.Get<UserService>();
        }

        public override string Execute()
        {
            var products = _userService.SuccessfullySoldProducts();

            ExportData = products; // for export

            return string.Join("\n---------------------\n", products);
        }

        public override void Export()
        {
            Exporter.Export(this);
        }
    }
}
