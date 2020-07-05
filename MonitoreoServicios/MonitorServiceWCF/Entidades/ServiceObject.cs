using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MonitorServiceWCF.Entidades
{
    public class ServiceObject
    {
        public List<ServicePID> ServiceObj { get; set; }
    }
    public class ServicePID
    {
        public string Service { get; set; }
        public string Status { get; set; }
        public uint PID { get; set; }

    }
}