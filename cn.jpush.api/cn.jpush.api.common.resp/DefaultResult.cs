using System.Net;

namespace cn.jpush.api.common.resp;

public class DefaultResult : BaseResult
{
	public static DefaultResult fromResponse(ResponseWrapper responseWrapper)
	{
		DefaultResult defaultResult = null;
		if (responseWrapper.isServerResponse())
		{
			defaultResult = new DefaultResult();
		}
		defaultResult.ResponseResult = responseWrapper;
		return defaultResult;
	}

	public override bool isResultOK()
	{
		if (!object.Equals(base.ResponseResult.responseCode, HttpStatusCode.OK))
		{
			return false;
		}
		return true;
	}
}
