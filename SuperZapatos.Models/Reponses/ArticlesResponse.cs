using System;
using System.Collections.Generic;
using SuperZapatos.Models.Primitives;
using System.Linq;

namespace SuperZapatos.Models.Responses
{
    public class ArticlesResponse : EnumerableResponse<Article>
    {
        [Newtonsoft.Json.JsonProperty("articles")]
        public override IEnumerable<Article> Elements { get; set; }

        public ArticlesResponse(IEnumerable<Article> articles)
        {
            this.Elements = articles;
        }
    }
}
