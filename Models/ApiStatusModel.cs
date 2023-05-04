using System.ComponentModel;
using System.Net;

namespace Funix.HannahAssistant.Api.Models
{
    public class ApiStatusModel<T>
    {
        public ApiStatusCode ApiStatusCode { get; set; }
        public string? ApiMessage { get; set; }
        public T? ReturnData { get; set; }
        public ApiException? ApiException { get; set; }
        public ApiHttpStatus? ApiHttpStatus { get; set; }
    }

    public class ApiException
    {
        [DefaultValue(-1)]
        public int ErrorCode { get; set; }
        public Exception? Exception { get; set; }
        public string? ExceptionMessage { get; set; }
    }

    public class ApiHttpStatus
    {
        [DefaultValue(HttpStatusCode.OK)]
        public HttpStatusCode HttpCode { get; set; }
    }

    public enum ApiStatusCode
    {
        Error = -1,
        OK = 0,
        Warning = 1,
        Empty = 2
    }
}
