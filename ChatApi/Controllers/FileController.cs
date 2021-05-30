using ChatApi.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ChatApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class FileController : Controller
    {
        public static IWebHostEnvironment _webHostEnviroment;


        public FileController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnviroment = webHostEnvironment;
        }

        [HttpPost]
        public async Task<string> FileUpload([FromForm] FileUpload fileUpload)
        {
            try
            {
                if (fileUpload.Files.Length > 0)
                {
                    string path = _webHostEnviroment.WebRootPath + "\\uploads\\";
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }

                    using (FileStream fileStream = System.IO.File.Create(path + fileUpload.Files.FileName))
                    {
                        fileUpload.Files.CopyTo(fileStream);
                        fileStream.Flush();
                        return ("Upload Done!");
                    }
                }

                else
                {
                    return ("Upload Failed");
                }

            }
            catch (Exception ex)
            {

                return (ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> FileDownload(string fileName)
        {
            
            string path = _webHostEnviroment.WebRootPath + "\\uploads\\";
            var filePath = path + fileName + ".png";
            if (System.IO.File.Exists(filePath))
            {
                byte[] b = System.IO.File.ReadAllBytes(filePath);
                return File(b, "image/png");
            }

            return null;
        }

    }
}
