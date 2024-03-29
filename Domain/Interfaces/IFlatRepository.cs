﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IFlatRepository
    {
        Task<IEnumerable<Flat>> GetAllFlatsAsync(int pageNumber, int pageSize, string sortField, bool ascending, string filterBy);
        IQueryable<Flat> GetAllFlatsAsync();
        Task<Flat> GetFlatByIdAsync(int id);
        Task<int> GetAllCountAsync(string filterBy);
        Task<Flat> AddAsync(Flat flat);
        Task UpdateAsync(Flat flat);
        Task DeleteAsync(Flat flat);
    }
}
