using SuperZapatos.Models.Primitives;

namespace SuperZapatos.Models.Responses
{
    public class ArticleResponse : Interfaces.IEntityResponse<Article>
    {
        [Newtonsoft.Json.JsonProperty("success")]
        public bool Success
        {
            get
            {
                return true;
            }
        }

        [Newtonsoft.Json.JsonProperty("article")]
        public Article Element { get; set; }

        public ArticleResponse(Article article)
        {
            this.Element = article;
        }
    }
}
