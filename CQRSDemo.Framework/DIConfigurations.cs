using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSDemo.Framework
{
    public static class DIConfigurations
    {
        public static void ConfigureDI(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DIConfigurations));
        }
    }
}
