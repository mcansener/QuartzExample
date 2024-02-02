using Quartz.Impl;
using Quartz;
using System;
using System.Threading.Tasks;

namespace QuartzExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await RunScheduler();
        }

        static async Task RunScheduler()
        {
            // Setup the scheduler
            var schedulerFactory = new StdSchedulerFactory();
            var scheduler = await schedulerFactory.GetScheduler();
            await scheduler.Start();

            // Define the job
            var job = JobBuilder.Create<HelloJob>()
                .WithIdentity("helloJob", "group1")
                .Build();

            // Define the trigger to run the job every 5 seconds
            var trigger = TriggerBuilder.Create()
                .WithIdentity("helloTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(5)
                    .RepeatForever())
                .Build();

            // Schedule the job with the trigger
            await scheduler.ScheduleJob(job, trigger);

            // Keep the application running until the user presses [Enter]
            Console.WriteLine("Press [Enter] to stop the scheduler.");
            await Task.Delay(-1);  // Use Task.Delay with a negative value to wait indefinitely

            // Shutdown the scheduler
            await scheduler.Shutdown();
        }
    }
}