using Sales;

namespace LocalStore.Models
{
    class Program
    {
        static void Main(string[] args)
        {
           SalesContext context =new SalesContext();
            
            context.Products.Add(new Product
            {
                Name = "Wash mashine",
                Quantity = 22,             
                Price = 299.01m,               
            }
            );
            
            //context.Products.Add(new Product
            //{
            //    Name = "Wash mashine",
            //    DistributorName = "Philips",
            //    Description = "very nice Wash mashine",
            //    Price = 421.12m
            //}
            //);
            //context.Products.Add(new Product
            //{
            //    Name = "Laptop",
            //    DistributorName = "Lenovo",
            //    Description = " nice Laptop",
            //    Price = 1523.11m
            //}
            //);
            context.SaveChanges();
           
        }
    }
}
