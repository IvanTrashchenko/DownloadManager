using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using DownloadManager.Service.Contract;
using DownloadManager.Service.Models.Input;
using Microsoft.IdentityModel.Tokens;
using Unity;

namespace DownloadManager.Web.Filter
{
    public class JwtAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                // Get the JWT token from the Authorization header
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(ConfigurationManager.AppSettings["DownloadManager:Token"]);

                try
                {
                    tokenHandler.ValidateToken(authenticationToken, new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    }, out SecurityToken validatedToken);

                    var jwtToken = validatedToken as JwtSecurityToken;
                    var username = jwtToken?.Claims.First(claim => claim.Type == "unique_name")?.Value;

                    if (username != null)
                    {
                        Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                    }
                    else
                    {
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                    }
                }
                catch
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }

    }

}