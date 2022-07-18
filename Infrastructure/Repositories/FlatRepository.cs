using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class FlatRepository : IFlatRepository
    {
        private static readonly ISet<Flat> _flats = new HashSet<Flat>()
        {
            new Flat(1, "Title 1", "Description 1", 22.5, 1, 1600, "Pełna własność", 2,
                "Wykończone", "brak", "brak", "miejskie"),
        new Flat(2, "Title 2", "Description 2", 51.0, 3, 2800, "Pełna własność", 5,
                "Wykończone", "balkon", "parking podziemny", "miejskie")
        };

        public Flat Add(Flat flat)
        {
            flat.Id = _flats.Count() + 1;
            flat.Created = DateTime.UtcNow;
            _flats.Add(flat);
            return flat;
        }

        public void Delete(Flat flat)
        {
            _flats.Remove(flat);
        }

        public IEnumerable<Flat> GetAllFlats()
        {
            return _flats;
        }

        public Flat GetFlatById(int id)
        {
            return _flats.SingleOrDefault(x => x.Id == id);
        }

        public void Update(Flat flat)
        {
            flat.LastModified = DateTime.UtcNow;
        }
    }
}
