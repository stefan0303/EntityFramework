using System;

namespace ProductsShop
{
    using System.Linq;
    using Data;

    public class Application
    {
        public static void Main(string[] args)
        {
            ProductShopContext context = new ProductShopContext();
            Console.WriteLine(context.Categories.Count());
        }
    }
}
