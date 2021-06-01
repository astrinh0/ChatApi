using ChatApi.Infrastructure.Data.Models;
using ChatApi.Infrastructure.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Services
{
    public class FileService : IFileService
    {
        public static IWebHostEnvironment _webHostEnviroment;
      


        public FileService(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnviroment = webHostEnvironment;
        }

        public string UploadFile(FileUpload fileUpload)
        {
            if (fileUpload.Files.Length > 0)
            {
                var path = _webHostEnviroment.WebRootPath + "\\uploads\\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                using (FileStream fileStream = File.Create(path + fileUpload.Files.FileName))
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

        public List<string> ListAllFiles()
        {
            var path = _webHostEnviroment.WebRootPath + "\\uploads\\";
            var aux = Directory.GetFiles(path).ToList();

            return aux;
        }



        public byte[] FileDownload(string fileName)
        {

            string path = _webHostEnviroment.WebRootPath + "\\uploads\\";
            var filePath = path + fileName + ".png";
            if (File.Exists(filePath))
            {
                byte[] b = File.ReadAllBytes(filePath);
                return b;
            }

            return null;
        }


        public string FileDelete(string fileName)
        {

            string path = _webHostEnviroment.WebRootPath + "\\uploads\\";
            var filePath = path + fileName + ".png";
            if (File.Exists(filePath))
            {
                File.Delete(path);
                return ("File deleted!");
            }

            return ("File delete error!");
        }
    }
}
