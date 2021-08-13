using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using RestSharp;
using System.Net;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MyStuff_RachelObandoJimenez.Models
{

    public partial class Brand
    {
        public Brand()
        {
            Items = new HashSet<Item>();
        }

        public int BrandId { get; set; }
        public string BrandName { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Item> Items { get; set; }

        public ObservableCollection<Brand> GetUserBrands()
        {
            string Consumo = string.Format(ObjetosGlobales.RutaPruebas + "brands/GetBrandsList?UserId={0}", UserId);

            var client = new RestClient(Consumo);
            var request = new RestRequest(Method.GET);

            request.AddHeader(ObjetosGlobales.ApiKeyName, ObjetosGlobales.ApiKeyValue);


            IRestResponse response = client.Execute(request);

            HttpStatusCode statusCode = response.StatusCode;

            var AllItems = JsonConvert.DeserializeObject<ObservableCollection<Brand>>(response.Content);

            if (statusCode == HttpStatusCode.OK)
            {
                return AllItems;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> AgregarBrand()
        {
            bool r = false;

            string RutaApi = ObjetosGlobales.RutaProduccion + "brands";
            var client = new RestClient(RutaApi);
            var request = new RestRequest(method: Method.POST);

            request.AddHeader(ObjetosGlobales.ApiKeyName, ObjetosGlobales.ApiKeyValue);
            request.AddHeader("Content-type", "application/json");

            string JsonClass = JsonConvert.SerializeObject(this);
            request.AddParameter("application/json", JsonClass, ParameterType.RequestBody);

            IRestResponse response = await client.ExecuteAsync(request);
            HttpStatusCode code = response.StatusCode;

            if (code == HttpStatusCode.Created)
            {
                r = true;
            }

            return r;
        }
        public async Task<bool> ModificarBrand()
        {
            bool r = false;

            string RutaApi = string.Format(ObjetosGlobales.RutaProduccion + "brands/{0}", this.BrandId);
            var client = new RestClient(RutaApi);
            var request = new RestRequest(method: Method.PUT);

            request.AddHeader(ObjetosGlobales.ApiKeyName, ObjetosGlobales.ApiKeyValue);
            request.AddHeader("Content-type", "application/json");

            string JsonClass = JsonConvert.SerializeObject(this);
            request.AddParameter("application/json", JsonClass, ParameterType.RequestBody);

            IRestResponse response = await client.ExecuteAsync(request);
            HttpStatusCode code = response.StatusCode;

            if (code == HttpStatusCode.OK)
            {
                r = true;
            }

            return r;
        }
        public async Task<bool> EliminarBrand()
        {
            bool r = false;

            string RutaApi = string.Format(ObjetosGlobales.RutaProduccion + "brands/{0}", this.BrandId);
            var client = new RestClient(RutaApi);
            var request = new RestRequest(method: Method.DELETE);

            request.AddHeader(ObjetosGlobales.ApiKeyName, ObjetosGlobales.ApiKeyValue);
            request.AddHeader("Content-type", "application/json");

            string JsonClass = JsonConvert.SerializeObject(this);
            request.AddParameter("application/json", JsonClass, ParameterType.RequestBody);

            IRestResponse response = await client.ExecuteAsync(request);
            HttpStatusCode code = response.StatusCode;

            if (code == HttpStatusCode.OK)
            {
                r = true;
            }

            return r;
        }


    }
}
