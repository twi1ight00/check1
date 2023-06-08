using Richfit.Garnet.Module.Base.Domain.Specifications;
using Richfit.Garnet.Module.HRManagement.Domain.Models;

namespace Richfit.Garnet.Module.HRManagement.Domain.Specifications;

internal class EmployeeSpecifications
{
	/// <summary>
	/// 删除查询条件
	/// </summary>
	/// <param name="delStatus">0为未删除1为已删除</param>
	/// <returns>返回实体的删除条件</returns>
	public static ISpecification<HR_EMPLOYEE> IsDelSpecification(int delStatus)
	{
		Specification<HR_EMPLOYEE> specification = new AnySpecification<HR_EMPLOYEE>();
		ExpressionSpecification<HR_EMPLOYEE> isDelSpecification = new ExpressionSpecification<HR_EMPLOYEE>((HR_EMPLOYEE c) => c.ISDEL == (decimal?)(decimal)delStatus);
		return specification & isDelSpecification;
	}
}
