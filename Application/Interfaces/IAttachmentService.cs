﻿using Application.Dto.Attachments;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IAttachmentService
    {
        Task<IEnumerable<AttachmentDto>> GetAttachmentsByFlatIdAsync(int flatId);
        Task<DownloadAttachmentDto> DownloadAttachmentByIdAsync(int id);
        Task<AttachmentDto> AddAttachmentToFlatAsync(int postId, IFormFile file);
    }
}
