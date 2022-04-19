namespace WebImoveis.Application.ViewModels
{
    public class PropertyModel
    {
        public int PropertyId { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public AddressModel Address { get; private set; }
        public int AddressId { get; private set; }
    }
}
