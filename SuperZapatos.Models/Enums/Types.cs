using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperZapatos.Models.Enums
{
    public enum ErrorType
    {
        BadRequest = 400,
        NotAuthorized = 401,
        RecordNotFound = 404,
        ServerError = 500
    }
}
