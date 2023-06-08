using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Common.Data;

/// <summary>
/// 数据库连接对象
/// </summary>
public class DatabaseConnection
{
	/// <summary>
	/// 获取数据库连接类型
	/// </summary>
	public DBType DatabaseType { get; private set; }

	/// <summary>
	/// 获取数据库连接名称
	/// </summary>
	public string DatabaseName { get; private set; }

	/// <summary>
	/// 获取数据库连接字符串
	/// </summary>
	public string ConnectionString { get; private set; }

	/// <summary>
	/// 初始化数据库连接对象
	/// </summary>
	/// <param name="name">数据库连接名称</param>
	/// <param name="connection">数据库连接字符串</param>
	/// <param name="type">数据库类型</param>
	public DatabaseConnection(string name, string connection, string type)
	{
		name.GuardNotNull();
		connection.GuardNotNull();
		DatabaseType = type.ConvertToEnum<DBType>();
		DatabaseName = name;
		ConnectionString = connection;
	}

	/// <summary>
	/// 初始化数据库连接对象
	/// </summary>
	/// <param name="name">数据库连接名称</param>
	/// <param name="connection">数据库连接字符串</param>
	/// <param name="type">数据库类型</param>
	public DatabaseConnection(string name, string connection, DBType type)
	{
		name.GuardNotNull();
		connection.GuardNotNull();
		DatabaseType = type;
		DatabaseName = name;
		ConnectionString = connection;
	}
}
