using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MNP.ServiceFabric.Shared.FunctionsMiddleware;

// Set up and run host:
using var host = new HostBuilder()
	.ConfigureFunctionsWorkerDefaults(builder =>
	{
		builder.UseAuthMiddleware(
			Environment.GetEnvironmentVariable("OpenIdMetadataAddress") ?? throw new ArgumentException("OpenIdMetadataAddress not configured"),
			Environment.GetEnvironmentVariable("JwtAudience") ?? throw new ArgumentException("JwtAudience not configured"));
	})
	.ConfigureServices(services =>
	{
		services.AddApplicationInsightsTelemetryWorkerService(opts => opts.DependencyCollectionOptions.EnableLegacyCorrelationHeadersInjection = true);
	})
	.Build();
await host.RunAsync();


[ExcludeFromCodeCoverage]
#pragma warning disable S1118 // Utility classes should not have public constructors
#pragma warning disable S3903 // Types should be defined in named namespaces
internal partial class Program { }
#pragma warning restore S3903 // Types should be defined in named namespaces
#pragma warning restore S1118 // Utility classes should not have public constructors