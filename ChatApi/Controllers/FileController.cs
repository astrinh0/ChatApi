using ChatApi.Infrastructure.Data.Models;
using ChatApi.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ChatApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class FileController : Controller
    {
        private readonly IFileService _fileService;


        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [Route("/FileUpload")]
        [HttpPost]
        public async Task<string> FileUpload([FromForm] FileUpload fileUpload)
        {
            try
            {
                return (_fileService.UploadFile(fileUpload));
            }
            catch (Exception ex)
            {

                return (ex.Message);
            }
        }

        [Route("/GetAllFiles")]
        [HttpGet]
        public List<string> GetAllFiles()
        {
            return _fileService.ListAllFiles();
        }

        [Route("/FileDownload")]
        [HttpGet]
        public async Task<IActionResult> FileDownload(string fileName)
        {

            var aux = _fileService.FileDownload(fileName);

           return File(aux, "image/png");
            
        }

    }
}
