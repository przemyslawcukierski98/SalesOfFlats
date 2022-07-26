using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFlatRepository
    {
        Task<IEnumerable<Flat>> GetAllFlatsAsync(int pageNumber, int pageSize);
        Task<Flat> GetFlatByIdAsync(int id);
        Task<int> GetAllCountAsync();
        Task<Flat> AddAsync(Flat flat);
        Task UpdateAsync(Flat flat);
        Task DeleteAsync(Flat flat);
    }
}
