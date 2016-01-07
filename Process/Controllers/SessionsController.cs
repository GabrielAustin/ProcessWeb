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
    public class SessionsController : BaseApiController
    {

        // GET api/<controller>
        [Process.Filters.BearerAuthorization()]
        public HttpResponseMessage Get()
        {
            //Creamos el objeto de 
            HttpResponseMessage response = new HttpResponseMessage();

            //Obtenemos credenciales
            var authorization = Request.Headers.Authorization;
            var credArray = TheHttpFactory.GetCredentials(authorization);
            UserModel userModel = TheModelFactory.Create(credArray);

            //Obtenemos IP
            IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
            string pIp = Convert.ToString(ipEntry.AddressList[1]);

            int establecer = TheProcessFactory.EstablishSession(userModel, pIp);
            int establecio = TheProcessFactory.GetStatus();

            if(establecio == 15140) {

            int status = TheProcessFactory.RecoverSession(userModel, pIp);

            if (status == -1)
            {
                response = TheHttpFactory.SetTicket(Request.CreateResponse(HttpStatusCode.OK),
                    TheProcessFactory.SaveSession());
            }
            else
            {
                response = Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                    Convert.ToString(TheProcessFactory.GetStatus()));
            }

            }
            //Liberamos la memoria ocupada por el motor.
            TheProcessFactory.Release();

            return response;
        }

        // POST api/<controller>
        //[Process.Filters.ForceHttps()]
        [Process.Filters.BearerAuthorization()]
        public HttpResponseMessage Post()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            var authorization = Request.Headers.Authorization;
            var credArray = TheHttpFactory.GetCredentials(authorization);
            UserModel userModel = TheModelFactory.Create(credArray);

            IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
            string pIp = Convert.ToString(ipEntry.AddressList[1]);

            int status = TheProcessFactory.EstablishSession(userModel, pIp);

            if (status == -1)
            {
                response = TheHttpFactory.SetTicket(Request.CreateResponse(
                    HttpStatusCode.Created,
                    TheProcessFactory.GetStatus()),
                    TheProcessFactory.SaveSession());

            }
            else
            {
                response = Request.CreateErrorResponse(HttpStatusCode.Conflict,
                    Convert.ToString(TheProcessFactory.GetStatus()));
            }

            TheProcessFactory.Release();

            return response;
        }

        // PUT api/<controller>/5
        [Process.Filters.BearerAuthorization()]
        public HttpResponseMessage Put()
        {
            HttpResponseMessage response = new HttpResponseMessage();
            AuthenticationHeaderValue authorization = Request.Headers.Authorization;

            //Obtenemos credenciales
            var credArray = TheHttpFactory.GetCredentials(authorization);
            UserModel userModel = TheModelFactory.Create(credArray);

            //Obtenemos IP
            IPHostEntry ipEntry = Dns.GetHostEntry(Dns.GetHostName());
            string pIp = Convert.ToString(ipEntry.AddressList[1]);

            int establish = TheProcessFactory.EstablishSession(userModel, pIp);
            int established = TheProcessFactory.GetStatus();

            if (established == 15140)
            {

                int destroy = TheProcessFactory.DestroySession(userModel, pIp);

                if (destroy == -1)
                {
                    response = TheHttpFactory.SetTicket(Request.CreateResponse(HttpStatusCode.OK),
                        TheProcessFactory.SaveSession());
                }
                else
                {
                    response = Request.CreateErrorResponse(HttpStatusCode.BadRequest,
                        Convert.ToString(TheProcessFactory.GetStatus()));
                }

            }

            TheProcessFactory.Release();
            return response;
        }

        // DELETE api/<controller>/5
        [Process.Filters.BearerAuthorization()]
        public HttpResponseMessage Delete()
        {
            HttpResponseMessage response = new HttpResponseMessage();

            AuthenticationHeaderValue authorization = Request.Headers.Authorization;

            int status = TheProcessFactory.GetSession(authorization.Parameter);

            if (status != 0)
            {
                status = TheProcessFactory.CloseSession();
                if (status == -1)
                {
                    response = Request.CreateResponse(HttpStatusCode.OK,
                        "Session destroyed.");
                }
                else
                {
                    response = Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        Convert.ToString(status));
                }
            }
            else
            {
                response = Request.CreateErrorResponse(HttpStatusCode.Forbidden,
                    Convert.ToString(status));
            }

            TheProcessFactory.Release();

            return response;

        }
    }
}