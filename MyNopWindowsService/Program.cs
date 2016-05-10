using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNopWindowsService
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            var mode = ConfigurationManager.AppSettings["StartMode"];
            if (mode.Equals("Service", StringComparison.OrdinalIgnoreCase))
            {
                var servicesToRun = new ServiceBase[]
                {
                    new MainService()
                };
                ServiceBase.Run(servicesToRun);
            }
            else
            {
                var form = new TestService();
                Application.Run(form);
            }

        }
    }
}
