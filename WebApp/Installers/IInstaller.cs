using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Installers
{
    public interface IInstaller
    {
        void InstallServices(IServiceCollection serviceCollection, IConfiguration configuration);
    }
}
