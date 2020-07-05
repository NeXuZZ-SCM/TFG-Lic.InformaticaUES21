using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MonitorServiceWCF
{
    [ServiceContract(CallbackContract = typeof(IMiServicioDuplexCallback))]
    public interface IService1
    {

        [OperationContract]
        void Conectar();
       
        // TODO: agregue aquí sus operaciones de servicio
    }


    //INICIO PRUEBAS DE COMUNICACION HUB SIGNALR

    [ServiceContract]
    public interface IMiServicioDuplexCallback
    {
        [OperationContract(IsOneWay = true)]
        void CallbackMostrarEstados(string json);

    }

    [ServiceContract]
    public interface IAcciones
    {
        [OperationContract]
        bool IniciarServicio(string nombreProceso);
        [OperationContract]
        bool DetenerServicio(string nombreProceso);
        [OperationContract]
        bool PausarServicio(string nombreProceso);
        [OperationContract]
        bool ReanudarServicio(string nombreProceso);
        [OperationContract]
        bool ReiniciarServicio(string nombreProceso);
        [OperationContract]
        bool killService(string nombreProceso);
    }




}
