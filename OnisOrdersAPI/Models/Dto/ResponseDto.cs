using System.Net;

namespace OnisOrdersAPI.Models.Dto
{
    public class ResponseDto
    {
        public ResponseDto()
        {
            ErrorMessages = new List<string>();
        }
        public HttpStatusCode statusCode { get; set; }
        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; }
        public string DisplayMessage { get; set; } = "";
        public List<string> ErrorMessages { get; set; }
    }
}
