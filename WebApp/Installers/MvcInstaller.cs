﻿using Application;
using Application.Interfaces;
using Application.Mappings;
using Application.Services;
using Domain.Interfaces;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Middlewares;

namespace WebApp.Installers
{
    public class MvcInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplication();
            services.AddInfrastructure();
            services.AddControllers();
            services.AddMemoryCache();
            services.AddScoped<ErrorHandlingMiddleware>();
        }
    }
}
