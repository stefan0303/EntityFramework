using System.Linq;
using System.Xml.Linq;
using ProductsShop.Data;

namespace Export_XML
{
    class Program
    {
        static void Main()
        {
            ProductShopContext context = new ProductShopContext();

            //ProductsInRange(context);
            CategoryByProductsCount(context);

        }
        private static void CategoryByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories.OrderBy(p => p.Products.Count)
                .Select(category => new
                    {
                        Name = category.Name,
                        CategoryByProductsCount = category.Products.Count,
                        AveragePrice= category.Products.Average(p=>p.Price),
                        TotalRevenu=category.Products.Sum(p=>p.Price)
                    }
                );
            var xmlDocument=new XElement("categories");
            foreach (var cat in categories)
            {
             
                var categoryNode= new XElement("category");
                  categoryNode.Add(new XAttribute("products-count",cat.CategoryByProductsCount));
                  categoryNode.Add(new XAttribute("average-price", cat.AveragePrice));
                  categoryNode.Add(new XAttribute("total-revenue", cat.TotalRevenu));

                  xmlDocument.Add(categoryNode);            
            }
            xmlDocument.Save("../../../categoryProductsCount.xml");
        }
        private static void ProductsInRange(ProductShopContext context)
        {
            var products = context.Products.Where(p => p.Price >= 1000 & p.Price <= 2000&p.BuyerId!=null).OrderBy(p=>p.Price)
                .Select(product=>new
                    {
                        Name = product.Name,
                        Price=product.Price,
                        Buyer=product.Buyer.FirstName+" "+product.Buyer.LastName
                    }
                );
            var xmlDocument =new XElement("products");
            foreach (var product in products)
            {
                var productNode =new XElement("product");
                productNode.Add(new XAttribute("name",product.Name));
                productNode.Add(new XAttribute("price", product.Price));
                productNode.Add(new XAttribute("buyer", product.Buyer));

                xmlDocument.Add(productNode);
            }
            xmlDocument.Save("../../../productsInRange.xml");
        }

    }
}
