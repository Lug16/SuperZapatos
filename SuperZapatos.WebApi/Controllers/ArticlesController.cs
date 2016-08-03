using SuperZapatos.Models.Primitives;
using SuperZapatos.Models.Responses;
using SuperZapatos.WebApi.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SuperZapatos.WebApi.Controllers
{
    /// <summary>
    /// Entity which identifies am article
    /// </summary>
    [CutomAuthorizeAttribute]
    public class ArticlesController : ApiController
    {
        /// <summary>
        /// Returns a list of articles
        /// </summary>
        /// <returns>Returns all the current articles</returns>
        public ArticlesResponse Get()
        {
            var handler = new RepositoryHandler.ArticleHandler();

            var list = handler.List();

            return new ArticlesResponse(list);
        }

        /// <summary>
        /// Returns an specific article
        /// </summary>
        /// <param name="id">Id of the article</param>
        /// <returns>Returns the requested article</returns>
        public ArticleResponse Get(int id)
        {
            var handler = new RepositoryHandler.ArticleHandler();

            var entity = handler.GetById(id);

            return new ArticleResponse(entity);
        }

        /// <summary>
        /// Gets the list of articles from a store
        /// </summary>
        /// <param name="id">Id of the store</param>
        /// <returns>Returns the list of articles</returns>
        [Route("services/Articles/store/{Id}")]
        public ArticlesResponse GetArticlesByStore(int id)
        {
            var handler = new RepositoryHandler.ArticleHandler();

            var list = handler.ListByStore(id).Select(
                r => new Article
                {
                    Description = r.Description,
                    Id = r.Id,
                    Name = r.Name,
                    Price = r.Price,
                    StoreId = r.StoreId,
                    Total_In_Shelf = r.Total_In_Shelf,
                    Total_In_Vault = r.Total_In_Vault
                }); 

            return new ArticlesResponse(list);
        }

        /// <summary>
        /// Inserts an article to the database
        /// </summary>
        /// <param name="value">A new article</param>
        public HttpResponseMessage Post([FromBody]Article value)
        {
            var handler = new RepositoryHandler.ArticleHandler();

            handler.Insert(value);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Updates an specific article
        /// </summary>
        /// <param name="id">Id of the article</param>
        /// <param name="value">Updated article</param>
        public HttpResponseMessage Put(int id, [FromBody]Article element)
        {
            var handler = new RepositoryHandler.ArticleHandler();

            handler.Update(element);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Deletes an specific article
        /// </summary>
        /// <param name="id">Id of the article</param>
        public HttpResponseMessage Delete(int id)
        {
            var handler = new RepositoryHandler.ArticleHandler();

            handler.Delete(id);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
