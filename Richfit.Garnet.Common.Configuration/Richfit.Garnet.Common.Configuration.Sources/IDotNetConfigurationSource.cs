using System;
using System.Configuration;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// .Net配置源对象接口
/// </summary>
[ConfigurationSourceMapping(typeof(DotNetConfigurationSource))]
public interface IDotNetConfigurationSource : IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 获取.NET标准配置文件对象
	/// </summary>
	System.Configuration.Configuration Configuration { get; }

	/// <summary>
	/// 获取或者设置原始配置文本
	/// </summary>
	string Text { get; set; }

	/// <summary>
	/// 指示配置源是否存在
	/// </summary>
	bool Exists { get; }

	/// <summary>
	/// 获取配置文件中的所有配置节
	/// </summary>
	/// <returns></returns>
	ConfigurationSection[] GetSections();

	/// <summary>
	/// 获取所有指定类型的配置节对象
	/// 返回配置节数组，没有匹配的配置节，返回空数组。
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <returns></returns>
	T[] GetSections<T>() where T : ConfigurationSection;

	/// <summary>
	/// 获取指定名称的配置节对象
	/// 没有匹配的配置节，则返回null
	/// </summary>
	/// <param name="sectionName">配置节名称</param>
	/// <returns>配置节对象</returns>
	ConfigurationSection GetSection(string sectionName);

	/// <summary>
	/// 获取指定类型的配置节对象
	/// 只返回第一个类型匹配的配置节，没有匹配的配置节，则返回null
	/// </summary>
	/// <typeparam name="T">配置节类型</typeparam>
	/// <returns>配置节对象</returns>
	T GetSection<T>() where T : ConfigurationSection;

	/// <summary>
	/// 获取指定名称、指定类型的配置节对象
	/// 没有匹配的配置节，则返回null
	/// </summary>
	/// <typeparam name="T">配置节类型</typeparam>
	/// <param name="sectionName">配置节名称</param>
	/// <returns>配置节对象</returns>
	T GetSection<T>(string sectionName) where T : ConfigurationSection;

	/// <summary>
	/// 添加指定名称的配置节
	/// </summary>
	/// <param name="sectionName">配置节名称</param>
	/// <param name="section">配置节对象</param>
	/// <returns>如果添加成功返回true，否则返回false</returns>
	bool AddSection(string sectionName, ConfigurationSection section);

	/// <summary>
	/// 添加指定名称的配置节
	/// </summary>
	/// <typeparam name="T">配置节类型</typeparam>
	/// <param name="sectionName">配置节名称</param>
	/// <returns>如果添加成功返回true，否则返回false</returns>
	bool AddSection<T>(string sectionName) where T : ConfigurationSection, new();

	/// <summary>
	/// 移除指定名称的配置节
	/// </summary>
	/// <param name="sectionName">配置节名称</param>
	/// <returns>如果移除成功返回true，否则返回false</returns>
	bool RemoveSection(string sectionName);
}
