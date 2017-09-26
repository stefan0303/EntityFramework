using JSONProcessing.Data;
using JSONProcessing.Data.CarDealer;
using JSONProcessing.Services.CarDealer;
using JSONProcessing.Services.ProductsShop;
using Ninject;
using Ninject.Modules;

namespace JSONProcessing.Services
{
    public static class NinjectCommon
    {
        public static IKernel Kernel { get; set; }

        public static void InitializeKernel()
        {
            Kernel = new StandardKernel(new Bindings());
        }

        private class Bindings : NinjectModule
        {
            public override void Load()
            {

                Bind<IProductsShopContext>().To<ProductsShopContext>();

                Bind<IUserService>().To<UserService>();
                Bind<IProductService>().To<ProductService>();
                Bind<ICategoryService>().To<CategoryService>();

                Bind<ICarDealerContext>().To<CarDealerContext>();

                Bind<ICarService>().To<CarService>();
                Bind<ICustomerService>().To<CustomerService>();
                Bind<ISaleService>().To<SaleService>();
                Bind<IPartService>().To<PartService>();
                Bind<ISupplierService>().To<SupplierService>();
            }
        }
    }
}
