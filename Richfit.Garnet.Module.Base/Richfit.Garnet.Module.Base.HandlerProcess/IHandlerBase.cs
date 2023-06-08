using System.Web;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;

namespace Richfit.Garnet.Module.Base.HandlerProcess;

/// <summary>
/// 请求处理接口
/// </summary>
public interface IHandlerBase
{
	/// <summary>
	/// 请求数据
	/// </summary>
	RequestData RequestData { get; set; }

	/// <summary>
	/// 实例化响应数据
	/// </summary>
	void ProcessRequest(HttpContext context);
}
