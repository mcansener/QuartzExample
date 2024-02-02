using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzExample
{
    public class HelloJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine("Hello, Quartz.NET!");
        }
    }
}
