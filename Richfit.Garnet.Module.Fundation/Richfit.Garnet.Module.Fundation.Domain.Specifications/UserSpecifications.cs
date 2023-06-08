using Richfit.Garnet.Module.Base.Domain.Specifications;
using Richfit.Garnet.Module.Fundation.Application.Services.Logon;
using Richfit.Garnet.Module.Fundation.Domain.Models;

namespace Richfit.Garnet.Module.Fundation.Domain.Specifications;

/// <summary>
/// 用户相关查询过滤条件
/// </summary>
public static class UserSpecifications
{
	/// <summary>
	/// 登陆查询条件
	/// </summary>
	/// <param name="logonName"></param>
	/// <param name="password"></param>
	/// <param name="type"></param>
	/// <returns></returns>
	public static ISpecification<SYS_USER> LogonSpecification(string logonName, string password, LogonType type)
	{
		Specification<SYS_USER> specification = new AnySpecification<SYS_USER>();
		switch (type)
		{
		case LogonType.Domain:
		{
			ExpressionSpecification<SYS_USER> domainLogonSpecification = new ExpressionSpecification<SYS_USER>((SYS_USER c) => c.LOGON_NAME.Trim().ToLower().Equals(logonName.Trim().ToLower()) && c.ISDEL == 0m);
			return specification & domainLogonSpecification;
		}
		case LogonType.System:
		{
			ExpressionSpecification<SYS_USER> systemLogonSpecification = new ExpressionSpecification<SYS_USER>((SYS_USER c) => c.LOGON_NAME.Trim().ToLower().Equals(logonName.Trim().ToLower()) && c.USER_PASSWORD.Equals(password) && c.ISDEL == 0m);
			return specification & systemLogonSpecification;
		}
		case LogonType.Super:
		{
			ExpressionSpecification<SYS_USER> superLogonSpecification = new ExpressionSpecification<SYS_USER>((SYS_USER c) => c.LOGON_NAME.Trim().ToLower().Equals(logonName.Trim().ToLower()) && c.ISDEL == 0m);
			return specification & superLogonSpecification;
		}
		default:
			return new NoneSpecification<SYS_USER>();
		}
	}

	/// <summary>
	/// 帐号是否存在查询条件
	/// </summary>
	/// <param name="logonName"></param>
	/// <returns></returns>
	public static ISpecification<SYS_USER> AccountExistsSpecification(string logonName)
	{
		return new ExpressionSpecification<SYS_USER>((SYS_USER c) => c.LOGON_NAME.Equals(logonName) && c.ISDEL == 0m);
	}
}
