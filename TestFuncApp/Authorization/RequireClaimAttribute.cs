using System.Security.Claims;
using MNP.ServiceFabric.Shared.FunctionsMiddleware.Auth;

namespace TestFuncApp.Authorization;

/// <summary>
/// Demo attribute for requiring a specific claim
/// </summary>
public class RequireClaimAttribute : AuthorizationRequirementAttribute
{
	private readonly string _claim;
	private readonly string _value;
	public RequireClaimAttribute(string claim, string value)
	{
		_claim = claim;
		_value = value;
	}

	public override Task<bool> Authorize(ClaimsPrincipal user, FunctionContext context, HttpRequestData httpRequestData, CancellationToken cancellationToken = default)
		=> Task.FromResult(user.HasClaim(_claim, _value));
}
