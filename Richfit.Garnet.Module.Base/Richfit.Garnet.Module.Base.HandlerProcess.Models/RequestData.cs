using System.Text;

namespace Richfit.Garnet.Module.Base.HandlerProcess.Models;

/// <summary>
/// 请求数据对象
/// </summary>
public class RequestData
{
	/// <summary>
	/// 验证后的客户端验证标识
	/// </summary>
	public string TokenGuid { get; set; }

	/// <summary>
	/// 是否移动端请求
	/// </summary>
	public int IsMobile { get; set; }

	/// <summary>
	/// 请求的功能代码
	/// </summary>
	public string ActionCode { get; set; }

	/// <summary>
	/// 请求的数据，Json字符串格式
	/// </summary>
	public string Data { get; set; }

	/// <summary>
	/// 将数据对象转换为字符串表示
	/// </summary>
	/// <returns></returns>
	public override string ToString()
	{
		StringBuilder sbRequest = new StringBuilder();
		sbRequest.AppendLine("Token:" + TokenGuid);
		sbRequest.AppendLine("Action:" + ActionCode);
		sbRequest.AppendLine("Data:" + Data);
		return sbRequest.ToString();
	}
}
