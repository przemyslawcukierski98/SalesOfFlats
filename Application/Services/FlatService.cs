using Application.Dto;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger _logger;

        public FlatService(IFlatRepository flatRepository, IMapper mapper,
            ILogger<FlatService> logger)
        {
            _flatRepository = flatRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<FlatDto> AddNewFlatAsync(CreateFlatDto flat)
        {
            _logger.LogDebug($"Add new flat: {flat.Title}, {flat.Description}");

            var newFlat = _mapper.Map<Flat>(flat);
            await _flatRepository.AddAsync(newFlat);

            return _mapper.Map<FlatDto>(newFlat);
        }

        public async Task DeleteFlatAsync(int id)
        { 
            _logger.LogDebug($"Delete flat with ID: {id}");

            var flat = await _flatRepository.GetFlatByIdAsync(id);
            await _flatRepository.DeleteAsync(flat);
        }

        public async Task<IEnumerable<FlatDto>> GetAllFlatsAsync(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy)
        {
            _logger.LogDebug("Get all announcement with flats using filters");
            _logger.LogInformation($"pageNumber: {pageNumber} | pageSize: {pageSize}");

            var flats = await _flatRepository.GetAllFlatsAsync(pageNumber, pageSize, sortField, ascending, filterBy);
            return _mapper.Map<IEnumerable<FlatDto>>(flats);
        }

        public IQueryable<FlatDto> GetAllFlatsAsync()
        { 
            _logger.LogDebug("Get all announcement with flats");

            var flats = _flatRepository.GetAllFlatsAsync();
            return _mapper.ProjectTo<FlatDto>(flats);
        }

        public async Task<int> GetAllFlatsCountAsync(string filterBy)
        {
            _logger.LogDebug("Get number of announcements found using the filter");

            return await _flatRepository.GetAllCountAsync(filterBy);
        }

        public async Task<FlatDto> GetFlatByIdAsync(int id)
        {
            _logger.LogDebug($"Get announcement by ID: {id}");

            var flat = await _flatRepository.GetFlatByIdAsync(id);
            return _mapper.Map<FlatDto>(flat);
        }

        public async Task UpdateFlatAsync(UpdateFlatDto updateFlat)
        {
            _logger.LogDebug($"Update flat with ID: {updateFlat.Id}");

            var existingFlat = await _flatRepository.GetFlatByIdAsync(updateFlat.Id);
            var flat = _mapper.Map(updateFlat, existingFlat);
            await _flatRepository.UpdateAsync(flat);
        }
    }
}
