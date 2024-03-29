﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPictureRepository
    {
        Task<Picture> AddAsync(Picture picture);
        Task<IEnumerable<Picture>> GetByFlatIdAsync(int flatId);
        Task<Picture> GetPictureByIdAsync(int pictureId);
        Task DeleteAsync(Picture picture);
    }
}
