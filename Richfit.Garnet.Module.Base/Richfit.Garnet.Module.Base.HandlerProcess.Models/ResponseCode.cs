namespace Richfit.Garnet.Module.Base.HandlerProcess.Models;

/// <summary>
/// 请求返回代码
/// </summary>
public class ResponseCode
{
	/// <summary>
	/// 执行成功（公共）
	/// </summary>
	public const string ExcecuteSuccess = "Public.I_0001";

	/// <summary>
	/// 验证错误（公共）
	/// </summary>
	public const string ValidateError = "Public.V_0001";

	/// <summary>
	/// Entity Framewok实体验证错误
	/// </summary>
	public const string DbEntityValidateError = "Public.V_0003";

	/// <summary>
	/// 执行错误（公共）
	/// </summary>
	public const string ExcecuteError = "Public.E_0001";

	/// <summary>
	/// 数据库更新并发冲突错误
	/// </summary>
	public const string DbUpdateConcurrencyError = "Public.E_0002";

	/// <summary>
	/// 没有定义请求数据错误
	/// </summary>
	public const string NoFunctionRequestData = "Public.E_0003";

	/// <summary>
	/// 功能代码没有对应的Handler错误
	/// </summary>
	public const string FunctionCodeNoHandledError = "Public.E_0004";

	/// <summary>
	/// Do Handler中发生未知错误
	/// </summary>
	public const string HandlerUndefinedError = "Public.E_0005";

	/// <summary>
	/// 请求用户未在系统登陆注册错误
	/// </summary>
	public const string UserNotLogon = "Public.E_0006";

	/// <summary>
	/// 用户没有权限执行某功能错误
	/// </summary>
	public const string UserCanNotDoFunction = "Public.E_0007";

	/// <summary>
	/// http访问失败
	/// </summary>
	public const string HttpAccessFail = "Public.E_0010";

	/// <summary>
	/// 访问外部服务配置错误
	/// </summary>
	public const string AccessConfigError = "Public.E_0011";

	/// <summary>
	/// 系统握手发生错误
	/// </summary>
	public const string SystemShakeError = "Public.E_0012";

	/// <summary>
	/// 数据库更新冲突错误
	/// </summary>
	public const string DbUpdateConflictError = "Public.E_0013";
}
