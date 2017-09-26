namespace JSONProcessing.Models.CarDealer.Dtos
{
    public class LocalSuppliersDto
    {
        public int SupplierId { get; set; }

        public string Name { get; set; }

        public int PartsCount { get; set; }

        public override string ToString()
        {
            return $"Supplier ID: {SupplierId}\nSupplier Name: {Name}\nNumber of Supplied Parts: {PartsCount}";
        }
    }
}
