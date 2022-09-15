using MNP.ServiceFabric.Shared.FunctionsMiddleware.Auth;
using TestFuncApp.Authorization;

namespace TestFuncApp;

/// <summary>
/// Demo function requiring a specific role to access the "role" endpoint
/// </summary>
public class GetRole
{
	[Function("GetRole")]
	[RequireRole("%RoleName%")]
	public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "role")] HttpRequestData req, FunctionContext context)
		=> req.CreateResponse(HttpStatusCode.OK);
}
