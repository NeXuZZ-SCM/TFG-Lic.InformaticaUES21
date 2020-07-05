using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitorServiceWCF.Entidades
{
    public class AlarmaObj
    {
        public List<AlarmasID> AlarmaObjeto { get; set; }
    }
    public class AlarmasID
    {
        public int ID_Evento { get; set; }
        public int ID_Vincha { get; set; }
        public string ModeloVincha { get; set; }
        public string NivelFatiga { get; set; }
        public int ID_Conductor { get; set; }
        public string NombreConductor { get; set; }
        public string Vehiculo { get; set; }
        public DateTime FechaHora { get; set; }
        public string GPS { get; set; }

    }
}