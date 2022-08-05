using Application.Dto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IPictureService
    {
        Task<PictureDto> GetPictureByIdAsync(int id);
        Task<IEnumerable<PictureDto>> GetPicturesByFlatIdAsync(int flatId);
        Task<PictureDto> AddPictureToFlatAsync(int flatId, IFormFile file);
        Task DeletePictureAsync(int id);
    }
}
