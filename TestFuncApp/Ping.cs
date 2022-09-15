using MNP.ServiceFabric.Shared.FunctionsMiddleware.Auth;

namespace TestFuncApp;

/// <summary>
/// Demo function allowing anonymous access to "ping" endpoint
/// </summary>
public class Ping
{
	private readonly ILogger _logger;
	public Ping(ILoggerFactory loggerFactory) => _logger = loggerFactory.CreateLogger<Ping>();


	[Function("Ping")]
	[AllowAnonymous]
	public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "ping")] HttpRequestData req)
	{
		_logger.LogInformation("Received Ping request");
		return req.CreateResponse(HttpStatusCode.OK);
	}
}
