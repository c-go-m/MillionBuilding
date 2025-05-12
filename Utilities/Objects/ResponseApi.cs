
namespace Utilities.Objects
{
    public class ResponseApi
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public object? Data { get; set; }

        public ResponseApi(int code, string message)
        {
            this.Code = code;
            this.Message = message;
            this.Data = null;
        }
        public ResponseApi(int code, string message, object data)
        {
            this.Code = code;
            this.Message = message;
            this.Data = data;
        }

        public ResponseApi(int code,object data)
        {
            this.Code = code;
            this.Message = string.Empty;
            this.Data = data;
        }
    }
}
