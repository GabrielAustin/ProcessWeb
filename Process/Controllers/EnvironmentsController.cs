using Process.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace Process.Controllers
{
    public class EnvironmentsController : BaseApiController
    {
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            List<DomainModel> envs = TheEnvironmentFactory.GetEnvironments();
            response = Request.CreateResponse(HttpStatusCode.OK, envs);
            TheEnvironmentFactory.Release();
            return response;
        }

        public HttpResponseMessage Get([FromUri]string Environment)
        {
            HttpResponseMessage response = new HttpResponseMessage();

            if (TheEnvironmentFactory.VerifyDomain(Environment))
            {
                response = Request.CreateResponse(HttpStatusCode.OK, true);
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, false);
            }

            return response;
        }
    }
}