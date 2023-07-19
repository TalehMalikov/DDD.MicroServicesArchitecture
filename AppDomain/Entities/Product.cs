namespace AppDomain.Entities
{
    public class Product 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }
    }
}
