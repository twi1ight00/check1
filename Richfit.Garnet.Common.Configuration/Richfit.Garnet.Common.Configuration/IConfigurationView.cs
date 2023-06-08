using Richfit.Garnet.Common.Threading;

namespace Richfit.Garnet.Common.Configuration;

/// <summary>
/// 配置视图接口
/// </summary>
public interface IConfigurationView
{
	/// <summary>
	/// 获取或者设置配置视图名称
	/// </summary>
	string Name { get; set; }

	/// <summary>
	/// 获取或者设置配置视图所有者对象
	/// </summary>
	IViewsConfiguration Owner { get; set; }

	/// <summary>
	/// 获取或者设置同步锁对象
	/// </summary>
	ISyncLocker SyncRoot { get; set; }

	/// <summary>
	/// 制作配置视图副本
	/// </summary>
	/// <returns>当前配置视图的副本</returns>
	IConfigurationView Copy();

	/// <summary>
	/// 获取配置视图副本
	/// </summary>
	/// <typeparam name="T">配置视图副本类型</typeparam>
	/// <returns></returns>
	T Copy<T>() where T : IConfigurationView, new();

	/// <summary>
	/// 获取属性值
	/// </summary>
	/// <param name="name">属性名称</param>
	/// <param name="ignoreCase">是否忽略属性名称的大小写</param>
	/// <returns>属性值</returns>
	object GetValue(string name, bool ignoreCase = false);

	/// <summary>
	/// 获取属性值
	/// </summary>
	/// <typeparam name="T">属性值类型</typeparam>
	/// <param name="name">属性名称</param>
	/// <param name="ignoreCase">是否忽略属性名称的大小写</param>
	/// <returns>属性值</returns>
	T GetValue<T>(string name, bool ignoreCase = false);

	/// <summary>
	/// 设置属性值
	/// </summary>
	/// <param name="name">属性名称</param>
	/// <param name="value">属性值</param>
	/// <param name="ignoreCase">是否忽略属性名称的大小写</param>
	void SetValue(string name, object value, bool ignoreCase = false);

	/// <summary>
	/// 将视图序列化为Xml格式的配置数据
	/// </summary>
	/// <returns>Xml格式配置数据</returns>
	string Serialize();

	/// <summary>
	/// 将Xml格式的配置数据反序列化为视图对象
	/// </summary>
	/// <param name="xml">Xml格式配置数据</param>
	void Deserialize(string xml);
}
