using TodoLibrary.Data;
using TodoLibrary.DataAccess;

namespace ApiProject.StartupConfig
{
    public static class DIExtensions
    {
        public static void AddStandardServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }

        public static void AddCustomServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
            builder.Services.AddSingleton<ITodoData, TodoData>();
        }

        public static void AddAuthServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddAuthorization(opts => opts.AddAuthorizationOptions());
            builder.Services.AddAuthentication("Bearer")
                .AddJwtBearer(opts => opts.AddJwtBearerOptions(builder));
        }

        public static void AddHealthChecksServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddHealthChecks()
                .AddSqlServer(builder.Configuration.GetConnectionString("SqlConnectionString"));
        }
    }
}
