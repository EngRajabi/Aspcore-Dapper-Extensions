using Microsoft.Extensions.DependencyInjection;

namespace AspcoreDapperExtensions
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection AddDapper(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IDapperSqlConnection>(r => new DapperSqlConnection(connectionString));
            return services;
        }
    }
}