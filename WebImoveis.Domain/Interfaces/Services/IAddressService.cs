using System;
using System.Collections.Generic;
using System.Text;
using WebImoveis.Domain.Entities;

namespace WebImoveis.Domain.Interfaces.Services
{
    interface IAddressService : IServiceBase<Address>
    {
        Address GetAddressThroughAPI(string cep);
    }
}
