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
        IEnumerable<FlatDto> GetAllFlats();
        FlatDto GetFlatById(int id);
        FlatDto AddNewFlat(CreateFlatDto flat);
        void UpdateFlat(UpdateFlatDto updateFlat);
    }
}
