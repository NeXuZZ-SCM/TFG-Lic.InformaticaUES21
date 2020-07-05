using MonitorServiceWCF.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Web;

namespace MonitorServiceWCF
{
    public class ConfigFile
    {
        public string GetJsonServicios()
        {
            //string output = JsonConvert.SerializeObject(GetServiceObject(GetServiceName()));
            string output = JsonConvert.SerializeObject(GetServiceName());
            return output;
        }

        public AlarmaObj GetServiceName()
        {
            
            var path = Path.Combine(Directory.GetCurrentDirectory(), "DatosAlarma.json");
            VeificaExistenciaArchivo(path);
            var json = File.ReadAllText(path); //C:\Program Files (x86)\IIS Express\ConfigServicios.json
            AlarmaObj AlarmasRecibidas = JsonConvert.DeserializeObject<AlarmaObj>(json);
            return AlarmasRecibidas;
        }

        private void VeificaExistenciaArchivo(string path)
        {
            if (!File.Exists(path))
            {
                var file = File.Create(path);
                file.Close();
                string[] lines = { "{", "\"Nombres\" : [", "\"TuServicio\",", "\"TuServicio2\"", "]", "}" };
                using (StreamWriter outputFile = new StreamWriter(path))
                {
                    foreach (string line in lines)
                    {
                        outputFile.WriteLine(line);
                    }
                }
            }
        }

      /*  public ServiceObject GetServiceObject(AlarmaObj AlarmasRecibidas)
        {
            ServiceObject serviceObject = new ServiceObject();
            serviceObject.ServiceObj = new List<ServicePID>();
                /*for (int i = 0; i < AlarmasRecibidas.AlarmaObjeto.Count; i++)
                {
                string qry = "SELECT PROCESSID FROM WIN32_SERVICE WHERE NAME = '" + ServiceNames.Nombres[i] + "'";
                System.Management.ManagementObjectSearcher searcher = new System.Management.ManagementObjectSearcher(qry);
                foreach (System.Management.ManagementObject mngntObj in searcher.Get())
                {
                    var objServPID = new ServicePID();
                    objServPID.Service = ServiceNames.Nombres[i];
                    objServPID.Status = GetStatusServiceByName(ServiceNames.Nombres[i]);
                    objServPID.PID = (uint)mngntObj["PROCESSID"];
                    serviceObject.ServiceObj.Add(objServPID);
                }
            }
            return serviceObject;
        }*/

        public string GetStatusServiceByName(string ServiceName)
        {
            ServiceController sc = new ServiceController(ServiceName);
            string status = sc.Status.ToString();
            sc.Refresh();
            return status;
        }
    }
}