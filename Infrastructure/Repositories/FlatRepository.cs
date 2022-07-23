using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
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

        public Flat Add(Flat flat)
        {
            flat.Id = _context.Flats.Count() + 1;
            flat.Created = DateTime.UtcNow;
            _context.Flats.Add(flat);
            _context.SaveChanges();
            return flat;
        }

        public void Delete(Flat flat)
        {
            _context.Flats.Remove(flat);
            _context.SaveChanges();
        }

        public IEnumerable<Flat> GetAllFlats()
        {
            return _context.Flats;
        }

        public Flat GetFlatById(int id)
        {
            return _context.Flats.SingleOrDefault(x => x.Id == id);
        }

        public void Update(Flat flat)
        {
            flat.LastModified = DateTime.UtcNow;
            _context.Flats.Update(flat);
            _context.SaveChanges();
        }
    }
}
