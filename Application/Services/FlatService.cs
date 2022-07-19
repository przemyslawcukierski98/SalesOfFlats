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

        public FlatDto AddNewFlat(CreateFlatDto flat)
        {
            if(string.IsNullOrEmpty(flat.Title))
            {
                throw new Exception("Title is empty");
            }

            var newFlat = _mapper.Map<Flat>(flat);
            _flatRepository.Add(newFlat);

            return _mapper.Map<FlatDto>(newFlat);
        }

        public IEnumerable<FlatDto> GetAllFlats()
        {
            var flats = _flatRepository.GetAllFlats();
            return _mapper.Map<IEnumerable<FlatDto>>(flats);
        }

        public FlatDto GetFlatById(int id)
        {
            var flat = _flatRepository.GetFlatById(id);
            return _mapper.Map<FlatDto>(flat);
        }

        public void UpdateFlat(UpdateFlatDto updateFlat)
        {
            var existingFlat = _flatRepository.GetFlatById(updateFlat.Id);
            var flat = _mapper.Map(updateFlat, existingFlat);
            _flatRepository.Update(flat);
        }
    }
}
