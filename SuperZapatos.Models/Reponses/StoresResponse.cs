using System;
using System.Collections.Generic;
using SuperZapatos.Models.Primitives;
using System.Linq;

namespace SuperZapatos.Models.Responses
{
    public class StoresResponse : EnumerableResponse<Store>
    {
        [Newtonsoft.Json.JsonProperty("stores")]
        public override IEnumerable<Store> Elements { get; set; }

        public StoresResponse(IEnumerable<Store> stores)
        {
            this.Elements = stores;
        }
    }
}
