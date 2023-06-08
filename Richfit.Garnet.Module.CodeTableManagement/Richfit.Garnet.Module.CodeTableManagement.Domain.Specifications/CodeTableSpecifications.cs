using Richfit.Garnet.Module.Base.Domain.Specifications;
using Richfit.Garnet.Module.CodeTableManagement.Domain.Models;

namespace Richfit.Garnet.Module.CodeTableManagement.Domain.Specifications;

/// <summary>
/// 码表Specification定义
/// </summary>
public static class CodeTableSpecifications
{
	/// <summary>
	/// 删除查询条件
	/// </summary>
	/// <param name="delStatus">0为未删除1为已删除</param>
	/// <returns>返回实体的删除条件</returns>
	public static ISpecification<SYS_CODE_TABLE> IsDelSpecification(int delStatus)
	{
		Specification<SYS_CODE_TABLE> specification = new AnySpecification<SYS_CODE_TABLE>();
		ExpressionSpecification<SYS_CODE_TABLE> isDelSpecification = new ExpressionSpecification<SYS_CODE_TABLE>((SYS_CODE_TABLE c) => c.ISDEL == (decimal)delStatus);
		return specification & isDelSpecification;
	}

	/// <summary>
	/// 禁用启用状态查询条件
	/// </summary>
	/// <param name="status"></param>
	/// <returns></returns>
	public static ISpecification<SYS_CODE_TABLE> StatusSpecification(int status)
	{
		Specification<SYS_CODE_TABLE> specification = new AnySpecification<SYS_CODE_TABLE>();
		ExpressionSpecification<SYS_CODE_TABLE> statusSpecification = new ExpressionSpecification<SYS_CODE_TABLE>((SYS_CODE_TABLE c) => c.STATUS == (decimal?)(decimal)status);
		return specification & statusSpecification;
	}

	/// <summary>
	/// 获得系统码表信息
	/// </summary>
	/// <returns></returns>
	public static ISpecification<SYS_CODE_TABLE> SystemSpecification()
	{
		return new ExpressionSpecification<SYS_CODE_TABLE>((SYS_CODE_TABLE c) => c.CODE_ID != null && c.ISDEL == 0m && c.STATUS == (decimal?)1m);
	}
}
