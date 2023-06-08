using System;
using Richfit.Garnet.Common.Data;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// 数据库连接配置源接口
/// </summary>
[ConfigurationSourceMapping(typeof(DatabaseConfigurationSource))]
public interface IDatabaseConfigurationSource : IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 获取或者设置配置文本
	/// </summary>
	string Text { get; set; }

	/// <summary>
	/// 获取系统默认使用的数据库连接名称
	/// </summary>
	DatabaseConnection DefaultConnection { get; }

	/// <summary>
	/// 获取全部数据库连接对象列表
	/// </summary>
	/// <returns>全部的数据库连接对象数组</returns>
	DatabaseConnection[] GetConnections();

	/// <summary>
	/// 获取指定数据库类型的所有数据库连接
	/// </summary>
	/// <param name="type">数据库类型</param>
	/// <returns>数据库连接对象数组</returns>
	DatabaseConnection[] GetConnections(DBType type);

	/// <summary>
	/// 获取指定名称的数据库连接对象，如果不存在指定名称的数据库连接对象，则返回null
	/// </summary>
	/// <param name="name">数据库连接名称</param>
	/// <returns>指定名称的数据库连接对象</returns>
	DatabaseConnection GetConnection(string name);

	/// <summary>
	/// 添加数据库连接
	/// </summary>
	/// <param name="name">数据库连接名称</param>
	/// <param name="connection">数据库连接字符串</param>
	/// <param name="type">数据库连接类型</param>
	/// <returns>如果添加成功返回true，否则返回false</returns>
	bool AddConnection(string name, string connection, DBType type);

	/// <summary>
	/// 添加数据库连接对象
	/// </summary>
	/// <param name="connection">数据库连接对象</param>
	/// <returns>添加成功返回true，否则返回false</returns>
	bool AddConnection(DatabaseConnection connection);

	/// <summary>
	/// 删除指定名称的数据库连接
	/// </summary>
	/// <param name="name">数据库连接名称</param>
	/// <returns>如果删除成功返回true，否则返回false</returns>
	bool RemoveConnection(string name);

	/// <summary>
	/// 删除指定名称的数据库连接
	/// </summary>
	/// <param name="connection">数据库连接对象</param>
	/// <returns>如果删除成功返回true，否则返回false</returns>
	bool RemoveConnection(DatabaseConnection connection);

	/// <summary>
	/// 设置默认数据连接名称
	/// </summary>
	/// <param name="name">数据库连接名称</param>
	void SetDefaultConnection(string name);
}
