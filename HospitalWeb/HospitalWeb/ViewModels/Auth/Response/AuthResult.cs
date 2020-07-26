using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HospitalWeb.ViewModels.Auth.Response
{
    public class AuthResult<T>
    {
        public AuthStatus Status { get; set; }
        public T Payload { get; set; }
        public string Message { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum AuthStatus
    {
        Fail,
        Success
    }
}