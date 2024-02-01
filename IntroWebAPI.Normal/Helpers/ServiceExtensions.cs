
namespace IntroWebAPI.Normal;

public static class ServiceExtensions
{
    /// <summary>
    /// Replaces Swagger UI configuration 
    /// builder.Services.AddEndpointsApiExplorer();
    /// builder.Services.AddSwaggerGen();
    /// </summary>
    /// <param name="services">IServiceCollection with add Swagger UI options</param>
    public static void ConfigureSwagger(this IServiceCollection services)
    {
        // // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        // builder.Services.AddEndpointsApiExplorer();
        // builder.Services.AddSwaggerGen();

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen();
    }

    public static IServiceCollection ConfigureControllers(this IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            options.ReturnHttpNotAcceptable = true;
        }).AddXmlDataContractSerializerFormatters();        

        return services;
    }

    public static void ConfigureCors(this IServiceCollection services, string policyName)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(policyName,
                builder => builder.AllowAnyOrigin()
                    //.WithOrigins("https://localhost:75236",
                    //             "https://blog.azure.com")
                    .WithMethods("PUT", "GET")
                    .AllowAnyHeader()
                    .AllowCredentials());

            options.AddDefaultPolicy(
                policy =>
                {
                    policy.WithOrigins("https://localhost:75236", "https://blog.azure.com");
                });
        });
    }

    public static void ConfigureDb(this IServiceCollection services, IConfiguration configuration)
    {

    }
}