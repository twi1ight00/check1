using System;
using System.Text;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// JSON对象配置源接口
/// </summary>
[ConfigurationSourceMapping(typeof(JsonObjectConfigurationSource))]
public interface IJsonObjectConfigurationSource : IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 获取或者设置配置源文件的编码
	/// </summary>
	Encoding Encoding { get; set; }

	/// <summary>
	/// 获取或者设置配置源文本
	/// </summary>
	string Text { get; set; }

	/// <summary>
	/// 获取JSON配置对象
	/// </summary>
	/// <param name="type">获取的JSON对象的类型</param>
	/// <returns>配置中定义的JSON对象</returns>
	object GetValue(Type type);

	/// <summary>
	/// 获取JSON配置对象
	/// </summary>
	/// <typeparam name="T">获取的JSON对象的类型</typeparam>
	/// <returns>配置中定义的JSON对象</returns>
	T GetValue<T>();

	/// <summary>
	/// 设置JSON配置对象
	/// </summary>
	/// <param name="obj">JSON配置对象</param>
	void SetValue(object obj);
}
