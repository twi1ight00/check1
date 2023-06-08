using System;
using Richfit.Garnet.Common.Data;
using Richfit.Garnet.Common.Patterns;

namespace Richfit.Garnet.Common.Configuration.Sources;

/// <summary>
/// SQL配置源接口
/// </summary>
[ConfigurationSourceMapping(typeof(SqlConfigurationSource))]
public interface ISqlConfigurationSource : IConfigurationSource, ISyncableObject, IDisposableObject, IDisposable
{
	/// <summary>
	/// 获取或者设置配置内容
	/// </summary>
	string Text { get; set; }

	/// <summary>
	/// 获取指定名称的数据库SQL语句
	/// </summary>
	/// <param name="name">SQL语句名称</param>
	/// <returns>只返回名称匹配的第一条语句，如果没有找到匹配的SQL语句，则返回null</returns>
	SqlStatement this[string name] { get; }

	/// <summary>
	/// 获取SQL语句数量
	/// </summary>
	/// <returns>SQL语句数量</returns>
	int GetSqlCount();

	/// <summary>
	/// 获取指定数据库类型的SQL语句数量
	/// </summary>
	/// <param name="databaseType">数据库类型</param>
	/// <returns>SQL语句数量</returns>
	int GetSqlCount(DBType databaseType);

	/// <summary>
	/// 获取指定数据库的SQL语句数量
	/// </summary>
	/// <param name="databaseName">数据库名称</param>
	/// <returns>SQL语句数量</returns>
	int GetSqlCount(string databaseName);

	/// <summary>
	/// 获取所有的SQL语句
	/// </summary>
	/// <returns>SQL语句对象数组</returns>
	SqlStatement[] GetSqls();

	/// <summary>
	/// 获取指定数据库类型的所有SQL语句
	/// </summary>
	/// <param name="databaseType">数据库类型</param>
	/// <returns>SQL语句对象数组</returns>
	SqlStatement[] GetSqls(DBType databaseType);

	/// <summary>
	/// 获取指定数据库名称的所有SQL语句
	/// </summary>
	/// <param name="databaseName">数据库名称</param>
	/// <returns>SQL语句的字典</returns>
	SqlStatement[] GetSqls(string databaseName);

	/// <summary>
	/// 获取指定名称的数据库SQL语句
	/// </summary>
	/// <param name="name">SQL语句名称</param>
	/// <returns>只返回名称匹配的第一条语句，如果没有找到匹配的SQL语句，则返回null</returns>
	SqlStatement GetSql(string name);

	/// <summary>
	/// 获取指定数据库类型和名称的SQL语句
	/// </summary>
	/// <param name="databaseType">数据库类型</param>
	/// <param name="name">SQL语句名称</param>
	/// <returns>SQL语句</returns>
	SqlStatement GetSql(DBType databaseType, string name);

	/// <summary>
	/// 获取指定数据库名称和SQL语句名称的SQL语句
	/// </summary>
	/// <param name="databaseName">数据库名称</param>
	/// <param name="name">SQL语句名称</param>
	/// <returns>SQL语句</returns>
	SqlStatement GetSql(string databaseName, string name);

	/// <summary>
	/// 添加SQL语句
	/// </summary>
	/// <param name="databaseType">数据库类型</param>
	/// <param name="name">SQL语句名称</param>
	/// <param name="sql">SQL语句</param>
	/// <returns>添加成功返回true，否则返回false</returns>
	bool AddSql(DBType databaseType, string name, string sql);

	/// <summary>
	/// 添加SQL语句
	/// </summary>
	/// <param name="databaseName">数据库名称</param>
	/// <param name="name">SQL语句名称</param>
	/// <param name="sql">SQL语句</param>
	/// <returns>添加成功返回true，否则返回false</returns>
	bool AddSql(string databaseName, string name, string sql);

	/// <summary>
	/// 移除所有与指定名称相同的SQL语句
	/// </summary>
	/// <param name="name">SQL语句名称</param>
	/// <returns>移除成功返回true，否则返回false</returns>
	bool RemoveSql(string name);

	/// <summary>
	/// 移除指定类型的SQL语句
	/// </summary>
	/// <param name="databaseType">数据库类型</param>
	/// <param name="name">SQL语句名称</param>
	/// <returns>移除成功返回true，否则返回false</returns>
	bool RemoveSql(DBType databaseType, string name);

	/// <summary>
	/// 移除指定类型的SQL语句
	/// </summary>
	/// <param name="databaseName">数据库名称</param>
	/// <param name="name">SQL语句名称</param>
	/// <returns>移除成功返回true，否则返回false</returns>
	bool RemoveSql(string databaseName, string name);

	/// <summary>
	/// 检测是否包含指定名称的SQL语句
	/// </summary>
	/// <param name="name">SQL语句名称</param>
	/// <returns>如果包含指定名称的SQL语句返回true，否则返回false</returns>
	bool ContainsSql(string name);

	/// <summary>
	/// 检测是否包含指定数据库和指定名称的SQL语句
	/// </summary>
	/// <param name="databaseType">数据库类型</param>
	/// <param name="name">SQL语句名称</param>
	/// <returns>如果包含则返回true，否则返回false</returns>
	bool ContainsSql(DBType databaseType, string name);

	/// <summary>
	/// 检测是否包含指定数据库和指定名称的SQL语句
	/// </summary>
	/// <param name="databaseName">数据库名称</param>
	/// <param name="name">SQL语句名称</param>
	/// <returns>如果包含则返回true，否则返回false</returns>
	bool ContainsSql(string databaseName, string name);

	/// <summary>
	/// 检测是否包含指定数据库类型的SQL语句
	/// </summary>
	/// <param name="databaseType">数据库类型</param>
	/// <returns>如果包含指定类型的数据库的SQL语句返回true，否则返回false</returns>
	bool ContainsDatabase(DBType databaseType);

	/// <summary>
	/// 检测是否包含指定名称的数据库的SQL语句
	/// </summary>
	/// <param name="databaseName">数据库名称</param>
	/// <returns>如果包含指定名称的数据库的SQL语句返回true，否则返回false</returns>
	bool ContainsDatabase(string databaseName);
}
