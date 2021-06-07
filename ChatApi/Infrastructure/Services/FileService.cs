using ChatApi.Infrastructure.Data.Models;
using ChatApi.Infrastructure.Repos;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ChatApi.Infrastructure.Services
{
    public class FileService : IFileService
    {
        public static IWebHostEnvironment _webHostEnviroment;
        private readonly IUserRepository _userRepository;
        private readonly IFileRepository _fileRepository;


        public FileService(IWebHostEnvironment webHostEnvironment, IUserRepository userRepository, IFileRepository fileRepository)
        {
            _webHostEnviroment = webHostEnvironment;

            _userRepository = userRepository;

            _fileRepository = fileRepository;
        }

        public string UploadFile(FileUpload fileUpload, string ownerName)
        {
            if (fileUpload.Files.Length > 0)
            {
                var path = _webHostEnviroment.WebRootPath + "\\uploads\\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                using (FileStream fileStream = System.IO.File.Create(path + fileUpload.Files.FileName))
                {
                    fileUpload.Files.CopyTo(fileStream);
                    fileStream.Flush();
                    System.IO.File.SetAttributes(path, FileAttributes.Normal);
                    var owner = _userRepository.FindUserByUsername(ownerName);

                    var expireDate = DateTime.UtcNow.AddSeconds(30);

                    
                    var file = _fileRepository.AddFile(owner.Id, expireDate, fileUpload.Files.FileName.Replace(".png", ""));

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
            if (System.IO.File.Exists(filePath))
            {
                byte[] b = System.IO.File.ReadAllBytes(filePath);
                return b;
            }

            return null;
        }


        public string FileDelete(string fileName)
        {

            string path = _webHostEnviroment.WebRootPath + "\\uploads\\";
            var filePath = path + fileName + ".png";
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.SetAttributes(filePath, FileAttributes.Normal);
                System.IO.File.Delete(path);
                _fileRepository.RemoveFile(fileName);
                return ("File deleted!");
            }

            return ("File delete error!");
        }

    }
}
