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
    public class PictureRepository : IPictureRepository
    {
        private static SalesContext _context;

        public PictureRepository(SalesContext context)
        {
            _context = context;
        }

        public async Task<Picture> AddAsync(Picture picture)
        {
            var createdPicture = await _context.AddAsync(picture);
            await _context.SaveChangesAsync();
            return createdPicture.Entity;
        }

        public async Task DeleteAsync(Picture picture)
        {
            _context.Pictures.Remove(picture);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Picture>> GetByFlatIdAsync(int flatId)
        {
            return await _context.Pictures.Include(x => x.Flats)
                .Where(x => x.Flats.Select(x => x.Id).Contains(flatId)).ToListAsync();
        }

        public async Task<Picture> GetPictureByIdAsync(int pictureId)
        {
            return await _context.Pictures.SingleOrDefaultAsync(x => x.Id == pictureId);
        }
    }
}
