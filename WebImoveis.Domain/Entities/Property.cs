namespace WebImoveis.Domain.Entities
{
    public class Property
    {
        public int PropertyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Number { get; set; }
        public Address Address { get; set; }
        public int AddressId { get; set; }
    }
}
