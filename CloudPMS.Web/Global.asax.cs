using System;
using System.Web;
using System.Web.Http;
using ECommon.Logging;
using ECommon.Configurations;
using ENode.Configurations;
using CloudPMS.Infrastructure;
using ECommon.Components;
using System.Reflection;
using CloudPMS.Web.Extensions;
using ECommon.Autofac;
using Autofac;
using Autofac.Integration.WebApi;

namespace CloudPMS.Web
{
    public class Global : HttpApplication
    {
        private ILogger _logger;
        private Configuration _ecommonConfiguration;
        private ENodeConfiguration _enodeConfiguration;
        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码
            GlobalConfiguration.Configure(WebApiConfig.Register);
            InitializeECommon();
            InitializeENode();
        }
        private void InitializeECommon()
        {
            _ecommonConfiguration = Configuration
                .Create()
                .UseAutofac()
                .RegisterCommonComponents()
                .UseLog4Net()
                .UseJsonNet()
                .RegisterUnhandledExceptionHandler();

            _logger = ObjectContainer.Resolve<ILoggerFactory>().Create(GetType().FullName);
            _logger.Info("ECommon initialized.");
        }
        private void InitializeENode()
        {
            ConfigSettings.Initialize();

            var assemblies = new[]
            {
                Assembly.Load("CloudPMS.Commands"),
                Assembly.Load("CloudPMS.QueryServices"),
                Assembly.Load("CloudPMS.QueryServices.Dapper"),
                Assembly.Load("CloudPMS.Web")
            };

            _enodeConfiguration = _ecommonConfiguration
                .CreateENode()
                .RegisterENodeComponents()
                .RegisterBusinessComponents(assemblies)
                .UseEQueue()
                .InitializeBusinessAssemblies(assemblies)
                .StartEQueue();

            //RegisterControllers();
            _logger.Info("ENode initialized.");
        }
        private void RegisterControllers()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}