using System;

namespace Richfit.Garnet.Module.Base.Infrastructure.Exceptions;

/// <summary>
/// 数据库更新冲突错误
/// </summary>
public class DbUpdateConflictException : Exception
{
	/// <summary>
	/// 构造异常对象
	/// </summary>
	public DbUpdateConflictException()
	{
	}
}
