using System.Web;
using Newtonsoft.Json;
using Richfit.Garnet.Common.Extensions;
using Richfit.Garnet.Module.Base.HandlerProcess.Models;

namespace Richfit.Garnet.Module.Base.Infrastructure.ExternalAccess;

/// <summary>
/// 访问提供者
/// </summary>
public class AccessProvider
{
	/// <summary>
	/// 访问请求
	/// </summary>
	/// <param name="serviceUri">请求的URL地址</param>
	/// <param name="requestData">请求数据</param>
	/// <returns></returns>
	public static ResponseData Access(string serviceUri, RequestData requestData)
	{
		ResponseData responseData = null;
		if (!string.IsNullOrEmpty(serviceUri) && requestData != null)
		{
			HttpClient client = new HttpClient(serviceUri);
			responseData = HttpUtility.HtmlDecode(client.Post(HttpUtility.UrlEncode(requestData.JsonSerialize()))).JsonDeserialize<ResponseData>(new JsonConverter[0]);
		}
		else
		{
			responseData.Code = "Public.E_0003";
			responseData.Message = "请求数据格式错误（URL or Data）！";
		}
		return responseData;
	}
}
