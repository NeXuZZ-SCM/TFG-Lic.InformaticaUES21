using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Web;

namespace MonitorServiceWCF
{
    public class Acciones
    {
        public bool IniciarServicio(string nombreServicio)
        {
            try
            {
                ServiceController sc = new ServiceController(nombreServicio);
                sc.Start();
                return true;
            }
            catch (ArgumentException ex)
            {
                return false;
            }
            catch (InvalidOperationException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool DetenerServicio(string nombreServicio)
        {
            try
            {
                ServiceController sc = new ServiceController(nombreServicio);
                sc.Stop();
                return true;
            }
            catch (ArgumentException ex)
            {
                return false;
                throw;
            }
            catch (InvalidOperationException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool PausarServicio(string nombreServicio)
        {
            try
            {
                ServiceController sc = new ServiceController(nombreServicio);
                sc.Pause();
                return true;
            }
            catch (ArgumentException ex)
            {
                return false;
            }
            catch (InvalidOperationException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool ReanudarServicio(string nombreServicio)
        {
            try
            {
                ServiceController sc = new ServiceController(nombreServicio);
                sc.Continue();
                return true;
            }
            catch (ArgumentException ex)
            {
                return false;
            }
            catch (InvalidOperationException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool ReiniciarServicio(string nombreServicio)
        {
            try
            {
                ServiceController sc = new ServiceController(nombreServicio);
                try
                {
                    sc.Stop();
                    sc.WaitForStatus(ServiceControllerStatus.Stopped);
                    sc.Start();
                    return true;
                }
                catch (InvalidOperationException ex)
                {
                    return false;
                }
                catch (Exception ex)
                {
                    return false;
                }

            }
            catch (ArgumentException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }



        }
        public bool KillService(string PID)
        {
            try
            {
                Process proc = Process.GetProcessById(Convert.ToInt32(PID));
                
                    try
                    {
                        proc.Kill();
                        return true;
                    }
                    catch (NotSupportedException ex)
                    {
                        return false;
                    }
                    catch (InvalidOperationException ex)
                    {
                        return false;
                    }
                    catch (Exception ex)
                    {
                        return false;
                    }




            }
            catch (InvalidOperationException ex)
            {
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}