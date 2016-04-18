using System.ServiceProcess;

namespace CloudPMS.CommandService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
            Bootstrap.Initialize();
        }

        protected override void OnStart(string[] args)
        {
            Bootstrap.Start();
        }
        protected override void OnStop()
        {
            Bootstrap.Stop();
        }
    }
}
