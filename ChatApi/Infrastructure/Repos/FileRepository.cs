using ChatApi.Infrastructure.Data.Models;
using ChatApi.Infrastructure.DB;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Repos
{
    public class FileRepository : IFileRepository
    {
        private readonly DataContext _context;
        private static IWebHostEnvironment _webHostEnvironment;

        public FileRepository(DataContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        public File AddFile(int ownerId, DateTime expireDate, string fileName)
        {
            var file = new File
            {
                CreatedAt = DateTime.UtcNow,
                ChangedAt = null,
                ExpireAt = expireDate,
                OwnerId = ownerId,
                Name = fileName,
                Active = Models.Enums.EnumFlag.Y
            };

            _context.Files.Add(file);
            _context.SaveChanges();
            return file;
        }

        public async Task CheckTimeOfFile()
        {
            var files = _context.Files.ToList();
            string path = _webHostEnvironment.WebRootPath + "\\uploads\\";

            if (files != null)
            {
                foreach (var file in files)
                {
                    if (file.ExpireAt < DateTime.UtcNow && file.Active == Models.Enums.EnumFlag.Y)
                    {

                        file.Active = Models.Enums.EnumFlag.N;
                        var filePath = path + file.Name + ".png";
                        _context.Files.Update(file);
                        _context.SaveChanges();
                        System.IO.File.SetAttributes(filePath, System.IO.FileAttributes.Normal);
                        System.IO.File.Delete(filePath);

                    }
                }
            }

        }
    }
}
