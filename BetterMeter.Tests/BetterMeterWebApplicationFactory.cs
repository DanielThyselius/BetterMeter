using BetterMeter.Core.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace BetterMeter.Tests;

public class BetterMeterWebApplicationFactory<T> : WebApplicationFactory<T> where T : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            // Remove the existing database registration from the container
            var dbDescriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                    typeof(IDatabase));

            services.Remove(dbDescriptor);

            // Add our test database to the container
            services.AddSingleton<IDatabase, TestDatabase>();
        });
    }
}
