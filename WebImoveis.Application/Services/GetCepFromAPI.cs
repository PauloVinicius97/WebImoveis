using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using WebImoveis.Domain.Entities;

namespace WebImoveis.Application.Services
{
    public class GetCepFromAPI
    {
        public static Address GetAddressFromJson(string cep)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri("https://viacep.com.br/ws/")
            };

            client.DefaultRequestHeaders.Add("User-Agent", "Anything");
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.GetAsync(cep + "/json/").Result;

            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException)
            {
                return null;
            }

            string json = response.Content.ReadAsStringAsync().Result;

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            TempAddressForAPI addressTemp = JsonSerializer.Deserialize<TempAddressForAPI>(json, options);
            Address address = new Address();

            address.Cep = addressTemp.Cep;
            address.Street = addressTemp.Logradouro;
            address.Neighborhood = addressTemp.Bairro;
            address.Town = addressTemp.Localidade;
            address.Uf = addressTemp.Uf;

            if (addressTemp.Cep != null)
            {
                try
                {
                    address.Cep = address.Cep.Remove(5, 1);
                }
                catch (Exception)
                {
                    return null;
                }
                return address;
            }
            return null;
        }
    }
}

