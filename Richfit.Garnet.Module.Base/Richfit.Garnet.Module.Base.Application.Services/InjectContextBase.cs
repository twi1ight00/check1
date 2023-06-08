using System.Collections.Generic;

namespace Richfit.Garnet.Module.Base.Application.Services;

/// <summary>
/// 服务方法注入上下文基类
/// </summary>
public class InjectContextBase
{
	/// <summary>
	/// 注入执行是否成功
	/// </summary>
	public bool Success { get; set; }

	/// <summary>
	/// 执行结果编码，与ResponseData中的Code概念一致
	/// </summary>
	public string Code { get; set; }

	/// <summary>
	/// 执行返回的信息
	/// </summary>
	public IEnumerable<string> Messages { get; set; }

	/// <summary>
	/// 自定义数据
	/// </summary>
	public object CustomData { get; set; }

	/// <summary>
	/// 构造对象
	/// </summary>
	public InjectContextBase()
	{
		Success = true;
		Messages = new List<string>();
	}
}
