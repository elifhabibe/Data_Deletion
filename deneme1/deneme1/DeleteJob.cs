using Quartz;
using System.Threading.Tasks;

namespace deneme1
{
    public class DeleteJob : IJob
    {

        public Task Execute(IJobExecutionContext context)
        {
           //DENEME
            Form2 fm = new Form2();
            fm.Calistir();
            return Task.CompletedTask;

        }
    }
}
