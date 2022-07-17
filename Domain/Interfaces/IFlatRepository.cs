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
        IEnumerable<Flat> GetAllFlats();
        Flat GetFlatById(int id);
        Flat Add(Flat flat);
        void Update(Flat flat);
        void Delete(Flat flat);
    }
}
