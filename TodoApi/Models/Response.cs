using System.ComponentModel.DataAnnotations;

namespace TodoApi.Models
{
    public class Response
    {
        public bool Success { get; set; }
        public string message { get; set; }
        public object entity { get; set; }

        public Response()
        {
            Success = true;
        }
    }
}