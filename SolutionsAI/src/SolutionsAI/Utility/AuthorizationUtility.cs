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
        private const string Issuer = "http://solutionsai.azurewebsites.net";
        private const string AuthenticationSchema = "Cookie";

        public static void SignIn(AuthenticationManager authenticationManager, User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.EMail, ClaimValueTypes.String, Issuer),
                new Claim(ClaimTypes.UserData, user.Id.ToString(), ClaimValueTypes.Integer32, Issuer)
            };
            var userIdentity = new ClaimsIdentity("Email");
            userIdentity.AddClaims(claims);
            var userPrincipal = new ClaimsPrincipal(userIdentity);

            authenticationManager.SignInAsync(AuthenticationSchema, userPrincipal,
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

        public static int GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            return int.Parse(claimsPrincipal.Claims.First(claim => claim.Type == ClaimTypes.UserData).Value);
        }

        public static string GetUserEmail(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.Claims.First(claim => claim.Type == ClaimTypes.Email).Value;
        }

        public static void SignOut(AuthenticationManager authenticationManager)
        {
            authenticationManager.SignOutAsync(AuthenticationSchema);
        }
    }
}
