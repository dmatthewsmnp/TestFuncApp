using System.Security.Claims;
using TestFuncApp.Authorization;

namespace TestFuncApp;

public class GetClaim
{
	private readonly ILogger _logger;
	public GetClaim(ILoggerFactory loggerFactory) => _logger = loggerFactory.CreateLogger<GetClaim>();


	[Function("GetClaim")]
	[RequireClaim("clientAccess", "b64cda32-48a4-4a31-bbb8-7c3b359dc796")]
	public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "claim")] HttpRequestData req, FunctionContext context)
	{
		var claimsPrincipal = context.Features.Get<ClaimsPrincipal>() ?? throw new InvalidOperationException("No ClaimsPrincipal received");

		_logger.LogInformation("Received Get request from {principal}", claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value);
		return req.CreateResponse(HttpStatusCode.OK);
	}
}
