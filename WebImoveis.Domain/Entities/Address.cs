
using System.Collections.Generic;

namespace WebImoveis.Domain.Entities
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Cep { get; set; }
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string Town { get; set; }
        public string Uf { get; set; }
        public IList<Property> Properties { get; set; }
    }
}
