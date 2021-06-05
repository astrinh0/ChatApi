using ChatApi.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApi.Infrastructure.Repos
{
    public interface IFileRepository
    {
        File AddFile(int ownerId, DateTime expireDate, string fileName);
        Task CheckTimeOfFile();
    }
}
