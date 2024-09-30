using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.DTOs.File
{
    public class UploadFileResponse
    {
        public string Path { get; set; }
        public IFormFileCollection Files { get; set; }
    }
}
