using Application.Dto;
using Application.Interfaces;
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

        public FlatService(IFlatRepository flatRepository)
        {
            _flatRepository = flatRepository;
        }

        public IEnumerable<FlatDto> GetAllFlats()
        {
            var flats = _flatRepository.GetAllFlats();
            return flats.Select(flat => new FlatDto 
            { 
                Id = flat.Id,
                Title = flat.Title,
                Content = flat.Description
            });
        }

        public FlatDto GetFlatById(int id)
        {
            var flat = _flatRepository.GetFlatById(id);
            return new FlatDto()
            {
                Id = flat.Id,
                Title = flat.Title,
                Content = flat.Description
            };
        }
    }
}
