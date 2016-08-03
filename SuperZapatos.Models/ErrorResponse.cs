using System.Text.RegularExpressions;

namespace SuperZapatos.Models
{
    public class ErrorResponse : Interfaces.IResponse
    {
        [Newtonsoft.Json.JsonProperty("success")]
        public bool Success
        {
            get
            {
                return false;
            }
        }
        [Newtonsoft.Json.JsonProperty("error_code")]
        public Enums.ErrorType Type { get; set; }

        [Newtonsoft.Json.JsonProperty("error_msg")]
        public string Description
        {
            get
            {
                return Regex.Replace(Type.ToString(), "(\\B[A-Z])", " $1").ToUpper();
            }
        }

        public ErrorResponse(Enums.ErrorType type)
        {
            this.Type = type;
        }
    }
}
