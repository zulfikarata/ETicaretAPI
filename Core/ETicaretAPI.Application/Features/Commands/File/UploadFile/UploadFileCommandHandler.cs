using ETicaretAPI.Application.Abstractions.Services;
using ETicaretAPI.Application.Abstractions.Storage;
using ETicaretAPI.Application.DTOs.File;
using ETicaretAPI.Application.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Features.Commands.File.UploadFile
{
    public class UploadFileCommandHandler : IRequestHandler<UploadFileCommandRequest, UploadFileCommandResponse>
    {
        readonly IStorageService _storageService;
        readonly IFileReadRepository _fileReadRepository;
        readonly IFileWriteRepository _fileWriteRepository;

        public UploadFileCommandHandler(IStorageService storageService, IFileReadRepository fileReadRepository, IFileWriteRepository fileWriteRepository)
        {
            _storageService = storageService;
            _fileReadRepository = fileReadRepository;
            _fileWriteRepository = fileWriteRepository;
        }

        public async Task<UploadFileCommandResponse> Handle(UploadFileCommandRequest request, CancellationToken cancellationToken)
        {
            List<(string fileName, string pathOrContainerName)> result = await _storageService.UploadAsync("photo-images", request.Files);


            Domain.Entities.File file = await _fileReadRepository.GetByIdAsync(request.Id);


            await _fileWriteRepository.AddRangeAsync(result.Select(r => new Domain.Entities.ImageFile
            {
                FileName = r.fileName,
                Path = r.pathOrContainerName,
                Storage = _storageService.StorageName,
                Files = new List<Domain.Entities.File>() { file }
            }).ToList());

            await _fileWriteRepository.SaveAsync();

            return new();
        }
    }
}
