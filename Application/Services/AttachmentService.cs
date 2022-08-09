using Application.Dto.Attachments;
using Application.ExtensionMethods;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AttachmentService : IAttachmentService
    {
        private readonly IAttachmentRepository _attachmentRepository;
        private readonly IFlatRepository _flatRepository;
        private readonly IMapper _mapper;

        public AttachmentService(IAttachmentRepository attachmentRepository, 
            IFlatRepository flatRepository, IMapper mapper)
        {
            _attachmentRepository = attachmentRepository;
            _flatRepository = flatRepository;
            _mapper = mapper;
        }

        public async Task<AttachmentDto> AddAttachmentToFlatAsync(int flatId, IFormFile file)
        {
            var flat = await _flatRepository.GetFlatByIdAsync(flatId);

            var attachment = new Attachment()
            {
                Flats = new List<Flat> { flat },
                Name = file.FileName,
                Path = file.SaveFile()
            };

            var result = await _attachmentRepository.AddAsync(attachment);
            return _mapper.Map<AttachmentDto>(result);
        }

        public Task DeleteAttachmentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<DownloadAttachmentDto> DownloadAttachmentByIdAsync(int id)
        {
            var attachment = await _attachmentRepository.GetByIdAsync(id);

            return new DownloadAttachmentDto()
            {
                Name = attachment.Name,
                Content = File.ReadAllBytes(attachment.Path)
            };
        }

        public async Task<IEnumerable<AttachmentDto>> GetAttachmentsByFlatIdAsync(int flatId)
        {
            var attachment = await _attachmentRepository.GetByFlatIdAsync(flatId);
            return _mapper.Map<IEnumerable<AttachmentDto>>(attachment);
        }
    }
}
