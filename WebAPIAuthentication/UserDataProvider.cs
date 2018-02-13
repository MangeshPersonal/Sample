using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace WebAPIAuthentication
{
    internal class UserDataProvider : IUserData
    {
        public string UserID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public  string GetUserID(HttpContext httpContext)
        {
            var ClaimsList = httpContext.User.Claims;
            foreach (var VARIABLE in ClaimsList)
            {
                if (VARIABLE.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/sid")
                {
                    return VARIABLE.Value;
                }
            }

            return "";
        }
    }
}