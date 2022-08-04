using Application.Dto;
using Application.ExtensionMethods;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
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

        public PictureService(IPictureRepository pictureRepository, 
            IFlatRepository flatRepository, IMapper mapper)
        {
            _pictureRepository = pictureRepository;
            _flatRepository = flatRepository;
            _mapper = mapper;
        }

        public async Task<PictureDto> AddPictureToPostAsync(int flatId, IFormFile file)
        {
            var flat = await _flatRepository.GetFlatByIdAsync(flatId);

            var picture = new Picture()
            {
                Flats = new List<Flat> { flat },
                Name = file.Name,
                Image = file.GetBytes(),
                Main = true
            };

            var result = await _pictureRepository.AddAsync(picture);
            return _mapper.Map<PictureDto>(result);
        }
    }
}
