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
    public partial class Supplier
    {

        public Supplier()
        {
            Items = new HashSet<Item>();
        }

        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string SupplierPhone { get; set; }
        public string SupplierEmail { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Item> Items { get; set; }

        public ObservableCollection<Supplier> GetUserSupplier()
        {
            string Consumo = string.Format(ObjetosGlobales.RutaPruebas + "suppliers/GetSuppliersList?UserId={0}", UserId);

            var client = new RestClient(Consumo);
            var request = new RestRequest(Method.GET);

            request.AddHeader(ObjetosGlobales.ApiKeyName, ObjetosGlobales.ApiKeyValue);


            IRestResponse response = client.Execute(request);

            HttpStatusCode statusCode = response.StatusCode;

            var AllItems = JsonConvert.DeserializeObject<ObservableCollection<Supplier>>(response.Content);

            if (statusCode == HttpStatusCode.OK)
            {
                return AllItems;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> AgregarSupplier()
        {
            bool r = false;

            string RutaApi = ObjetosGlobales.RutaProduccion + "suppliers";
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
        public async Task<bool> ModificarSupplier()
        {
            bool r = false;

            string RutaApi = string.Format(ObjetosGlobales.RutaProduccion + "suppliers/{0}", this.SupplierId);
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
        public async Task<bool> EliminarSupplier()
        {
            bool r = false;

            string RutaApi = string.Format(ObjetosGlobales.RutaProduccion + "suppliers/{0}", this.SupplierId);
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
