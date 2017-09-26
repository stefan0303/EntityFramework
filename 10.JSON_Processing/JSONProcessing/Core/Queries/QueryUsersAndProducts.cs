using JSONProcessing.Common;
using JSONProcessing.Services;
using JSONProcessing.Services.ProductsShop;
using Ninject;
using System.Collections.Generic;

namespace JSONProcessing.Core.Queries
{
    public class QueryUsersAndProducts : Query
    {
        private readonly IUserService _userService;
        public override IEnumerable<object> ExportData { get; set; }

        public QueryUsersAndProducts()
        {
            _userService = NinjectCommon.Kernel.Get<UserService>();
        }

        public override string Execute()
        {
            var usersAndProducts = _userService.UsersAndProducts();
            ExportData = new[] { usersAndProducts };

            return string.Join("", usersAndProducts);
        }

        public override void Export()
        {
            Exporter.Export(this);
        }
    }
}
