using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEDC.Lamazon.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Lamazon.Services.Helpers
{
    public static class DIModule
    {
        public static IServiceCollection RegisterModule(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<LamazonDbContext>
                (options => options.UseSqlServer(connectionString));

            return services;
        }
    }
}
