using Richfit.Garnet.Common.Configuration;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Quartz;

/// <summary>
/// Quartz定时服务管理器
/// </summary>
public class QuartzManager : Singleton<QuartzManager>
{
	/// <summary>
	/// 同步对象
	/// </summary>
	private static readonly object SyncLocker = new object();

	/// <summary>
	/// Quartz定时服务实例
	/// </summary>
	private IQuartzServer quartzServer;

	/// <summary>
	/// 初始化定时服务管理器
	/// 不存在配置文件则不进行初始化
	/// </summary>
	/// <param name="configuration">主配置源</param>
	public static void Initialize(IMainConfiguration configuration)
	{
		lock (Singleton<QuartzManager>.Instance)
		{
			Dispose();
			if (!configuration.Settings.EnableQuartz)
			{
				return;
			}
			IQuartzConfiguration quartzConfiguration = configuration.Quartz;
			if (quartzConfiguration != null)
			{
				IQuartzJobConfiguration[] quartzJobConfigurations = configuration.GetAll<IQuartzJobConfiguration>(recursive: true);
				Singleton<QuartzManager>.Instance.quartzServer = new QuartzServer();
				Singleton<QuartzManager>.Instance.quartzServer.Initialize(quartzConfiguration.GetConfiguration());
				IQuartzJobConfiguration[] array = quartzJobConfigurations;
				foreach (IQuartzJobConfiguration jobConfiguration in array)
				{
					Singleton<QuartzManager>.Instance.quartzServer.AddJob(jobConfiguration.GetConfiguration());
				}
				Singleton<QuartzManager>.Instance.quartzServer.Start();
			}
		}
	}

	/// <summary>
	/// 执行清理
	/// </summary>
	public static void Dispose()
	{
		lock (Singleton<QuartzManager>.Instance)
		{
			if (Singleton<QuartzManager>.Instance.quartzServer != null)
			{
				Singleton<QuartzManager>.Instance.quartzServer.Stop();
				Singleton<QuartzManager>.Instance.quartzServer.Dispose();
				Singleton<QuartzManager>.Instance.quartzServer = null;
			}
		}
	}

	/// <summary>
	/// 初始化管理器
	/// </summary>
	private QuartzManager()
	{
	}
}
