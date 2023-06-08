using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using Richfit.Garnet.Common.AOP.Handler;

namespace Richfit.Garnet.Module.Base.Infrastructure.Exceptions;

/// <summary>
/// Exception扩展类，对特定错误处理
/// </summary>
public static class ExceptionExtensions
{
	/// <summary>
	/// 判断错误类型是否是自定义错误类型
	/// </summary>
	/// <param name="ex"></param>
	/// <returns></returns>
	public static bool IsCustomCodeException(this Exception ex)
	{
		return ex is CustomCodeException;
	}

	/// <summary>
	/// 判断错误类型是否是验证错误类型
	/// </summary>
	/// <param name="ex"></param>
	/// <returns></returns>
	public static bool IsValidationException(this Exception ex)
	{
		return ex is ValidationException;
	}

	/// <summary>
	/// 判断错误类型是否是数据更新冲突错误类型
	/// </summary>
	/// <param name="ex"></param>
	/// <returns></returns>
	public static bool IsDbUpdateConcurrencyException(this Exception ex)
	{
		return ex is DbUpdateConcurrencyException;
	}

	/// <summary>
	/// 判断错误类型是否是数据数据实体校验错误类型
	/// </summary>
	/// <param name="ex"></param>
	/// <returns></returns>
	public static bool IsDbEntityValidationException(this Exception ex)
	{
		return ex is DbEntityValidationException;
	}

	/// <summary>
	/// 判断错误类型是否是Sql执行错误类型
	/// </summary>
	/// <param name="ex"></param>
	/// <returns></returns>
	public static bool IsSqlExecuteException(this Exception ex)
	{
		return ex is SqlExecuteException;
	}

	/// <summary>
	/// 判断错误类型是否是数据库更新冲突错误类型
	/// </summary>
	/// <param name="ex"></param>
	/// <returns></returns>
	public static bool IsDbUpdateConflictException(this Exception ex)
	{
		return ex is DbUpdateConflictException;
	}
}
