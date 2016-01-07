using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using Process.Models;
using p4bwfeng7;

namespace Process.Factories
{
    public class ProcessFactory
    {
        private c_Process _engine;
        protected c_Process Engine
        {
            get
            {
                if(_engine == null)
                {
                    _engine = new c_Process();
                }
                return _engine;
            }
        }

        public void Release()
        {
            Marshal.ReleaseComObject(_engine);
        }

        //Manejo de sesion.

        //Establecer sesion.
        public int EstablishSession(UserModel user, string pIp)
        {
            Random randNum = new Random();
            int sessionID = 111111111;
            int pSesionCaida = 0;

            EnvironmentFactory environmentFactory = new EnvironmentFactory();
            Domain domain = environmentFactory.GetDomain(user.domain);
            environmentFactory.Release();


            return Engine.p4bEstablecerSesion
                (
                user.username,
                user.password,
                user.domain.name,
                sessionID,
                pIp,
                domain.connectionType,
                pSesionCaida
                );
        }

        //Recuperar Sesion.
        public int RecoverSession(UserModel user, string pIp)
        {
            Random randNum = new Random();
            int sessionID = 111111111;
            int connectionType = 3;
            int pSesionCaida = Engine.SesionCaida;

            return Engine.p4bEstablecerSesion
                (
                user.username,
                user.password,
                user.domain.name,
                sessionID,
                pIp,
                connectionType,
                pSesionCaida
                );
        }

        //Destruit Sesion
        public int DestroySession(UserModel user, string pIp)
        {
            Random randNum = new Random();
            EnvironmentFactory environmentFactory = new EnvironmentFactory();
            Domain domain = environmentFactory.GetDomain(user.domain);
            int pSesionCaida = Engine.SesionCaida;

            return Engine.p4bEstablecerSesion
                (
                user.username,
                user.password,
                user.domain.name,
                randNum.Next(999999999),
                pIp,
                domain.connectionType,
                pSesionCaida
                );
        }

        //Guardar sesion.
        public string SaveSession()
        {
            string ticket = Engine.p4bGuardarSesion(0);
            return ticket ;
        }

        //Obtener estatus de la sesion
        public int GetStatus()
        {
            int status = Engine.p4bStatus();
            return status;
        }

        //Obtener la sesion.
        public int GetSession(string ticket)
        {
            return Engine.p4bObtenerSesion(ticket);
        }

        //Cerrar la sesion.
        public int CloseSession()
        {
            return Engine.p4bCerrarSesion();
        }

        //Manejo de Cesta
        public string GetBasket(BasketModel bm)
        {
            string message = null;
            message = Engine.p4bObtenerCesta(bm.type,
                bm.from,
                bm.docNumber,
                bm.wfParent,
                bm.wfChild,
                bm.dateStart,
                bm.dateEnd,
                bm.detail);
            Log("GetBasket", message);
            return message;
        }

        public List<Task> GetBasketList(BasketModel basket)
        {
            XmlDocument doc = new XmlDocument();
            XDocument xDoc = XDocument.Parse(GetBasket(basket));
            List<Task> myList = new List<Task>();

            foreach (XElement element in xDoc.Descendants("inst"))
            {
                Task task = new Task();

                task.pNudocopened = element.Element("nu_doc_opened").Value;
                task.pNudoc = Convert.ToInt32(element.Element("nu_doc").Value);
                task.pNuinst = Convert.ToInt32(element.Element("nu_inst").Value);
                task.pWfp = Convert.ToInt32(element.Element("wfp").Value);
                task.pWfa = Convert.ToInt32(element.Element("wfa").Value);
                task.pNbwf = element.Element("nb_wf").Value;
                task.pE = element.Element("e").Value;
                task.pEp = element.Element("ep").Value;
                task.pFeini = element.Element("fe_ini").Value;
                task.pTxobserva = element.Element("txobserva").Value;
                task.pDetalle = element.Element("detalle").Value;
                task.pDias = element.Element("dias").Value;
                task.pTiempo = element.Element("tiempo").Value;
                task.pRetraso = element.Element("retraso").Value;
                task.pOrigen = element.Element("origen").Value;
                task.pNbpuesto = element.Element("nb_puesto").Value;
                task.pNbpersona = element.Element("nb_persona").Value;
                task.pAlerta = Convert.ToInt32(element.Element("alerta").Value);
                task.pSemaforo = element.Element("semaforo").IsEmpty ? -1 : Convert.ToInt32(element.Element("semaforo").Value);

                task.pInespera = element.Element("in_espera") == null ? "" : element.Element("in_espera").Value;
                task.pInUrgente = element.Element("in_urgente") == null ? "" : element.Element("in_urgente").Value;
                task.pFever = element.Element("fever") == null ? "" : element.Element("fever").Value;
                task.pFrmn = element.Element("frmn") == null ? -1 : Convert.ToInt32(element.Element("frmn").Value);

                task.pNb_puesto_destino = element.Element("nb_puesto_destino") == null ? "" : element.Element("nb_puesto_destino").Value;
                task.pNb_persona_destino = element.Element("nb_persona_destino") == null ? "" : element.Element("nb_persona_destino").Value;
                task.pIn_clone = element.Element("in_clone") == null ? "" : element.Element("in_clone").Value;
                task.pDestino = element.Element("destino") == null ? "" : element.Element("destino").Value;
                task.pTp_inst = element.Element("tp_inst") == null ? "" : element.Element("tp_inst").Value;
                task.pWfc = element.Element("wfc") == null ? -1 : Convert.ToInt32(element.Element("wfc").Value);
                task.pTp_c = element.Element("tp_c") == null ? "" : element.Element("tp_c").Value;

                myList.Add(task);
            }

            return myList;
        }

        public void Log(string activity, string message)
        {
            Engine.p4bTrazaInt(activity, message);
        }

    }
}