using Application.Dto;
using Application.ExtensionMethods;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PictureService : IPictureService
    {
        private readonly IPictureRepository _pictureRepository;
        private readonly IFlatRepository _flatRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public PictureService(IPictureRepository pictureRepository, 
            IFlatRepository flatRepository, IMapper mapper, ILogger logger)
        {
            _pictureRepository = pictureRepository;
            _flatRepository = flatRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<PictureDto> AddPictureToFlatAsync(int flatId, IFormFile file)
        {
            var flat = await _flatRepository.GetFlatByIdAsync(flatId);
            var existingPictures = await _pictureRepository.GetByFlatIdAsync(flatId);

            var picture = new Picture()
            {
                Flats = new List<Flat> { flat },
                Name = file.FileName,
                Image = file.GetBytes(),
                Main = existingPictures.Count() == 0 ? true : false
            };

            _logger.LogDebug($"Add new picture to flat with ID: {flatId}");
            var result = await _pictureRepository.AddAsync(picture);
            return _mapper.Map<PictureDto>(result);
        }

        public async Task DeletePictureAsync(int id)
        {
            _logger.LogDebug($"Delete picture with ID: {id}");
            var picture = await _pictureRepository.GetPictureByIdAsync(id);
            await _pictureRepository.DeleteAsync(picture);
        }

        public async Task<PictureDto> GetPictureByIdAsync(int id)
        {
            _logger.LogDebug($"Get picture by ID: {id}");
            var picture = await _pictureRepository.GetByFlatIdAsync(id);
            return _mapper.Map<PictureDto>(picture);
        }

        public async Task<IEnumerable<PictureDto>> GetPicturesByFlatIdAsync(int flatId)
        {
            _logger.LogDebug($"Get picture by flat: {flatId}");
            var pictures = await _pictureRepository.GetPictureByIdAsync(flatId);
            return _mapper.Map<IEnumerable<PictureDto>>(pictures);
        }
    }
}
