using Microsoft.Extensions.DependencyInjection;

namespace AspcoreDapperExtensions
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection AddDapper(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IDapperSqlConnection>(r => new DapperSqlConnection(connectionString));

            services.AddScoped(typeof(IDapperRepository<>), typeof(DapperRepository<>));
            return services;
        }
    }
}