using Quartz;
using Quartz.Impl;
using System;
using System.Timers;
using Topshelf;

namespace TopshelfConsole
{
    class MainService
    {

        private readonly IScheduler scheduler;
        public MainService()
        {
            //Quartz3.0 初始化方式1
            scheduler = StdSchedulerFactory.GetDefaultScheduler().GetAwaiter().GetResult();
            //Quartz3.0 初始化方法2
            //scheduler = StdSchedulerFactory.GetDefaultScheduler().Result;
        }

        public bool Start(HostControl hostControl)
        {
            scheduler.Start();
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            scheduler.Shutdown();
            return true;
        }
    }
}
