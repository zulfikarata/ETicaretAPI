﻿using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IFileWriteRepository : IWriteRepository<Domain.Entities.File>
    {
        Task AddRangeAsync(List<ImageFile> imageFiles);
    }
}
