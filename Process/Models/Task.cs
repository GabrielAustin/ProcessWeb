using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Process.Models
{
    public class Task
    {
        //    [JsonProperty(PropertyName = "opened")]
        public string pNudocopened { get; set;}
        //    [JsonProperty(PropertyName = "nu_doc")]
        public int pNudoc { get; set; }
        //     [JsonProperty(PropertyName = "nu_task")]
        public int pNuinst { get; set; }
        //    [JsonProperty(PropertyName = "nu_parent")]
        public int pWfp { get; set; }
        //    [JsonProperty(PropertyName = "nu_child")]
        public int pWfa { get; set; }
        //    [JsonProperty(PropertyName = "wf_name")]
        public string pNbwf { get; set; }
        //     [JsonProperty(PropertyName = "e")]
        public string pE { get; set; }
        //     [JsonProperty(PropertyName = "ep")]
        public string pEp { get; set; }
        //      [JsonProperty(PropertyName = "start_date")]
        public string pFeini { get; set; }
        //     [JsonProperty(PropertyName = "observa")]
        public string pTxobserva { get; set; }
        //      [JsonProperty(PropertyName = "detail")]
        public string pDetalle { get; set; }
        //      [JsonProperty(PropertyName = "days")]
        public string pDias { get; set; }
        //       [JsonProperty(PropertyName = "time")]
        public string pTiempo { get; set; }
        //      [JsonProperty(PropertyName = "overdue")]
        public string pRetraso { get; set; }
        //      [JsonProperty(PropertyName = "origin")]
        public string pOrigen { get; set; }
        //       [JsonProperty(PropertyName = "position_name")]
        public string pNbpuesto { get; set; }
        //        [JsonProperty(PropertyName = "person_name")]
        public string pNbpersona { get; set; }
        //        [JsonProperty(PropertyName = "alert")]
        public int pAlerta { get; set; }
        //         [JsonProperty(PropertyName = "state")]
        public int pSemaforo { get; set; }
        //         [JsonProperty(PropertyName = "waiting")]
        public string pInespera { get; set; }
//        [JsonProperty(PropertyName = "urgent")]
        public string pInUrgente { get; set; }
//        [JsonProperty(PropertyName = "start_date_time")]
        public string pFever { get; set; }
//        [JsonProperty(PropertyName = "form")]
        public int pFrmn { get; set; }

        public string pNb_puesto_destino { get; set; }
        public string pNb_persona_destino { get; set; }
        public string pIn_clone { get; set; }
        public string pDestino { get; set; }
        public string pTp_inst { get; set; }
        public int pWfc { get; set; }
        public string pTp_c { get; set; }

    }
}