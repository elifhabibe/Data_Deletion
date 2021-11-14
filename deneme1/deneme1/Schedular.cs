using Quartz;
using Quartz.Impl;
using System;

namespace deneme1
{
    public class Scheduler
    {
        public async void Start()
        {

            var scheduler = await new StdSchedulerFactory().GetScheduler();
            await scheduler.Start();
            IJobDetail job = JobBuilder.Create<DeleteJob>().Build();
            ITrigger trigger = TriggerBuilder.Create()
             .WithDailyTimeIntervalSchedule(
                    s=>s.OnEveryDay()
                    .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(13,55))
                    )
               .Build();
            await scheduler.ScheduleJob(job, trigger);

        }

    }
}