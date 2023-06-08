using System;
using System.Web;
using Common.Logging;
using log4net.Config;
using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.IoC;
using Richfit.Garnet.Common.Logging;
using Richfit.Garnet.Common.Quartz;
using Richfit.Garnet.Module.Base.Infrastructure;
using Richfit.Garnet.Module.Base.Infrastructure.Cache;
using Richfit.Garnet.Module.Base.Infrastructure.Logging;
using Richfit.Garnet.Module.Exporting;
using Richfit.Garnet.Module.Importing;

namespace webapp;

public class Global : HttpApplication
{
	protected void Application_Start(object sender, EventArgs e)
	{
		try
		{
			ConfigurationManager.Initialize();
			ServiceLocator.Initialize(ConfigurationManager.System);
			XmlConfigurator.Configure(ConfigurationManager.System.Log4Net.GetConfiguration());
			LogManager.Reset(ConfigurationManager.System.CommonLogging.GetConfiguration());
			ILogger log = LoggerManager.GetLogger();
			log.Debug("系统工厂初始化开始");
			FactoryInitializer.Initialize();
			log.Debug("系统工厂初始化结束");
			log.Debug("数据缓存加载开始");
			CacheLoaderManager.Initialize();
			log.Debug("数据缓存加载结束");
			log.Debug("定时任务初始化开始");
			QuartzManager.Initialize(ConfigurationManager.System);
			log.Debug("定时任务初始化结束");
			log.Debug("导入管理器初始化开始");
			ImportManager.Initialize(ConfigurationManager.System);
			log.Debug("导入管理器初始化结束");
			log.Debug("导出管理器初始化开始");
			ExportManager.Initialize(ConfigurationManager.System);
			log.Debug("导出管理器初始化结束");
		}
		catch (Exception)
		{
			throw;
		}
	}

	protected void Session_Start(object sender, EventArgs e)
	{
	}

	protected void Application_BeginRequest(object sender, EventArgs e)
	{
	}

	protected void Application_AuthenticateRequest(object sender, EventArgs e)
	{
	}

	protected void Application_Error(object sender, EventArgs e)
	{
	}

	protected void Session_End(object sender, EventArgs e)
	{
	}

	protected void Application_End(object sender, EventArgs e)
	{
		LogCacheManager.ClearCache();
		QuartzManager.Dispose();
		ServiceLocator.Dispose();
		ConfigurationManager.Dispose();
		ImportManager.Dispose();
		ExportManager.Dispose();
	}
}
