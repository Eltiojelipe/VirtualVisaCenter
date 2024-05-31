using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace VirtualVisaCenterWEB.Auth
{
    public class AuthenticationProviderTest : AuthenticationStateProvider
    {
        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            
            var anonimous = new ClaimsIdentity();
            var oapUser = new ClaimsIdentity(new List<Claim> 
        { 
            new Claim("FirstName", "Sebastian"),
            new Claim("LastName", "D"),
            new Claim(ClaimTypes.Name, "sebasdago.@gmail.com"),
            new Claim(ClaimTypes.Role, "Admin")

        },
);
            return await Task.FromResult(new AuthenticationState(new ClaimsPrincipal(oapUser)));
        }
    }
}

