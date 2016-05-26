using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNet.Http.Authentication;
using SolutionsAI.Domain;

namespace SolutionsAI.Utility
{
    public static class AuthorizationUtility
    {
        const string Issuer = "http://solutionsai.azurewebsites.net";

        public static void SignIn(AuthenticationManager authenticationManager, User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.EMail, ClaimValueTypes.String, Issuer)
            };
            var userIdentity = new ClaimsIdentity("Email");
            userIdentity.AddClaims(claims);
            var userPrincipal = new ClaimsPrincipal(userIdentity);

            authenticationManager.SignInAsync("Cookie", userPrincipal,
                new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                    IsPersistent = false,
                    AllowRefresh = true
                }).Wait();
        }

        public static bool HasAuthority(this ClaimsPrincipal claimsPrincipal, string email)
        {
            return claimsPrincipal.Claims.Any(claim => claim.Type == ClaimTypes.Email && claim.Value == email);
        }
    }
}
