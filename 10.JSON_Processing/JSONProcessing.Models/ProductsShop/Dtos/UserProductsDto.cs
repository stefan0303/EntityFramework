namespace JSONProcessing.Models.ProductsShop.Dtos
{
    public class UserProductsDto
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? Age { get; set; }

        public ProductCountDto SoldProducts { get; set; }

        public override string ToString()
        {
            return
                $"User: {FirstName ?? "[no name]"} {LastName}, Age: {Age}" +
                $"\n-  Sold Products:\n--   {string.Join("\n--  ", SoldProducts)}";
        }
    }
}
