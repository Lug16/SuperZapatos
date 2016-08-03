using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperZapatos.Models.Interfaces
{
    public interface IEntityResponse<T> : IResponse
    {
        T Element { get; set; }
    }
}
