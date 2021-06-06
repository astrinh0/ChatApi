using ChatApi.Infrastructure.Data.Models;
using System.Collections.Generic;

namespace ChatApi.Infrastructure.Services
{
    public interface IFileService
    {
        string UploadFile(FileUpload fileUpload, string ownerName);
        byte[] FileDownload(string fileName);

        string FileDelete(string fileName);
        List<string> ListAllFiles();
    }
}
