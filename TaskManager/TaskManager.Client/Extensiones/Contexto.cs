using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;

public interface IAuthService
{
    Task SignInAsync(ClaimsPrincipal principal);
    Task SignOutAsync();
}

public class AuthService : IAuthService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuthService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task SignInAsync(ClaimsPrincipal principal)
    {
        await _httpContextAccessor.HttpContext.SignInAsync(principal);
    }

    public async Task SignOutAsync()
    {
        await _httpContextAccessor.HttpContext.SignOutAsync();
    }
}
