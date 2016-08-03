using SuperZapatos.Models.Primitives;

namespace SuperZapatos.Models.Responses
{
    public class StoreResponse : Interfaces.IEntityResponse<Store>
    {
        [Newtonsoft.Json.JsonProperty("success")]
        public bool Success
        {
            get
            {
                return true;
            }
        }

        [Newtonsoft.Json.JsonProperty("store")]
        public Store Element { get; set; }

        public StoreResponse(Store store)
        {
            this.Element = store;
        }
    }
}
