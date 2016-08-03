using SuperZapatos.Models.Responses;
using SuperZapatos.WebApi.Custom;
using System.Web.Http;
using System.Linq;
using System.Linq.Expressions;
using SuperZapatos.Models.Primitives;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;

namespace SuperZapatos.WebApi.Controllers
{

    /// <summary>
    /// Entity which identifies a Store
    /// </summary>
    [CutomAuthorizeAttribute]
    public class StoresController : ApiController
    {
        /// <summary>
        /// Returns a list of stores
        /// </summary>
        /// <returns>Returns all the current stores</returns>
        public StoresResponse Get()
        {
            var handler = new RepositoryHandler.StoreHandler();

            var stores = handler.List();

            return new StoresResponse(stores);
        }

        /// <summary>
        /// Returns a specific Store
        /// </summary>
        /// <param name="id">Id of the store</param>
        /// <returns>Returns the requested store</returns>
        public StoreResponse Get(int id)
        {
            var handler = new RepositoryHandler.StoreHandler();

            var store = handler.GetById(id);

            return new StoreResponse(store);
        }

        /// <summary>
        /// Inserts a store to the database
        /// </summary>
        /// <param name="element">A new store</param>
        public HttpResponseMessage Post([FromBody]Store element)
        {
            var handler = new RepositoryHandler.StoreHandler();

            handler.Insert(element);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Updates a specific Store
        /// </summary>
        /// <param name="id">Id of the store</param>
        /// <param name="value">Updated store</param>
        public HttpResponseMessage Put(int id, [FromBody]Store element)
        {
            var handler = new RepositoryHandler.StoreHandler();

            handler.Update(element);

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        /// <summary>
        /// Deletes a specific Store
        /// </summary>
        /// <param name="id">Id of the store</param>
        public HttpResponseMessage Delete(int id)
        {
            var handler = new RepositoryHandler.StoreHandler();

            handler.Delete(id);

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
