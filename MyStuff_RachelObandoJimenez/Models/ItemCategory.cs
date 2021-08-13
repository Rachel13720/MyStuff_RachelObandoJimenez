using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyStuff_RachelObandoJimenez.Models
{
    public partial class ItemCategory
    {
        public ItemCategory()
        {
            Items = new HashSet<Item>();
        }

        public int ItemCategoryId { get; set; }
        public string Category { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Item> Items { get; set; }

        public ObservableCollection<ItemCategory> GetUserItemCategory()
        {
            string Consumo = string.Format(ObjetosGlobales.RutaPruebas + "categories/GetCategoriesList?UserId={0}", UserId);

            var client = new RestClient(Consumo);
            var request = new RestRequest(Method.GET);

            request.AddHeader(ObjetosGlobales.ApiKeyName, ObjetosGlobales.ApiKeyValue);


            IRestResponse response = client.Execute(request);

            HttpStatusCode statusCode = response.StatusCode;

            var AllItems = JsonConvert.DeserializeObject<ObservableCollection<ItemCategory>>(response.Content);

            if (statusCode == HttpStatusCode.OK)
            {
                return AllItems;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> AgregarCategory()
        {
            bool r = false;

            string RutaApi = ObjetosGlobales.RutaProduccion + "categories";
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
        public async Task<bool> ModificarCategory()
        {
            bool r = false;

            string RutaApi = string.Format(ObjetosGlobales.RutaProduccion + "categories/{0}", this.ItemCategoryId);
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
        public async Task<bool> EliminarCategory()
        {
            bool r = false;

            string RutaApi = string.Format(ObjetosGlobales.RutaProduccion + "categories/{0}", this.ItemCategoryId);
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
