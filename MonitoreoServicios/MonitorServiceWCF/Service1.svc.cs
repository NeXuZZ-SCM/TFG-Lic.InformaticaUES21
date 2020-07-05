using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Configuration;
using System.Text;
using System.ServiceProcess;
using System.Timers;
using System.Web.UI;
using System.Diagnostics;

namespace MonitorServiceWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1, IAcciones
    {


        System.Timers.Timer timer = new System.Timers.Timer();
        public Service1()
        {

        }
        private IMiServicioDuplexCallback _cliente;
        public IMiServicioDuplexCallback Cliente { get { return _cliente; } set { _cliente = value; } }
        public IMiServicioDuplexCallback GetCurrentCallback()
        {
            return OperationContext.Current.GetCallbackChannel<IMiServicioDuplexCallback>();
        }
        public void Conectar()
        {
            _cliente = this.GetCurrentCallback();
            if (timer.Enabled != true)
            {
                
                timer.Interval = Convert.ToInt32(ConfigurationManager.AppSettings["intervalo"]);
                timer.Elapsed += new System.Timers.ElapsedEventHandler(RequestMostrarEstados);
                timer.Start();
            }
        }

        public void RequestMostrarEstados(object sender, System.Timers.ElapsedEventArgs e)
        {
            ConfigFile configFile = new ConfigFile();
            _cliente.CallbackMostrarEstados(configFile.GetJsonServicios());

        }


        #region ACCIONES
        public bool IniciarServicio(string nombreProceso)
        {
            Acciones acciones = new Acciones();
            return acciones.IniciarServicio(nombreProceso);
        }

        public bool DetenerServicio(string nombreProceso)
        {
            Acciones acciones = new Acciones();
            return acciones.DetenerServicio(nombreProceso);
        }

        public bool PausarServicio(string nombreProceso)
        {
            Acciones acciones = new Acciones();
            return acciones.PausarServicio(nombreProceso);
        }

        public bool ReanudarServicio(string nombreProceso)
        {
            Acciones acciones = new Acciones();
            return acciones.ReanudarServicio(nombreProceso);
        }

        public bool ReiniciarServicio(string nombreProceso)
        {
            Acciones acciones = new Acciones();
            return acciones.ReiniciarServicio(nombreProceso);
        }

        public bool killService(string PID)
        {
            Acciones acciones = new Acciones();
            return acciones.KillService(PID);
        }
        #endregion







    }
}
