using System;
using System.Reflection;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 包信息配置源
/// </summary>
[ConfigurationSourceMapping(typeof(PackageConfigurationSource))]
public interface IPackageConfigurationSource : IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 获取包ID
	/// </summary>
	string PackageID { get; }

	/// <summary>
	/// 获取包名称
	/// </summary>
	string PackageName { get; }

	/// <summary>
	/// 获取包位置
	/// </summary>
	string PackageLocation { get; }

	/// <summary>
	/// 获取或者设置配置内容
	/// </summary>
	string Text { get; set; }

	/// <summary>
	/// 获取包程序集集合
	/// </summary>
	Assembly[] Assemblies { get; }

	/// <summary>
	/// 获取组配置
	/// </summary>
	IGroupConfiguration Collection { get; }

	/// <summary>
	/// 获取包的设置配置
	/// </summary>
	ISettingsGroupConfiguration Settings { get; }

	/// <summary>
	/// 获取包的SQL设置配置
	/// </summary>
	ISqlGroupConfiguration Sqls { get; }

	/// <summary>
	/// 获取指定名称的包程序集，不存在指定名称的包程序集返回null
	/// </summary>
	/// <param name="name">包程序集名称</param>
	/// <returns>包程序集</returns>
	Assembly GetAssembly(string name);

	/// <summary>
	/// 添加包程序集
	/// </summary>
	/// <param name="assembly">添加的包程序集</param>
	/// <returns>添加成功返回true，否则返回false</returns>
	bool AddAssembly(Assembly assembly);

	/// <summary>
	/// 添加包程序集
	/// </summary>
	/// <param name="name">包程序集名称</param>
	/// <param name="assembly">添加的包程序集</param>
	/// <returns>添加成功返回true，否则返回false</returns>
	bool AddAssembly(string name, Assembly assembly);

	/// <summary>
	/// 移除包程序集
	/// </summary>
	/// <param name="name">包程序集名称</param>
	/// <returns>移除成功返回true，否则返回false</returns>
	bool RemoveAssembly(string name);

	/// <summary>
	/// 移除包程序集
	/// </summary>
	/// <param name="assembly">待移除的包程序集</param>
	/// <returns>移除成功返回true，否则返回false</returns>
	bool RemoveAssembly(Assembly assembly);
}
