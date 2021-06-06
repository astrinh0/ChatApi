using Microsoft.AspNetCore.Http;

namespace ChatApi.Infrastructure.Data.Models
{
    public class FileUpload
    {
        public IFormFile Files { get; set; }

    }
}
