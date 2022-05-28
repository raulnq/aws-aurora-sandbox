using Amazon.RDS.Util;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

namespace aws_aurora_sandbox_app
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPostgreSQL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                var connectionString = configuration["ConnectionString"];
                options.UseNpgsql(connectionString, npgsqlOption => { npgsqlOption.UseAwsIamAuthentication(); });
                options.UseLowerCaseNamingConvention();
            });

            return services;
        }

        public static NpgsqlDbContextOptionsBuilder UseAwsIamAuthentication(this NpgsqlDbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ProvidePasswordCallback(RequestAwsIamAuthToken);
            return optionsBuilder;
        }

        static string RequestAwsIamAuthToken(string host, int port, string database, string username)
        {
            return RDSAuthTokenGenerator.GenerateAuthToken(host, port, username);
        }
    }
}