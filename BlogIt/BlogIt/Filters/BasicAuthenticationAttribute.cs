using BlogIt.Auth;
using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace BlogIt.Filters
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        /// <summary>
        /// Authorization Filter to Check validity of the user.
        /// </summary>
        /// <param name="actionContext">Http Action Context</param>
        /// <returns></returns>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            try
            {
                if (actionContext.Request.Headers.Authorization == null)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
                else
                {
                    string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                    string decodedAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
                    string[] userNamePassArray = decodedAuthenticationToken.Split(':');
                    string userName = userNamePassArray[0];
                    string password = userNamePassArray[1];

                    if (BlogAuth.Login(userName, password))
                    {
                        // storing in thread principle so that on further extension to this app, we can make access to edit/update/delete to owner only.
                        Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(userName), null);
                    }
                    else
                    {
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                    }

                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error Occured: [Method: OnAuthorization] {ex.Message} - {ex.ToString()}");
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                return;
            }
        }
    }
}