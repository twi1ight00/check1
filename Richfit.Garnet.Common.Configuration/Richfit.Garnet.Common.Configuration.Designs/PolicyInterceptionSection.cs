using System.Configuration;

namespace Richfit.Garnet.Common.Configuration.Designs;

/// <summary>
/// 策略拦截配置节
/// </summary>
public class PolicyInterceptionSection : ConfigurationSection
{
	/// <summary>
	/// 拦截器集合属性名称
	/// </summary>
	public const string InterceptorsProperty = "interceptors";

	/// <summary>
	/// 拦截目标集合属性名称
	/// </summary>
	public const string TargetsProperty = "targets";

	/// <summary>
	/// 拦截器配置集合
	/// </summary>
	[ConfigurationProperty("interceptors", IsDefaultCollection = false)]
	[ConfigurationCollection(typeof(KeyedConfigurationElementCollection<InterceptionTargetInterceptorElement, string>), AddItemName = "interceptor", ClearItemsName = "clear", RemoveItemName = "remove")]
	public KeyedConfigurationElementCollection<InterceptionTargetInterceptorElement, string> Interceptors => (KeyedConfigurationElementCollection<InterceptionTargetInterceptorElement, string>)base["interceptors"];

	/// <summary>
	/// 策略拦截目标配置集合
	/// </summary>
	[ConfigurationProperty("targets", IsDefaultCollection = false)]
	[ConfigurationCollection(typeof(KeyedConfigurationElementCollection<InterceptionTargetElement, string>), AddItemName = "target", ClearItemsName = "clear", RemoveItemName = "remove")]
	public KeyedConfigurationElementCollection<InterceptionTargetElement, string> Targets => (KeyedConfigurationElementCollection<InterceptionTargetElement, string>)base["targets"];
}
