using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopshelfConsole
{
    /// <summary>
    /// 自定義Job，實際工作地，需實現IJob
    /// </summary>
    public class TestJob : IJob
    {        
        public Task Execute(IJobExecutionContext context)
        {            
            Console.WriteLine("TestJob測試");
            Console.WriteLine($"現在時間{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}");
            return Task.CompletedTask;
        }
    }
}
