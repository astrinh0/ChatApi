using ChatApi.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Services
{
    public interface IFileService
    {
        string UploadFile(FileUpload fileUpload);
        byte[] FileDownload(string fileName);

        List<string> ListAllFiles();
    }
}
