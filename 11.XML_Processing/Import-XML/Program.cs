using System;
using System.Linq;
using System.Xml.Linq;
using ProductsShop.Data;
using ProductsShop.Model;

namespace Import_XML
{
    class Program
    {
        static void Main()
        {
            ProductShopContext context = new ProductShopContext();


            //ImportUsers(context);
            //ImportProducts(context);
           // ImportCategories(context);//is not OK
           

        }
        private static void ImportCategories(ProductShopContext context)
        {
            XDocument categoriesXml = XDocument.Load("../../../Xml-files/categories.xml");
            XElement categoryRoot = categoriesXml.Root;

            foreach (var categoryElementh in categoryRoot.Elements())
            {
                string name = categoryElementh.Element("name")?.Value;       
                if (name != null)
                {
                    Category category = new Category()
                    {
                        Name = name
                    };
                    int count = 326;
                    var products = context.Products.Where(p=>p.Id<count+20);
                  
                    foreach (var product in products)
                    {                       
                        product.Categories.Add(category);                          
                    }
                    count += 20;
                }
            }           
            context.SaveChanges();
            
        }
        private static void ImportUsers(ProductShopContext context)
        {
            XDocument usersXml = XDocument.Load("../../../Xml-files/users.xml");
            XElement userRoot = usersXml.Root;
            foreach (var userElementh in userRoot.Elements())
            {
                string firsName = userElementh.Attribute("first-name")?.Value;
                string lastName = userElementh.Attribute("last-name")?.Value;

                int age = Convert.ToInt32(userElementh.Attribute("age")?.Value);//Triabva da e ConvertToint32 a ne Parse inache ne minava
                if (lastName != null)
                {
                    User user = new User()
                    {
                        FirstName = firsName,
                        LastName = lastName,
                        Age = age
                    };
                    context.Users.Add(user);
                }

            }
            context.SaveChanges();
        }
        private static void ImportProducts(ProductShopContext context)
        {
            XDocument productsXml = XDocument.Load("../../../Xml-files/products.xml");
            XElement productsRoot = productsXml.Root;

            foreach (var productElementh in productsRoot.Elements())
            {
                string name = productElementh.Element("name")?.Value;//Zashto stava sus Elementh a ne sus Attribute
                decimal price = Convert.ToDecimal(productElementh.Element("price").Value);//Ne go vzima

                Random rnd = new Random();
                int usersCount = context.Users.Count();
                if (rnd.Next(1, usersCount - 1)%3==0)
                {
                    Product product = new Product()
                    {
                        Name = name,
                        Price = price,
                        BuyerId = null,
                        SelledId = rnd.Next(1, usersCount - 2)
                    };
                    context.Products.Add(product);
                }
                else
                {
                    Product product = new Product()
                    {
                        Name = name,
                        Price = price,
                        BuyerId = rnd.Next(1, usersCount - 1),
                        SelledId = rnd.Next(1, usersCount - 2)
                    };
                    context.Products.Add(product);
                }
                
                

            }
            context.SaveChanges();
        }
    }
}
