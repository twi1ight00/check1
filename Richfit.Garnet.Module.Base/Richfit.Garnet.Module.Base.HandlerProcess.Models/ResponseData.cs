using System.Text;
using Richfit.Garnet.Common.Extensions;

namespace Richfit.Garnet.Module.Base.HandlerProcess.Models;

/// <summary>
/// 请求响应数据对象
/// </summary>
public class ResponseData
{
	/// <summary>
	/// 返回代码
	/// </summary>
	public string Code { get; set; }

	/// <summary>
	/// 返回消息
	/// </summary>
	public string Message { get; set; }

	/// <summary>
	/// 返回数据类型，参见ResponseDataType的定义
	/// </summary>
	public ResponseDataType Type { get; set; }

	/// <summary>
	/// 返回数据
	/// </summary>
	public string Data { get; set; }

	/// <summary>
	/// 构造响应数据对象
	/// </summary>
	public ResponseData()
	{
		Type = ResponseDataType.Json;
	}

	/// <summary>
	/// 构造响应数据对象
	/// </summary>
	/// <param name="code">返回代码</param>
	public ResponseData(string code)
	{
		Code = code;
	}

	/// <summary>
	/// 获取响应数据的字符串表示
	/// </summary>
	/// <returns></returns>
	public override string ToString()
	{
		StringBuilder sbRequest = new StringBuilder();
		sbRequest.AppendLine("Code:" + Code);
		sbRequest.AppendLine("Type:" + Type);
		sbRequest.AppendLine("Message:" + Message);
		sbRequest.AppendLine("Data:" + Data);
		return sbRequest.ToString();
	}

	/// <summary>
	/// 将响应数据序列化为Json字符串
	/// </summary>
	/// <returns></returns>
	public string ToJson()
	{
		return this.JsonSerialize();
	}
}
