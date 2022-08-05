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
        Task<PictureDto> AddPictureToPostAsync(int flatId, IFormFile file);
        Task<IEnumerable<PictureDto>> GetPicturesByFlatIdAsync(int flatId);
        Task<PictureDto> AddPictureToFlatAsync(int flatId, IFormFile file);
        Task DeletePictureAsync(int id);
    }
}
