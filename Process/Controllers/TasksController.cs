using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml;
using Newtonsoft.Json;
using Process.Models;
using System.Net.Http.Headers;

namespace Process.Controllers
{
    public class TasksController : BaseApiController
    {

        [Process.Filters.BearerAuthorization()]
        public HttpResponseMessage Get([FromUri]int id)
        {
            AuthenticationHeaderValue authorization = Request.Headers.Authorization;
            int status = TheProcessFactory.GetSession(authorization.Parameter);
            List<Task> result = TheProcessFactory.GetBasketList(TheModelFactory.Create(new Basket(id)));

            return TheHttpFactory.SetTicket(Request.CreateResponse(
                HttpStatusCode.OK,result),
                TheProcessFactory.SaveSession());
        }

        public void Post()
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}