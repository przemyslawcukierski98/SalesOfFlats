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
    public class AttachmentRepository : IAttachmentRepository
    {
        private readonly SalesContext _context;

        public AttachmentRepository(SalesContext context)
        {
            _context = context;
        }

        public async Task<Attachment> AddAsync(Attachment attachment)
        {
            var createdAttachment = await _context.Attachments.AddAsync(attachment);
            await _context.SaveChangesAsync();
            return createdAttachment.Entity;
        }

        public async Task DeleteAsync(Attachment picture)
        {
            _context.Attachments.Remove(picture);
            await _context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task<IEnumerable<Attachment>> GetByFlatIdAsync(int flatId)
        {
            return await _context.Attachments.Include(x => x.Flats).Where(x => x.Flats.Select(x => x.Id)
            .Contains(flatId))
            .ToListAsync();
        }

        public async Task<Attachment> GetByIdAsync(int id)
        {
            return await _context.Attachments.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
