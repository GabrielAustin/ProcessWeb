using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Web;
using MBAmb02;
using Process.Models;

namespace Process.Factories
{
    public class EnvironmentFactory
    {
        private Ambientes _environment;
        protected Ambientes Environment
        {
            get
            {
                if (_environment == null)
                {
                    _environment = new Ambientes();
                    _environment.Init("Suite");
                }
                return _environment;
            }
        }

        public void Release()
        {
            Marshal.ReleaseComObject(_environment);
        }

        public int CountEnvironments()
        {
            return Environment.Count;
        }

        public List<DomainModel> GetEnvironments()
        {
            var myList = new List<DomainModel>();

            for (int i = 1; i <= CountEnvironments(); i++)
            {
                DomainModel domain = new DomainModel();
                domain.name = Environment[i];
                myList.Add(domain);
            }

            return myList;
        }

        public Domain GetDomain(DomainModel domainModel)
        {
            Domain domain = new Domain();

            Environment.set_Ambiente(domainModel.name);
            domain.name = domainModel.name;
            domain.language = Environment.LeerVarAmbienteEx("", "Idioma");
            domain.connectionType = Convert.ToInt32(Environment.LeerVarAmbienteEx("", "WebTipoconexion"));
            domain.securityLevel = ((Environment.LeerVarAmbienteEx("", "Nvlseg")) != "") ? Convert.ToInt32(Environment.LeerVarAmbienteEx("", "Nvlseg")) : 0;
            domain.webEnvironment = Environment.LeerVarAmbienteEx("", "WebAmbientes");

            return domain;
        }

    }
}