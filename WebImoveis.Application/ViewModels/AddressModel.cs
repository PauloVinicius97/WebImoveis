namespace WebImoveis.Application.ViewModels
{
    public class AddressModel
    {
        public int AddressId { get; private set; }
        public string Cep { get; private set; }
        public int Number { get; private set; }
        public string Street { get; private set; }
        public string Neighborhood { get; private set; }
        public string Town { get; private set; }
        public string Uf { get; private set; }
        public PropertyModel Property { get; private set; }
    }
}
