using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Process.Filters
{
    public class BearerAuthorizationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            HttpRequestMessage request = actionContext.Request;
            AuthenticationHeaderValue authorization = request.Headers.Authorization;

            if(authorization == null)
            {
                actionContext.Response = request.CreateResponse(HttpStatusCode.Unauthorized, "Missing Credentials");
            }

            if(authorization.Scheme.ToLowerInvariant() != "bearer" && authorization.Scheme.ToLowerInvariant() != "basic")
            {
                actionContext.Response = request.CreateResponse(HttpStatusCode.BadRequest, "Wrong Sheme.");
            }

            if (String.IsNullOrEmpty(authorization.Parameter))
            {
                actionContext.Response = request.CreateResponse(HttpStatusCode.Unauthorized, "Missing Credentials");
            }

            base.OnAuthorization(actionContext);
        }
    }
}