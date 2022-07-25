using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class FlatRepository : IFlatRepository
    {
        private readonly SalesContext _context;

        public FlatRepository(SalesContext context)
        {
            _context = context;
        }

        public async Task<Flat> AddAsync(Flat flat)
        {
            flat.Created = DateTime.UtcNow;
            _context.Flats.Add(flat);
            await _context.SaveChangesAsync();
            return flat;
        }

        public async Task DeleteAsync(Flat flat)
        {
            _context.Flats.Remove(flat);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Flat>> GetAllFlatsAsync(int pageNumber, int pageSize)
        {
            return await _context.Flats.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<Flat> GetFlatByIdAsync(int id)
        {
            return await _context.Flats.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Flat flat)
        {
            flat.LastModified = DateTime.UtcNow;
            _context.Flats.Update(flat);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }
    }
}
