using Serilog;

namespace Nackademin_Episerver
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var s = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var t = s;


            Log.Logger = new LoggerConfiguration()
           .ReadFrom.Configuration(Configuration).WriteTo.Console().CreateLogger();

            CreateHostBuilder(args).Build().Run();
        } 

        public static IConfiguration Configuration { get; } =
        new ConfigurationBuilder()
        .AddJsonFile("appSettings.json", false, true)
        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true, true)
        .AddJsonFile($"appsettings.{Environment.MachineName}.json", true, true)
        .AddEnvironmentVariables()
        .Build();

        public static IHostBuilder CreateHostBuilder(string[] args) =>

         Host.CreateDefaultBuilder(args)
             .ConfigureCmsDefaults()
             .UseSerilog()
             .ConfigureAppConfiguration((ctx, builder) =>
             {
                 builder.AddConfiguration(Configuration);
             })
             .ConfigureWebHostDefaults(webBuilder =>
             {
                 webBuilder.UseStartup<Startup>();
             });
    }
}
