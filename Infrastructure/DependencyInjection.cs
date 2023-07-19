using AppDomain.Entities;
using AppDomain.Repositories;
using Infrastructure.Options;
using Infrastructure.Persistance;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Npgsql;
using System.Data;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfrastructureServices(this IServiceCollection services, string connectionString  /*IConfiguration configuration*/)
        {
            services.AddTransient<IRepository<Product>, ProductRepository>();

            services.AddTransient<IDbConnection>(db => new NpgsqlConnection(connectionString));
            //services.AddTransient<IDbConnection>(db => new NpgsqlConnection(
            //        configuration.GetConnectionString("DefautConnectionString")));
        }
    }
}
