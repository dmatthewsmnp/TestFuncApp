using MNP.ServiceFabric.Shared.FunctionsMiddleware.Auth;
using TestFuncApp.Authorization;

namespace TestFuncApp;

public class GetRole
{
	private readonly ILogger _logger;
	public GetRole(ILoggerFactory loggerFactory) => _logger = loggerFactory.CreateLogger<GetClaim>();


	[Function("GetRole")]
	[RequireRole("%RoleName%")]
	public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "role")] HttpRequestData req, FunctionContext context)
		=> req.CreateResponse(HttpStatusCode.OK);
}
