using Richfit.Garnet.Common.Configuration;

namespace Richfit.Garnet.Common.Cache;

/// <summary>
/// 缓存配置
/// </summary>
public class CacheConfig
{
	/// <summary>
	/// Provider
	/// </summary>
	public static string CacheProvider => ConfigurationManager.System.Settings.GetSetting<string>("CacheProvider");

	/// <summary>
	/// 获得分布式部署的服务器的数量
	/// </summary>
	public static int DistributedServerCount => ConfigurationManager.System.Settings.GetSetting("DistributedServerCount", 1);

	/// <summary>
	/// 获得分布式服务器部署的情况下当前服务器的索引
	/// </summary>
	public static int CurrentServerIndex => ConfigurationManager.System.Settings.GetSetting("CurrentServerIndex", 0);

	/// <summary>
	/// 应用服务器启动是否清空二级缓存（分布式缓存）,默认不清空
	/// </summary>
	public static bool IsClearDistributeCache => ConfigurationManager.System.Settings.GetSetting("IsClearDistributeCache", defaultValue: false);
}
