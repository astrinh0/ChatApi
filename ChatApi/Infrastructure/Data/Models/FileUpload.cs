using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Data.Models
{
    public class FileUpload
    {
        public IFormFile Files { get; set; }
    }
}
