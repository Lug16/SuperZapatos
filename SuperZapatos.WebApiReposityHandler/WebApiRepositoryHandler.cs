using SuperZapatos.RepositoryHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperZapatos.WebApiReposityHandler
{
    public class WebApiRepositoryHandler
    {
        public ArticleRepositoryHandler Articles { get; set; }

        public StoreRepositoryHandler Stores { get; set; }

        public string Url { get; set; }

        public WebApiRepositoryHandler(string url)
        {
            Articles = new ArticleRepositoryHandler(url);
            Stores = new StoreRepositoryHandler(url);
        }
    }
}
