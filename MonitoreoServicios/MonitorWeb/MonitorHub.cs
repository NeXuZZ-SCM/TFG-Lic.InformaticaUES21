using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MonitorWeb.ServiceReference1;
using Microsoft.AspNet.SignalR;
using System.ServiceModel;

namespace MonitorWeb
{
    public class MonitorHub : Hub, ServiceReference1.IService1Callback
    {
        Service1Client service;
        ServiceReference1.AccionesClient acciones = new AccionesClient();
        public void RequestMostrarEstados()
        {
            var instanceContext = new InstanceContext(this);
            service = new Service1Client(instanceContext);

            service.Conectar(); //funcion Iservice
        }
        public void MostrarTablaPorCategoria(string json)
        {
            throw new NotImplementedException();
        }
        void IService1Callback.CallbackMostrarEstados(string json)
        {
            Clients.All.callbackEstados(json);
        }
        //INICIA ETAPA ESTADOS SERVICIOS
        public void requestIniciarServicio(string servicio)
        {
            acciones.IniciarServicio(servicio); //funcion : IAcciones
        }
        public void requestDetenerServicio(string servicio)
        {
            acciones.DetenerServicio(servicio); //funcion : IAcciones
        }
        public void requestPausarServicio(string servicio)
        {
            acciones.PausarServicio(servicio); //funcion : IAcciones
        }
        public void requestReanudarServicio(string servicio)
        {
            acciones.ReanudarServicio(servicio); //funcion : IAcciones
        }
        public void requestReiniciarServicio(string servicio)
        {
            acciones.ReiniciarServicio(servicio); //funcion : IAcciones
        }
        public void requestkillService(string PID)
        {
            acciones.killService(PID); //funcion : IAcciones
        }
        //FIN ESTAPA ESTADOS SERVICIOS
    }

}