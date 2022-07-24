using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class FlatService : IFlatService
    {
        private readonly IFlatRepository _flatRepository;
        private readonly IMapper _mapper;

        public FlatService(IFlatRepository flatRepository, IMapper mapper)
        {
            _flatRepository = flatRepository;
            _mapper = mapper;
        }

        public async Task<FlatDto> AddNewFlatAsync(CreateFlatDto flat)
        {
            if(string.IsNullOrEmpty(flat.Title))
            {
                throw new Exception("Title is empty");
            }

            var newFlat = _mapper.Map<Flat>(flat);
            await _flatRepository.AddAsync(newFlat);

            return _mapper.Map<FlatDto>(newFlat);
        }

        public async Task DeleteFlatAsync(int id)
        {
            var flat = await _flatRepository.GetFlatByIdAsync(id);
            await _flatRepository.DeleteAsync(flat);
        }

        public async Task<IEnumerable<FlatDto>> GetAllFlatsAsync()
        {
            var flats = await _flatRepository.GetAllFlatsAsync();
            return _mapper.Map<IEnumerable<FlatDto>>(flats);
        }

        public async Task<FlatDto> GetFlatByIdAsync(int id)
        {
            var flat = await _flatRepository.GetFlatByIdAsync(id);
            return _mapper.Map<FlatDto>(flat);
        }

        public async Task UpdateFlatAsync(UpdateFlatDto updateFlat)
        {
            var existingFlat = await _flatRepository.GetFlatByIdAsync(updateFlat.Id);
            var flat = _mapper.Map(updateFlat, existingFlat);
            await _flatRepository.UpdateAsync(flat);
        }
    }
}
