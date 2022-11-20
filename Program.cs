using log4net;
using Quartz;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace TopshelfConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                HostFactory.Run(x =>
                {
                    x.Service<MainService>(y =>
                    {
                        y.ConstructUsing<MainService>(service => new MainService());
                        y.WhenStarted((tc, th) => tc.Start(th));
                        y.WhenStopped((ts, th) => ts.Stop(th));
                    });

                    x.RunAsLocalSystem();

                    x.SetDescription(ConfigurationManager.AppSettings["ServiceDescription"]);

                    x.SetDisplayName(ConfigurationManager.AppSettings["ServiceDisplayName"]);

                    x.SetServiceName(ConfigurationManager.AppSettings["ServiceName"]);
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine("服務異常:" + ex.Message);
            }
        }
    }
}
