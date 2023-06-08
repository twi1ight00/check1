using System;
using System.Text;

namespace Richfit.Garnet.Module.Base.Infrastructure.Exceptions;

/// <summary>
/// Sql执行错误，包含执行的Sql语句，参数，及错误信息
/// </summary>
public class SqlExecuteException : Exception
{
	/// <summary>
	/// sql语句
	/// </summary>
	public string Sql { get; private set; }

	/// <summary>
	/// 参数
	/// </summary>
	public object[] Parameter { get; private set; }

	/// <summary>
	/// 错误
	/// </summary>
	public Exception Exception { get; private set; }

	/// <summary>
	/// 构造函数
	/// </summary>
	/// <param name="sql">sql语句</param>
	/// <param name="parameter">参数</param>
	/// <param name="exception">错误</param>
	public SqlExecuteException(string sql, object[] parameter, Exception exception)
	{
		Sql = sql;
		Parameter = parameter;
		Exception = exception;
	}

	/// <summary>
	/// ToString
	/// </summary>
	/// <returns></returns>
	public override string ToString()
	{
		StringBuilder message = new StringBuilder();
		message.AppendLine("Exception occured: " + Exception.Message);
		message.AppendLine("SQL: " + Sql);
		if (Parameter != null && Parameter.Length > 0)
		{
			for (int i = 0; i < Parameter.Length; i++)
			{
				message.AppendLine("Parameter[" + i + "]: " + Parameter[i].ToString());
			}
		}
		return message.ToString();
	}
}
