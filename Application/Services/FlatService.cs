using Application.Dto;
using Application.Interfaces;
using AutoMapper;
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
    }
}
