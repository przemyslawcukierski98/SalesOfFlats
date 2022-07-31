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
    }
}
