using InertiaSparkTest.Application.Tasks;
using Coravel;

namespace InertiaSparkTest.Application.Startup
{
    public static class Scheduler
    {
        public static IServiceProvider RegisterScheduledJobs(this IServiceProvider services)
        {
            services.UseScheduler(scheduler =>
            {
                // example scheduled job
                //scheduler
                //    .Schedule<ExampleTask>()
                //    .EveryFiveMinutes();
            });
            return services;
        }
    }
}
