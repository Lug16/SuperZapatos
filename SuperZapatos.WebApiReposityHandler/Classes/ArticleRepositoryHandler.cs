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
    public class ArticleRepositoryHandler : IRespositoryHandler<Article>
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
                var content = response.Content.ReadAsAsync<Models.Responses.ArticleResponse>().Result;
            }
        }

        public Article GetById(int id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));

                HttpResponseMessage response = client.GetAsync(url + "/" + id.ToString()).Result;
                var content = response.Content.ReadAsAsync<Models.Responses.ArticleResponse>().Result;

                return content.Element;
            }
        }

        public void Insert(Article entity)
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

        public IEnumerable<Article> List()
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(credentials));

                HttpResponseMessage response = client.GetAsync(url).Result;
                var content = response.Content.ReadAsAsync<Models.Responses.ArticlesResponse>().Result;

                return content.Elements;
            }
        }

        public void Update(Article entity)
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

        public ArticleRepositoryHandler(string url)
        {
            this.url = url + "articles";
        }
    }
}
