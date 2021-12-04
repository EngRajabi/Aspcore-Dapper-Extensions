using Microsoft.Extensions.DependencyInjection;

namespace AspcoreDapperExtensions
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection AddDapper(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IDapperSqlConnection>(r => new DapperSqlConnection(connectionString));
            //services.TryAddSingleton<ICompressorProvider, DefaultCompressorProvider>();
            //services.AddSingleton<ICompressor, LZ4Compressor>(_ => new LZ4Compressor(name, level));
            return services;
        }
    }
}