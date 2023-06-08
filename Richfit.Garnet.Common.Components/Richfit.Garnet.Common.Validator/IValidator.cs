using System.Collections.Generic;

namespace Richfit.Garnet.Common.Validator;

/// <summary>
/// DTO和POCO验证接口
/// </summary>
public interface IValidator
{
	/// <summary>
	/// 验证是否可用
	/// </summary>
	/// <typeparam name="TEntity">类型</typeparam>
	/// <param name="item">对象</param>
	/// <returns>true，验证通过；false，验证失败</returns>
	bool IsValid<TEntity>(TEntity item) where TEntity : class;

	/// <summary>
	/// 获得验证错误的消息集合
	/// </summary>
	/// <typeparam name="TEntity">类型</typeparam>
	/// <param name="item">对象</param>
	/// <returns></returns>
	IEnumerable<string> GetInvalidMessages<TEntity>(TEntity item) where TEntity : class;
}
