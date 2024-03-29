﻿using Domain.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IAttachmentRepository, AttachmentRepository>();
            services.AddScoped<IFlatRepository, FlatRepository>();
            services.AddScoped<IPictureRepository, PictureRepository>();

            return services;
        }
    }
}
