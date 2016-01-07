using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Process.Factories;

namespace Process.Controllers
{
    public class BaseApiController : ApiController
    {
        private ModelFactory _modelFactory;

        protected ModelFactory TheModelFactory
        {
            get
            {
                if (_modelFactory == null)
                {
                    _modelFactory = new ModelFactory();
                }
                return _modelFactory;
            }
        }

        private ProcessFactory _processFactory;

        protected ProcessFactory TheProcessFactory
        {
            get
            {
                if (_processFactory == null)
                {
                    _processFactory = new ProcessFactory();
                }
                return _processFactory;
            }

        }


        private HttpFactory _httpFactory;

        protected HttpFactory TheHttpFactory
        {
            get
            {
                if (_httpFactory == null)
                {
                    _httpFactory = new HttpFactory();
                }
                return _httpFactory;
            }
        }

        private EnvironmentFactory _environmentFactory;

        protected EnvironmentFactory TheEnvironmentFactory
        {
            get
            {
                if (_environmentFactory == null)
                {
                    _environmentFactory = new EnvironmentFactory();
                }
                return _environmentFactory;
            }
        }
    }
}