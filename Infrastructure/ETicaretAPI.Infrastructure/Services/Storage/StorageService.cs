using ETicaretAPI.Application.Abstractions.Storage;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Infrastructure.Services.Storage
{
    public class StorageService : IStorageService
    {
        private readonly IStorage _stroge;

        public StorageService(IStorage stroge)
        {
            _stroge = stroge;
        }

        public string StorageName { get => _stroge.GetType().Name; }

        public async Task DeleteAsync(string pathOrContainerName, string fileName)
        {
            await _stroge.DeleteAsync(pathOrContainerName, fileName);
        }

        public List<string> GetFiles(string pathOrContainerName)
          => _stroge.GetFiles(pathOrContainerName);

        public bool HasFile(string pathOrContainerName, string filename)
          => _stroge.HasFile(pathOrContainerName, filename);

        public Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files)
          => _stroge.UploadAsync(pathOrContainerName, files);
    }
}
