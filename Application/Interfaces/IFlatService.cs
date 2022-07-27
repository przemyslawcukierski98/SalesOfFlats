using Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IFlatService
    {
        Task<IEnumerable<FlatDto>> GetAllFlatsAsync(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy);
        Task<int> GetAllFlatsCountAsync(string filterBy);
        Task<FlatDto> GetFlatByIdAsync(int id);
        Task<FlatDto> AddNewFlatAsync(CreateFlatDto flat);
        Task UpdateFlatAsync(UpdateFlatDto updateFlat);
        Task DeleteFlatAsync(int id);
    }
}
