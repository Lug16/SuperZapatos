using SuperZapatos.Models.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SuperZapatos.RepositoryHandler
{
    public class StoreRepositoryHandler : IRespositoryHandler<Store>
    {
        private byte[] credentials = Encoding.ASCII.GetBytes("my_user:my_password");
        private string url;

        public void Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));

                HttpResponseMessage response = client.DeleteAsync(url + "/" + id.ToString()).Result;
                var content = response.Content.ReadAsAsync<Models.Responses.StoreResponse>().Result;
            }
        }

        public Store GetById(int id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));

                HttpResponseMessage response = client.GetAsync(url + "/" + id.ToString()).Result;
                var content = response.Content.ReadAsAsync<Models.Responses.StoreResponse>().Result;

                return content.Element;
            }
        }

        public void Insert(Store entity)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));

                var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(entity, Newtonsoft.Json.Formatting.None), Encoding.UTF8, "application/json");
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                request.Content = content;

                var response = client.SendAsync(request).Result;
            }
        }

        public IEnumerable<Store> List()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));

                HttpResponseMessage response = client.GetAsync(url).Result;
                var content = response.Content.ReadAsAsync<Models.Responses.StoresResponse>().Result;

                return content.Elements;
            }
        }

        public void Update(Store entity)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));

                var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(entity, Newtonsoft.Json.Formatting.None), Encoding.UTF8, "application/json");

                var response = client.PutAsync(url + "/" + entity.Id.ToString(), content).Result;
            }
        }

        public StoreRepositoryHandler(string url)
        {
            this.url = url + "stores";
        }
    }
}
