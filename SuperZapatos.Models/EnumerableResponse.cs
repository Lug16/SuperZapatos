using SuperZapatos.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperZapatos.Models
{
    public abstract class EnumerableResponse<T> : IResponse
    {
        public abstract IEnumerable<T> Elements { get; set; }

        [Newtonsoft.Json.JsonProperty("total_elements")]
        public int ElementsCount
        {
            get
            {
                return Elements.Count();
            }
        }

        [Newtonsoft.Json.JsonProperty("success")]
        public bool Success
        {
            get
            {
                return true;
            }
        }
    }
}
